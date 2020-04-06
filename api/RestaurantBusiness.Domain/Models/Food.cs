using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestaurantBusiness.Domain.Models
{
    public class Food
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string RestaurantId { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public List<Ingredient> Ingredients { get; set; }    
    }
}
