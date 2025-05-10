using DesignPatternsDemo.Domain.Orders;
using DesignPatternsDemo.Kernel;

namespace DesignPatternsDemo.Api.Endpoints.Orders.Models;

public class OrderItemMapper : ICustomMapper<OrderItemModel, OrderItem>
{
    public OrderItem Map(OrderItemModel from) => new(from.ProductId, 
        from.ProductName,
        from.Description,
        from.UnitPrice);
}