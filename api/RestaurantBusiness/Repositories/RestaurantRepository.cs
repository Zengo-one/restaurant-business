using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using RestaurantBusiness.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBusiness.Repositories
{
    public class RestaurantRepository
    {
        private readonly Container _container;

        public RestaurantRepository(Database database)
        {
            _container = database.GetContainer("restaurants");
        }

        public async Task CreateRestaurantAsync(Restaurant restaurant)
        {
            await _container.CreateItemAsync(restaurant);
        }

        public async Task<Restaurant> GetRestaurantAsync(string id)
        {
            return await _container.ReadItemAsync<Restaurant>(id, new PartitionKey());
        }

        public FeedIterator<Restaurant> GetAllRestaurantsAsync()
        {
            return _container.GetItemLinqQueryable<Restaurant>()
                .ToFeedIterator();
        }
    }
}
