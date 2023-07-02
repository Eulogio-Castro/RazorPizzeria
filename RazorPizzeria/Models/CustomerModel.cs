using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RazorPizzeria.Models
{
    [Index(nameof(CustomerID), IsUnique = true)]
    public class CustomerModel
    {
            public int CustomerID { get; set; }

            [StringLength(355)]
            public string CustomerName { get; set; }
            public float PhoneNumber { get; set; }
            public bool AddressLine1 { get; set; }
            public bool AddressLine2 { get; set; }
            public bool City { get; set; }
            public bool State { get; set; }
            public bool PostalCode { get; set; }

        
    }
}
