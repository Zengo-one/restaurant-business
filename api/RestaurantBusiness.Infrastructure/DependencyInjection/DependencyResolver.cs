using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantBusiness.BLL.Interfaces;
using RestaurantBusiness.BLL.Services;
using RestaurantBusiness.DAL.Interfaces;
using RestaurantBusiness.DAL.Repositories;
using RestaurantBusiness.Domain.Models;
using RestaurantBusiness.Infrastructure.CosmosDb;

namespace RestaurantBusiness.Infrastructure.DependencyInjection
{
    public static class DependencyResolver
    {
        public static void Resolve(IServiceCollection services, IConfiguration configuration)
        {
            // Repositories
            services.AddTransient<IRepository<Restaurant>, RestaurantRepository>();
            services.AddTransient<IRepository<Food>, FoodRepository>();
            services.AddTransient<IRepository<Address>, AddressRepository>();

            // Services
            services.AddTransient<IRestaurantService, RestaurantService>();
            services.AddTransient<IAddressService, AddressService>();

            // CosmosDB
            services.AddSingleton(CosmosClientInitializer.BuildClient(configuration));
        }
    }
}
