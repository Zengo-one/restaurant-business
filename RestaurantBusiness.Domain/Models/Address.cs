using Newtonsoft.Json;

namespace RestaurantBusiness.Domain.Models
{
    public class Address
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
