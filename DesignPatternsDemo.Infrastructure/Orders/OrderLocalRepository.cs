using DesignPatternsDemo.Domain.Orders;
using DesignPatternsDemo.Kernel.Exceptions;

namespace DesignPatternsDemo.Infrastructure.Orders;

public class OrderLocalRepository : IOrderRepository
{
    private static readonly List<Order> Orders = new List<Order>();
    public Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return Task.FromResult(Orders.FirstOrDefault(o => o.Id == id));
    }

    public Task<List<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(Orders);
    }

    public Task AddOrderAsync(Order order, CancellationToken cancellationToken)
    {
        Orders.Add(order);
        return Task.CompletedTask;
    }

    public Task UpdateOrderAsync(Order order, CancellationToken cancellationToken)
    {
        var index = Orders.FindIndex(o => o.Id == order.Id);
        if (index >= 0)
        {
            Orders[index] = order;
        }
        return Task.CompletedTask;
    }

    public Task DeleteOrderAsync(Order order, CancellationToken cancellationToken)
    {
        var index = Orders.FindIndex(o => o.Id == order.Id);

        if (index < 0)
        {
            throw new NotFoundException(nameof(Order), order.Id);
        }
        
        Orders.RemoveAt(index);
        
        return Task.CompletedTask;
    }
}