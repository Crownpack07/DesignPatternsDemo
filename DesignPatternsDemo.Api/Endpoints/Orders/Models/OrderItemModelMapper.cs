using DesignPatternsDemo.Domain.Orders;
using DesignPatternsDemo.Kernel;

namespace DesignPatternsDemo.Api.Endpoints.Orders.Models;

public class OrderItemModelMapper : ICustomMapper<OrderItem, OrderItemModel>
{
    public OrderItemModel Map(OrderItem from) => new(from.ProductId, 
        from.ProductName,
        from.Description,
        from.UnitPrice);
}