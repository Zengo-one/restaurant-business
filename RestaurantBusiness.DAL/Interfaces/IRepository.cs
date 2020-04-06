using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestaurantBusiness.DAL.Interfaces
{
    public interface IRepository<TItem>
    {
        Task CreateItemAsync(TItem item);

        Task CreateSeveralItems(IEnumerable<TItem> items);

        Task<TItem> GetItemAsync(string id);

        Task<IEnumerable<TItem>> GetAllItemsAsync(Expression<Func<TItem, bool>> filter);
    }
}
