using AutoMapper;
using RestaurantBusiness.BLL.DTO;
using RestaurantBusiness.BLL.Interfaces;
using RestaurantBusiness.DAL.Interfaces;
using RestaurantBusiness.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.BLL.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantRepository;
        private readonly IRepository<Food> _foodRepository;
        private readonly IMapper _mapper;

        public RestaurantService(
            IRepository<Restaurant> restaurantRepository,
            IRepository<Food> foodRepository,
            IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task CreateRestaurant(RestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            restaurant.Id = Guid.NewGuid().ToString();
            await _restaurantRepository.CreateItemAsync(restaurant);

            foreach(var food in restaurantDto.Menu)
            {
                food.RestaurantId = restaurant.Id;
                await _foodRepository.CreateItemAsync(food);
            }
        }

        public async Task<RestaurantDto> GetRestaurant(string id)
        {
            var restaurant = await _restaurantRepository.GetItemAsync(id);
            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto;
        }

        public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAllItemsAsync(null);
            var restaurantDtos = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            foreach(var restaurant in restaurantDtos)
            {
                restaurant.Menu = new List<Food>();
                restaurant.Menu.AddRange(await _foodRepository.GetAllItemsAsync(f => f.RestaurantId == restaurant.Id));
            }

            return restaurantDtos;
        }
    }
}
