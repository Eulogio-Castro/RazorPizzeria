using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Areas.Identity.Data;
using RazorPizzeria.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace RazorPizzeria.Pages.Profile
{
    public class MyOrdersModel : PageModel
    {
        private readonly ApplicationDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

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
    }
}
