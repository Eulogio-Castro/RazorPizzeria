using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Helpers;
using RazorPizzeria.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace RazorPizzeria.Pages
{
    public class IndexModel : PageModel
    {
        public const string SessionKeyOrder = "_Order";

        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDBContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {


            PizzaOrderModel currentOrder = HttpContext.Session.GetObject<PizzaOrderModel>(SessionKeyOrder);
            
            if(currentOrder == null)
            {
                HttpContext.Session.SetObject(SessionKeyOrder, new PizzaOrderModel());
            }
        }

    }
}