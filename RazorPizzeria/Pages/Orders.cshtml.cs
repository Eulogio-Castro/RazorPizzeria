using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages
{
    public class OrdersModel : PageModel
    {
        public List<PizzaOrderModel> PizzaOrders = new List<PizzaOrderModel>();
        private readonly ApplicationDBContext _context;

        public OrdersModel(ApplicationDBContext context)
        {
            _context = context;
            //_context.Database.EnsureCreated();
        }

        public void OnGet()
        {
            PizzaOrders = _context.Orders.OrderByDescending(p => p.OrderDate).ToList();
        }
    }
}
