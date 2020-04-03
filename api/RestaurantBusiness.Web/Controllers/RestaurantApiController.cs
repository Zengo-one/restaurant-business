using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.DAL.Interfaces;
using RestaurantBusiness.Domain.Models;
using System.Threading.Tasks;

namespace RestaurantBusiness.Web.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantApiController : ControllerBase
    {
        private readonly IRepository<Restaurant> _restaurantRepository;

        public RestaurantApiController(IRepository<Restaurant> restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(Restaurant restaurant)
        {
            await _restaurantRepository.CreateItemAsync(restaurant);

            return Ok();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetRestaurant(string id)
        {
            var restaurant = await _restaurantRepository.GetItemAsync(id);

            return Ok(restaurant);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAllItemsAsync();

            return Ok(restaurants);
        }
    }
}