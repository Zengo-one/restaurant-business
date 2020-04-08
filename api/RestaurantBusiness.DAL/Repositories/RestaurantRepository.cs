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
        private readonly Container _restaurantsContainer;

        public RestaurantRepository(CosmosClient client, IOptions<CosmosDatabaseSettings> settings)
        {
            _restaurantsContainer = client.GetContainer(settings.Value.DatabaseId, "restaurants");
        }

        public async Task CreateItemAsync(Restaurant item)
        {
            await _restaurantsContainer.CreateItemAsync(item, new PartitionKey(item.Name));
        }

        public async Task<Restaurant> GetItemAsync(string id, string partitionKey)
        {
            return await _restaurantsContainer.ReadItemAsync<Restaurant>(id, new PartitionKey(partitionKey));
        }

        public async Task<IEnumerable<Restaurant>> GetAllItemsAsync(Expression<Func<Restaurant, bool>> filter = null)
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

        public async Task CreateSeveralItemsAsync(IEnumerable<Restaurant> items)
        {
            await Task.WhenAll(items.Select(async restaurant =>
            {
                await _restaurantsContainer.CreateItemAsync(restaurant);
            }));
        }
    }
}
