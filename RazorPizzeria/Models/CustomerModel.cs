namespace RazorPizzeria.Models
{

    public class CustomerModel
    {
            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
            public float PhoneNumber { get; set; }
            public bool AddressLine1 { get; set; }
            public bool AddressLine2 { get; set; }
            public bool City { get; set; }
            public bool State { get; set; }
            public bool PostalCode { get; set; }

        
    }
}
