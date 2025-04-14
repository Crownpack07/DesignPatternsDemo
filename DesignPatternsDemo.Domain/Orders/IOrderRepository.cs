namespace DesignPatternsDemo.Domain.Orders;

public interface IOrderRepository
{
    public Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    public Task<List<Order>> GetAllAsync(CancellationToken cancellationToken);
    
    public Task AddOrderAsync(Order order, CancellationToken cancellationToken);
    
    public Task UpdateOrderAsync(Order order, CancellationToken cancellationToken);
    
    public Task DeleteOrderAsync(Order order, CancellationToken cancellationToken);
}