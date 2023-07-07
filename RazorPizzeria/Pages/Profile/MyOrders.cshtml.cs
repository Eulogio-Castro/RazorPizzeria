using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Areas.Identity.Data;
using RazorPizzeria.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RazorPizzeria.Helpers;
using System.Linq;

namespace RazorPizzeria.Pages.Profile
{
    public class MyOrdersModel : PageModel
    {
        private readonly ApplicationDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public const string SessionKeyOrder = "_Order";

        public int _ReOrderID { get; set; }

        public List<PizzaOrderModel> MyPizzaOrders = new List<PizzaOrderModel>();

        public MyOrdersModel(ApplicationDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
                


        public void OnGet()
        {
            string? UserEmail = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);
            if (UserEmail != null)
                MyPizzaOrders = _context.Orders.Include(p=>p.Pizzas).Where(o => o.CustomerID.Equals(UserEmail)).Take(10).OrderByDescending(o=>o.OrderDate).ToList();
        }

        public IActionResult OnPost(int id)
        {
            Console.WriteLine(id + " selected");
            PizzaOrderModel? order = _context.Orders.Include(p => p.Pizzas).Where(o => o.Id.Equals(id)).Single();
            List<PizzasModel> pizzasModels = new List<PizzasModel>();

            foreach(PizzasModel prevPizza in order.Pizzas)
            {
                pizzasModels.Add(new PizzasModel()
                {
                    PizzaName = prevPizza.PizzaName,
                    BasePrice = prevPizza.BasePrice,
                    FinalPrice = prevPizza.FinalPrice,
                    HasBeef = prevPizza.HasBeef,
                    HasCheese = prevPizza.HasCheese,
                    HasHam = prevPizza.HasHam,
                    HasMushroom = prevPizza.HasMushroom,
                    HasPepperoni = prevPizza.HasPepperoni,
                    HasPizzaSauce = prevPizza.HasPizzaSauce,
                    HasPineapple = prevPizza.HasPineapple,
                    HasTuna = prevPizza.HasTuna,
                    ImageTitle = prevPizza.ImageTitle
                    
                });
            }


            PizzaOrderModel reOrder = new PizzaOrderModel() { Pizzas = pizzasModels };

            PizzaOrderModel blank = new PizzaOrderModel();
            HttpContext.Session.SetObject(SessionKeyOrder, blank);


            HttpContext.Session.SetObject(SessionKeyOrder, reOrder);
            return RedirectToPage("/Checkout/Checkout");

        }
    }




}
