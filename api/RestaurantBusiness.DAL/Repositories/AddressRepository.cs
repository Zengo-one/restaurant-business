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
        private readonly CosmosClient _client;
        private readonly Database _database;
        private readonly Container _addressContainer;

        public AddressRepository(IOptions<CosmosDbSettings> settings)
        {
            _client = new CosmosClient(settings.Value.EndpointUri, settings.Value.PrimaryKey);
            _database = _client.GetDatabase(settings.Value.DatabaseId);
            _addressContainer = _database.GetContainer("addresses");
        }

        public async Task CreateItemAsync(Address item)
        {
            item.Id = Guid.NewGuid().ToString();
            await _addressContainer.CreateItemAsync(item);
        }

        public async Task CreateSeveralItems(IEnumerable<Address> items)
        {
            foreach(var item in items)
            {
                await _addressContainer.CreateItemAsync(item, new PartitionKey(item.Country));
            }
        }

        public async Task<IEnumerable<Address>> GetAllItemsAsync(Expression<Func<Address, bool>> filter)
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

        public async Task<Address> GetItemAsync(string id)
        {
            return await _addressContainer.ReadItemAsync<Address>(id, new PartitionKey("Ukraine"));
        }
    }
}
