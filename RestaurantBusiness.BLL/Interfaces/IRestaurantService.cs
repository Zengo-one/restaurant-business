using RestaurantBusiness.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.BLL.Interfaces
{
    public interface IRestaurantService
    {
        Task<RestaurantDto> GetRestaurant(string id);

        Task CreateRestaurant(RestaurantDto restaurantDto);

        Task<IEnumerable<RestaurantDto>> GetRestaurants();
    }
}
