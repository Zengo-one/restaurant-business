using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using RestaurantBusiness.Domain.DatabaseConfiguration;

namespace RestaurantBusiness.Infrastructure.CosmosDb
{
    public static class CosmosClientInitializer
    {
        public static CosmosClient BuildClient(IConfiguration configuration)
        {
            var cosmosSettings = configuration.GetSection(nameof(CosmosClientSettings)).Get<CosmosClientSettings>();
            CosmosClientBuilder clientBuilder = new CosmosClientBuilder(cosmosSettings.EndpointUri, cosmosSettings.PrimaryKey);
            CosmosClient client = clientBuilder
                                .WithConnectionModeDirect()
                                .Build();

            return client;
        }
    }
}
