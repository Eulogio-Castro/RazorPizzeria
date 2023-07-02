using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Areas.Identity.Data;
using RazorPizzeria.Models;
using System.Security.Claims;

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
                MyPizzaOrders = _context.Orders.Where(p => p.CustomerID.Equals(UserEmail)).OrderByDescending(p=>p.OrderDate).ToList();
        }
    }
}
