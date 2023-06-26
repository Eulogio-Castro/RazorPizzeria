using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages
{
    public class PizzaModel : PageModel
    {
        public List<PizzasModel> fakePizzaDB = new List<PizzasModel>()
        {
            new PizzasModel(){ ImageTitle="Margerita", PizzaName="Margerita", BasePrice=7, HasPizzaSauce = true, HasCheese=true, HasPepperoni = true, FinalPrice = 8},
            new PizzasModel(){ ImageTitle="Hawaiian", PizzaName="Hawaiian", BasePrice=7, HasPizzaSauce = true, HasCheese=true, HasPineapple = true, HasHam = true, FinalPrice = 10},
            new PizzasModel(){ ImageTitle="MeatFeast", PizzaName="MeatFeast", BasePrice=7, HasPizzaSauce = true, HasCheese=true, HasPepperoni = true, HasHam = true, HasBeef = true, FinalPrice = 10},
            new PizzasModel(){ ImageTitle="MeatFeast", PizzaName="Mushroom", BasePrice=7, HasPizzaSauce = true, HasCheese=true, HasMushroom = true, FinalPrice = 8},
            new PizzasModel(){ ImageTitle="Vegetarian", PizzaName="Vegetarian", BasePrice=7, HasPizzaSauce = true, HasCheese=true, FinalPrice = 10}
        };
        public void OnGet()
        {
        }
    }
}
