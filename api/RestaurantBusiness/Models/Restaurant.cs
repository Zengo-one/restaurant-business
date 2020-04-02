using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestaurantBusiness.Models
{
    public class Restaurant
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public List<Food> Menu { get; set; }
    }
}
