using DesignPatternsDemo.Domain.Orders;
using DesignPatternsDemo.Kernel.Exceptions;

namespace DesignPatternsDemo.Infrastructure.Orders;

public class OrderLocalRepository : IOrderRepository
{
    private static List<Order> orders = new List<Order>();
    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return orders.FirstOrDefault(o => o.Id == id);
    }

    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        return orders;
    }

    public Task AddOrderAsync(Order order, CancellationToken cancellationToken)
    {
        orders.Add(order);
        return Task.CompletedTask;
    }

    public Task UpdateOrderAsync(Order order, CancellationToken cancellationToken)
    {
        var index = orders.FindIndex(o => o.Id == order.Id);
        if (index >= 0)
        {
            orders[index] = order;
        }
        return Task.CompletedTask;
    }

    public Task DeleteOrderAsync(Order order, CancellationToken cancellationToken)
    {
        var index = orders.FindIndex(o => o.Id == order.Id);

        if (index < 0)
        {
            throw new NotFoundException(nameof(Order), order.Id);
        }
        
        orders.RemoveAt(index);
        
        return Task.CompletedTask;
    }
}