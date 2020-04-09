using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Options;
using RestaurantBusiness.DAL.Interfaces;
using RestaurantBusiness.Domain.DatabaseConfiguration;
using RestaurantBusiness.Domain.Models;

namespace RestaurantBusiness.DAL.Repositories
{
    public class FoodRepository : IRepository<Food>
    {
        private readonly Container _foodContainer;

        public FoodRepository(CosmosClient client, IOptions<CosmosDatabaseSettings> settings)
        {
            _foodContainer = client.GetContainer(settings.Value.CosmosDbDatabaseId, "foods");
        }

        public async Task CreateItemAsync(Food item)
        {
            item.Id = Guid.NewGuid().ToString();
            await _foodContainer.CreateItemAsync(item);
        }

        public async Task CreateSeveralItemsAsync(IEnumerable<Food> items)
        {
            await Task.WhenAll(items.Select(async food =>
            {
                await _foodContainer.CreateItemAsync(food);
            }));
        }

        public async Task<IEnumerable<Food>> GetAllItemsAsync(Expression<Func<Food, bool>> filter = null)
        {
            var foodQueryable = _foodContainer.GetItemLinqQueryable<Food>().AsQueryable();

            if(filter != null)
            {
                foodQueryable = foodQueryable.Where(filter);
            }

            var restaurants = new List<Food>();
            restaurants.AddRange(await foodQueryable.ToFeedIterator().ReadNextAsync());

            return restaurants;
        }

        public async Task<Food> GetItemAsync(string id, string partitionKey)
        {
            return await _foodContainer.ReadItemAsync<Food>(id, new PartitionKey(partitionKey));
        }
    }
}
