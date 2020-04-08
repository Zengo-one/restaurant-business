using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestaurantBusiness.DAL.Interfaces
{
    public interface IRepository<TItem>
    {
        Task CreateItemAsync(TItem item);

        Task CreateSeveralItemsAsync(IEnumerable<TItem> items);

        Task<TItem> GetItemAsync(string id, string partitionKey);

        Task<IEnumerable<TItem>> GetAllItemsAsync(Expression<Func<TItem, bool>> filter = null);
    }
}
