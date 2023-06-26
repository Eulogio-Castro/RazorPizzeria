using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {

        public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public string ImageTitle { get; set; }


        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(PizzaName))
            {
                PizzaName = "Custom Pizza";
            }
            if (string.IsNullOrWhiteSpace(ImageTitle))
            {
                ImageTitle = "Create";
            }
        }
    }
}
