using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestaurantBusiness.DatabaseConfiguration;
using RestaurantBusiness.Models;
using RestaurantBusiness.Repositories;
using System.Threading.Tasks;

namespace RestaurantBusiness.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantApiController : ControllerBase
    {
        private readonly RestaurantRepository _restaurantRepository;

        public RestaurantApiController(IOptions<CosmosDbSettings> options)
        {
            _restaurantRepository = new RestaurantRepository(options);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(Restaurant restaurant)
        {
            await _restaurantRepository.CreateRestaurantAsync(restaurant);

            return Ok();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetRestaurant(string id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantAsync(id);

            return Ok(restaurant);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurantsAsync();

            return Ok(restaurants);
        }
    }
}