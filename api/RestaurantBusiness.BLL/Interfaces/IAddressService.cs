using RestaurantBusiness.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBusiness.BLL.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllAddresses();

        Task AddNewAddress(Address address);
    }
}
