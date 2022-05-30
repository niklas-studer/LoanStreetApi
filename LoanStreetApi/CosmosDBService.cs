using Microsoft.Azure.Cosmos;

namespace LoanStreetApi
{
    public class CosmosDBService : ICosmosDBService
    {
        private Container container;
        public CosmosDBService(
         CosmosClient cosmosDbClient,
         string databaseName,
         string containerName)
        {
            container = cosmosDbClient.GetContainer(databaseName, containerName);
        }
        public async Task AddAsync(Loan item)
        {
            await container.CreateItemAsync(item);
        }

        public async Task<Loan> GetAsync(string id)
        {
            var response = await container.ReadItemAsync<Loan>(id, new PartitionKey(id));
            return response.Resource;
        }

        public async Task UpdateAsync(string id, Loan item)
        {
           await container.UpsertItemAsync(item, new PartitionKey(id));
        }
    }
}
