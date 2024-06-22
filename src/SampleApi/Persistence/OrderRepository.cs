using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SampleApi.Domain;

namespace SampleApi.Persistence;

internal sealed class OrderRepository
{
    private readonly IMongoCollection<OrderEntity> _ordersCollection;

    public OrderRepository(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(
            mongoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);

        _ordersCollection = mongoDatabase.GetCollection<OrderEntity>("orders");
    }

    public Task<OrderEntity> FindAsync(Guid id)
    {
        return _ordersCollection
            .Find(record => record.Id == id)
            .FirstOrDefaultAsync();
    }

    public Task CreateAsync(OrderEntity entity)
    {
        return _ordersCollection.InsertOneAsync(entity);
    }

    public Task UpdateAsync(OrderEntity entity)
    {
        return _ordersCollection.ReplaceOneAsync(record => record.Id == entity.Id, entity);
    }
}