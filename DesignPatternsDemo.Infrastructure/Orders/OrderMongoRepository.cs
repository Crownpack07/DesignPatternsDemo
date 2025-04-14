using DesignPatternsDemo.Domain.Orders;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DesignPatternsDemo.Infrastructure.Orders;

public class OrderMongoRepository : IOrderRepository
{
    private readonly IMongoCollection<Order> collection;

    public OrderMongoRepository(
        IOptions<Settings> settings,
        IMongoClient mongoClient)
    {
        collection = mongoClient
            .GetDatabase(settings.Value.DatabaseName)
            .GetCollection<Order>(settings.Value.OrdersCollectionName);
    }

    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => await collection
        .Find(o => o.Id == id)
        .FirstOrDefaultAsync(cancellationToken);

    public Task<List<Order>> GetAllAsync(CancellationToken cancellationToken) => collection
        .Find(Builders<Order>.Filter.Empty)
        .ToListAsync(cancellationToken);

    public Task AddOrderAsync(Order order, CancellationToken cancellationToken) => collection
        .InsertOneAsync(order, cancellationToken: cancellationToken);

    public Task UpdateOrderAsync(Order order, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrderAsync(Order order, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}