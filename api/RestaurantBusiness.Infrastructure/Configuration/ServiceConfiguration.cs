using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantBusiness.Domain.DatabaseConfiguration;

namespace RestaurantBusiness.Infrastructure.Configuration
{
    public static class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CosmosDatabaseSettings>(configuration.GetSection(nameof(CosmosDatabaseSettings)));
            services.Configure<CosmosClientSettings>(configuration.GetSection(nameof(CosmosClientSettings)));
        }
    }
}
