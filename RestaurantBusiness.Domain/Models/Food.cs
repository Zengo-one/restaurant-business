using System.Collections.Generic;

namespace RestaurantBusiness.Domain.Models
{
    public class Food
    {
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public List<Ingredient> Ingredients { get; set; }    
    }
}
