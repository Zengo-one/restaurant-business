using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;

namespace RestaurantBusiness.Infrastructure.CosmosDb
{
    public static class CosmosClientInitializer
    {
        public static CosmosClient BuildClient(IConfiguration configuration)
        {
            string endpointUri = configuration["CosmosDbEndpointUri"];
            string primaryKey = configuration["CosmosDbPrimaryKey"];

            CosmosClientBuilder clientBuilder = new CosmosClientBuilder(
                endpointUri, primaryKey);
            CosmosClient client = clientBuilder
                                .WithConnectionModeDirect()
                                .Build();

            return client;
        }
    }
}
