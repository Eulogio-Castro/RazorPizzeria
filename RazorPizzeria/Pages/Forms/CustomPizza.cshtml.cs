using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Forms
{
    public class CustomPizzaModel : PageModel
    {
        [BindProperty]
        public PizzasModel Pizza { get; set; }
        public float PizzaPrice { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            PizzaPrice = Pizza.BasePrice;
            if (Pizza.HasPizzaSauce) PizzaPrice += 1;
            if (Pizza.HasCheese) PizzaPrice += 1;
            if (Pizza.HasPepperoni) PizzaPrice += 1;
            if (Pizza.HasMushroom) PizzaPrice += 1;
            if (Pizza.HasTuna) PizzaPrice += 1;
            if (Pizza.HasPineapple) PizzaPrice += 1;
            if (Pizza.HasHam) PizzaPrice += 1;
            if (Pizza.HasBeef) PizzaPrice += 1;

            return RedirectToPage("/Checkout/Checkout", new {Pizza.PizzaName, PizzaPrice});
        }
    }
}
