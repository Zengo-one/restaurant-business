using RestaurantBusiness.Domain.Models;
using System.Collections.Generic;

namespace RestaurantBusiness.BLL.DTO
{
    public class RestaurantDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public List<Food> Menu { get; set; }
    }
}
