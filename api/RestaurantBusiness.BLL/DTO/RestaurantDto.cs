using RestaurantBusiness.Domain.Models;
using System.Collections.Generic;

namespace RestaurantBusiness.BLL.DTO
{
    public class RestaurantDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public List<Food> Menu { get; set; }
    }
}
