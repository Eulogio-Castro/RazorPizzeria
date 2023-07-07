using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPizzeria.Areas.Identity.Data;
using RazorPizzeria.Data;
using RazorPizzeria.Helpers;
using RazorPizzeria.Models;
using System.Data;
using System.Security.Claims;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class ThankYouModel : PageModel
    {
        public const string SessionKeyOrder = "_Order";

        public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }

        private readonly ApplicationDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PizzaOrderModel _currentOrder = new PizzaOrderModel();


        public ThankYouModel(ApplicationDBContext context, UserManager<RazorPizzeriaUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }

        public void OnGet()
        {

            try
            {
                _currentOrder = HttpContext.Session.GetObject<PizzaOrderModel>(SessionKeyOrder);
                string? UserEmail = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);
                _currentOrder.CustomerID = UserEmail==null? "Walk-In Customer" : UserEmail;
                _currentOrder.OrderPrice = _currentOrder.Pizzas.Sum(p => p.FinalPrice);
                _currentOrder.OrderDate = DateTime.UtcNow;
                _context.Database.EnsureCreated();
                


                _context.Orders.Add(_currentOrder);

                _context.SaveChanges();

                PizzaOrderModel blank = new PizzaOrderModel();

                HttpContext.Session.SetObject(SessionKeyOrder, blank);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
        }




    }
}
