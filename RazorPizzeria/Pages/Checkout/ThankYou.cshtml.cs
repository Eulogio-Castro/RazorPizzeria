using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPizzeria.Data;
using RazorPizzeria.Models;
using System.Data;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class ThankYouModel : PageModel
    {
        string connectionString = "Server=aws.connect.psdb.cloud;Database=razorpizzeriadb;user=ueg7ahbtdaecvzjiw0kw;password=pscale_pw_gQNdUv6EgT2BSfX3rs3BKjfMTmfa2BByfmrfiONlF4b";

    public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }

        private readonly ApplicationDBContext _context;
        public ThankYouModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            
            if (string.IsNullOrWhiteSpace(PizzaName))
            {
                PizzaName = "Custom Pizza";
            }

            
            try
            {
                _context.Database.EnsureCreated();
                _context.Orders.Add(new PizzaOrderModel() { PizzaName = this.PizzaName, FinalPrice = this.PizzaPrice });
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
        }
    }
}
