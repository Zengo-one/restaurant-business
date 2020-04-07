using Newtonsoft.Json;

namespace RestaurantBusiness.Domain.Models
{
    public class Restaurant
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string AddressId { get; set; }

        public string Country { get; set; }
    }
}
