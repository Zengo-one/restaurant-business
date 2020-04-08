using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.BLL.Interfaces;
using RestaurantBusiness.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.Web.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    public class AddressApiController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressApiController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task AddNewAddress([FromBody]Address address)
        {
            await _addressService.AddNewAddress(address);
        }

        [HttpGet]
        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            var addresses = await _addressService.GetAllAddresses();

            return addresses;
        }
    }
}