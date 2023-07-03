using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;
using RazorPizzeria.Helpers;
using Microsoft.AspNetCore.Http;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {
        public const string SessionKeyOrder = "_Order";
        public const string SessionKeyPizza = "_Pizza";
        public PizzaOrderModel _currentOrder = new PizzaOrderModel();
        public float _OrderTotal = 0.0f;

        public CheckoutModel()
        {

        }


        public void OnGet()
        {
            _currentOrder = HttpContext.Session.GetObject<PizzaOrderModel>(SessionKeyOrder);
            _OrderTotal = _currentOrder.Pizzas.Sum(p => p.FinalPrice);
        }


    }
}
