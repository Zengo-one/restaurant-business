using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Linq;
using Microsoft.Extensions.Options;
using RestaurantBusiness.DatabaseConfiguration;
using RestaurantBusiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantBusiness.Repositories
{
    public class RestaurantRepository
    {
        private readonly CosmosClient _client;
        private readonly Database _database;
        private readonly Container _container;

        public RestaurantRepository(IOptions<CosmosDbSettings> options)
        {
            _client = new CosmosClient(options.Value.EndpointUri, options.Value.PrimaryKey);
            _database = _client.GetDatabase(options.Value.DatabaseId);
            _container = _database.GetContainer("restaurants");
        }

        public async Task CreateRestaurantAsync(Restaurant restaurant)
        {
            await _container.CreateItemAsync(restaurant);
        }

        public async Task<Restaurant> GetRestaurantAsync(string id)
        {
            return await _container.ReadItemAsync<Restaurant>(id, new PartitionKey("/country"));
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            var iterator = _container.GetItemLinqQueryable<Restaurant>()
                .ToFeedIterator();
            var restaurants = new List<Restaurant>();

            while (iterator.HasMoreResults)
            {
                foreach(var restaurant in await iterator.ReadNextAsync())
                {
                    restaurants.Add(restaurant);
                }
            }

            return restaurants;
        }
    }
}
