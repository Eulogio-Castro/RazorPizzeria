namespace RazorPizzeria.Models
{
    public class PizzasModel
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public string PizzaName { get; set; }
        public float BasePrice { get; set; } = 7;
        public bool HasPizzaSauce { get; set; }
        public bool HasCheese { get; set; }
        public bool HasPepperoni { get; set; }
        public bool HasMushroom { get; set; }
        public bool HasTuna { get; set; }
        public bool HasPineapple { get; set; }
        public bool HasHam { get; set; }
        public bool HasBeef { get; set; }
        public float FinalPrice { get; set; }

        public int PizzaOrderId { get; set; }
        public PizzaOrderModel PizzaOrder { get; set; } = null!;

    }
}
