
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RazorPizzeria.Models
{
    [Index(nameof(Id), IsUnique=true)]
    public class PizzaOrderModel
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100, MinimumLength =0)]
        public string PizzaName { get; set; }

        public float FinalPrice { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

    }
}
