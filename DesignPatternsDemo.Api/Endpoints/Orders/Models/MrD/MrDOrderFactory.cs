using DesignPatternsDemo.Api.Endpoints.Orders.Models.UberEats;
using DesignPatternsDemo.Domain.Orders;
using DesignPatternsDemo.Kernel;

namespace DesignPatternsDemo.Api.Endpoints.Orders.Models.MrD;

public class MrDOrderFactory : IOrderFactory
{
    private readonly ICustomMapper<OrderItemModel, OrderItem> orderItemMapper;
    private readonly ICustomMapper<OrderItem, OrderItemModel> orderItemModelMapper;

    public MrDOrderFactory(ICustomMapper<OrderItemModel, OrderItem> orderItemMapper,
        ICustomMapper<OrderItem, OrderItemModel> orderItemModelMapper)
    {
        this.orderItemMapper = orderItemMapper;
        this.orderItemModelMapper = orderItemModelMapper;
    }

    public bool IsApplicable(CreateOrderRequest request) => request is MrDOrderRequest;

    public bool IsApplicable(Order value) => value is MrDOrder;

    public Order Create(CreateOrderRequest request)
    {
        var orderRequest = request as MrDOrderRequest;

        if (orderRequest == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return new MrDOrder(Guid.NewGuid(),
            orderRequest.OrderDate,
            orderRequest.Items.Select(orderItemMapper.Map).ToList(),
            orderRequest.ReferenceId,
            orderRequest.CustomerId,
            orderRequest.IsDelivery);
    }

    public OrderModel Map(Order value, decimal vat)
    {
        var order = value as MrDOrder;

        if (order == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new MrDModel(order.Id,
            order.Items.Select(orderItemModelMapper.Map).ToList(),
            order.OrderDate,
            order.ReferenceId,
            order.CustomerId,
            order.IsDelivery,
            order.CalculateTotal(vat),
            order.CalculateSubTotal());
    }
}