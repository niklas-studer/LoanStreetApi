using LoanStreetApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICosmosDBService>(CreateCosmosService().GetAwaiter().GetResult());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task<CosmosDBService> CreateCosmosService()
{
    var connectionString = builder.Configuration.GetConnectionString("CosmosDb");
    var databaseName = builder.Configuration["DatabaseName"];
    var containerName = builder.Configuration["ContainerName"];

    var client = new Microsoft.Azure.Cosmos.CosmosClient(connectionString);
  
    var database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
    await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");
    var cosmosDbService = new CosmosDBService(client, databaseName, containerName);
    return cosmosDbService;
}