using RestaurantBusiness.BLL.Interfaces;
using RestaurantBusiness.DAL.Interfaces;
using RestaurantBusiness.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.BLL.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;

        public AddressService(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task AddNewAddress(Address address)
        {
            await _addressRepository.CreateItemAsync(address);
        }

        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await _addressRepository.GetAllItemsAsync();
        }
    }
}
