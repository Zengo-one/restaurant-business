using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.DAL.Interfaces
{
    public interface IRepository<TItem>
    {
        Task CreateItemAsync(TItem item);

        Task<TItem> GetItemAsync(string id);

        Task<IEnumerable<TItem>> GetAllItemsAsync();
    }
}
