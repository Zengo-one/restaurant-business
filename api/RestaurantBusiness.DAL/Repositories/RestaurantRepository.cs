using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantBusiness.Domain.Models;
using RestaurantBusiness.Domain.DatabaseConfiguration;
using RestaurantBusiness.DAL.Interfaces;
using Microsoft.Extensions.Options;
using System;

namespace RestaurantBusiness.DAL.Repositories
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        private readonly CosmosClient _client;
        private readonly Database _database;
        private readonly Container _container;

        public RestaurantRepository(IOptions<CosmosDbSettings> settings)
        {
            _client = new CosmosClient(settings.Value.EndpointUri, settings.Value.PrimaryKey);
            _database = _client.GetDatabase(settings.Value.DatabaseId);
            _container = _database.GetContainer("restaurants");
        }

        public async Task CreateItemAsync(Restaurant item)
        {
            item.Id = Guid.NewGuid().ToString();
            await _container.CreateItemAsync(item);
        }

        public async Task<Restaurant> GetItemAsync(string id)
        {
            return await _container.ReadItemAsync<Restaurant>(id, new PartitionKey("/country"));
        }

        public async Task<IEnumerable<Restaurant>> GetAllItemsAsync()
        {
            var iterator = _container.GetItemLinqQueryable<Restaurant>()
                .ToFeedIterator();
            var restaurants = new List<Restaurant>();
            restaurants.AddRange(await iterator.ReadNextAsync());
            
            return restaurants;
        }
    }
}
