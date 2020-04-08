using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.BLL.DTO;
using RestaurantBusiness.BLL.Interfaces;
using System.Threading.Tasks;

namespace RestaurantBusiness.Web.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantApiController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantApiController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody]RestaurantDto restaurant)
        {
            await _restaurantService.CreateRestaurant(restaurant);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant(string id)
        {
            var restaurant = await _restaurantService.GetRestaurant(id);

            return Ok(restaurant);
        }

        [HttpGet("{country}")]
        public async Task<IActionResult> GetAllRestaurants(string country)
        {
            var restaurants = await _restaurantService.GetRestaurants(country);

            return Ok(restaurants);
        }
    }
}