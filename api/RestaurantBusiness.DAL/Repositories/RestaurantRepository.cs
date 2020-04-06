using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantBusiness.Domain.Models;
using RestaurantBusiness.Domain.DatabaseConfiguration;
using RestaurantBusiness.DAL.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RestaurantBusiness.DAL.Repositories
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        private readonly CosmosClient _client;
        private readonly Database _database;
        private readonly Container _restaurantsContainer;

        public RestaurantRepository(IOptions<CosmosDbSettings> settings)
        {
            _client = new CosmosClient(settings.Value.EndpointUri, settings.Value.PrimaryKey);
            _database = _client.GetDatabase(settings.Value.DatabaseId);
            _restaurantsContainer = _database.GetContainer("restaurants");
        }

        public async Task CreateItemAsync(Restaurant item)
        {
            await _restaurantsContainer.CreateItemAsync(item);
        }

        public async Task<Restaurant> GetItemAsync(string id)
        {
            return await _restaurantsContainer.ReadItemAsync<Restaurant>(id, new PartitionKey("/Country"));
        }

        public async Task<IEnumerable<Restaurant>> GetAllItemsAsync(Expression<Func<Restaurant, bool>> filter)
        {
            var restaurantQueryable = _restaurantsContainer.GetItemLinqQueryable<Restaurant>().AsQueryable();
            if(filter != null)
            {
                restaurantQueryable = restaurantQueryable.Where(filter);
            }

            var restaurants = new List<Restaurant>();
            restaurants.AddRange(await restaurantQueryable.ToFeedIterator().ReadNextAsync());

            return restaurants;
        }

        public async Task CreateSeveralItems(IEnumerable<Restaurant> items)
        {
            foreach(var item in items)
            {
                await _restaurantsContainer.CreateItemAsync(item);
            }
        }
    }
}
