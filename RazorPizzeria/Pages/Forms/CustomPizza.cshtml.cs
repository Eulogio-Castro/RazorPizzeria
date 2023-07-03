using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Helpers;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Forms
{
    public class CustomPizzaModel : PageModel
    {
        public const string SessionKeyOrder = "_Order";

        [BindProperty]
        public PizzasModel Pizza { get; set; }
        public float PizzaPrice { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Pizza.PizzaName == null) { Pizza.PizzaName = "Create"; }
            PizzaPrice = Pizza.BasePrice;
            if (Pizza.HasPizzaSauce) PizzaPrice += 1;
            if (Pizza.HasCheese) PizzaPrice += 1;
            if (Pizza.HasPepperoni) PizzaPrice += 1;
            if (Pizza.HasMushroom) PizzaPrice += 1;
            if (Pizza.HasTuna) PizzaPrice += 1;
            if (Pizza.HasPineapple) PizzaPrice += 1;
            if (Pizza.HasHam) PizzaPrice += 1;
            if (Pizza.HasBeef) PizzaPrice += 1;
            Pizza.FinalPrice = PizzaPrice;
            PizzaOrderModel currentOrder = HttpContext.Session.GetObject<PizzaOrderModel>(SessionKeyOrder);

            currentOrder.Pizzas.Add(Pizza);

            HttpContext.Session.SetObject(SessionKeyOrder, currentOrder);

            return RedirectToPage("/Checkout/Checkout");

        }
    }
}
