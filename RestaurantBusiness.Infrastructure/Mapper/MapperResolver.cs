using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace RestaurantBusiness.Infrastructure.Mapper
{
    public static class MapperResolver
    {
        public static void Resolve(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());
        }
    }
}
