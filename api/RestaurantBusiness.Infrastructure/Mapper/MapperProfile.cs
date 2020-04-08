using AutoMapper;
using RestaurantBusiness.BLL.DTO;
using RestaurantBusiness.Domain.Models;

namespace RestaurantBusiness.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ReverseMap()
                .ForMember(restaurant => restaurant.AddressId, opt => opt
                .MapFrom(restaurantDto => restaurantDto.Address.Id));
        }
    }
}
