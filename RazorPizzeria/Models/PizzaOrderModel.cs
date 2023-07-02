using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RazorPizzeria.Models
{
    [Index(nameof(Id), IsUnique=true)]
    public class PizzaOrderModel
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100, MinimumLength =0)]

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public string CustomerID { get; set; }

        public ICollection<PizzasModel> Pizzas { get; set; } = new List<PizzasModel>();
    }
}
