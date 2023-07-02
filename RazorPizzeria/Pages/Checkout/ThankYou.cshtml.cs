using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPizzeria.Areas.Identity.Data;
using RazorPizzeria.Data;
using RazorPizzeria.Models;
using System.Data;
using System.Security.Claims;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class ThankYouModel : PageModel
    {
        
    public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }

        private UserManager<RazorPizzeriaUser> _userManager;
        private readonly ApplicationDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public ThankYouModel(ApplicationDBContext context, UserManager<RazorPizzeriaUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            
            if (string.IsNullOrWhiteSpace(PizzaName))
            {
                PizzaName = "Custom Pizza";
            }

            
            try
            {
                string? UserEmail = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);
                

                _context.Database.EnsureCreated();


                _context.Orders.Add(new PizzaOrderModel() { PizzaName = this.PizzaName, FinalPrice = this.PizzaPrice, CustomerID= UserEmail });
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
        }




    }
}
