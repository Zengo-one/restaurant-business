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
                .ReverseMap();
        }
    }
}
