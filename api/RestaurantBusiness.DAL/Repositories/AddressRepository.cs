using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Options;
using RestaurantBusiness.DAL.Interfaces;
using RestaurantBusiness.Domain.DatabaseConfiguration;
using RestaurantBusiness.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestaurantBusiness.DAL.Repositories
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly Container _addressContainer;

        public AddressRepository(CosmosClient client, IOptions<CosmosDatabaseSettings> settings)
        {
            _addressContainer = client.GetContainer(settings.Value.CosmosDbDatabaseId, "addresses");
        }

        public async Task CreateItemAsync(Address item)
        {
            item.Id = Guid.NewGuid().ToString();
            await _addressContainer.CreateItemAsync(item);
        }

        public async Task CreateSeveralItemsAsync(IEnumerable<Address> items)
        {
            await Task.WhenAll(items.Select(async address =>
            {
                await _addressContainer.CreateItemAsync(address);
            }));
        }

        public async Task<IEnumerable<Address>> GetAllItemsAsync(Expression<Func<Address, bool>> filter = null)
        {
            var addressQueryable = _addressContainer.GetItemLinqQueryable<Address>().AsQueryable();

            if(filter != null)
            {
                addressQueryable = addressQueryable.Where(filter);
            }

            var addresses = new List<Address>();
            addresses.AddRange(await addressQueryable.ToFeedIterator().ReadNextAsync());

            return addresses;
        }

        public async Task<Address> GetItemAsync(string id, string partitionKey)
        {
            return await _addressContainer.ReadItemAsync<Address>(id, new PartitionKey(partitionKey));
        }
    }
}
