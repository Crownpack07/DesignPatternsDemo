using DesignPatternsDemo.Domain.Orders;
using DesignPatternsDemo.Kernel;

namespace DesignPatternsDemo.Api.Endpoints.Orders.Models.UberEats;

public class UberEatsOrderFactory : IOrderFactory
{
    private readonly ICustomMapper<OrderItemModel, OrderItem> orderItemMapper;
    private readonly ICustomMapper<OrderItem, OrderItemModel> orderItemModelMapper;

    public UberEatsOrderFactory(ICustomMapper<OrderItemModel, OrderItem> orderItemMapper,
        ICustomMapper<OrderItem, OrderItemModel> orderItemModelMapper)
    {
        this.orderItemMapper = orderItemMapper;
        this.orderItemModelMapper = orderItemModelMapper;
    }

    public bool IsApplicable(CreateOrderRequest request) => request is UberEatsOrderRequest;

    public bool IsApplicable(Order value) => value is UberEatsOrder;

    public Order Create(CreateOrderRequest request)
    {
        var orderRequest = request as UberEatsOrderRequest;

        if (orderRequest == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return new UberEatsOrder(Guid.NewGuid(),
            orderRequest.Items.Select(orderItemMapper.Map).ToList(),
            orderRequest.OrderDate,
            orderRequest.ReferenceId,
            orderRequest.CustomerId,
            orderRequest.IsDelivery);
    }

    public OrderModel Map(Order value, decimal vat)
    {
        var order = value as UberEatsOrder;

        if (order == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new UberEatsModel(order.Id,
            order.Items.Select(orderItemModelMapper.Map).ToList(),
            order.OrderDate,
            order.ReferenceId,
            order.CustomerId,
            order.IsDelivery,
            order.CalculateTotal(vat),
            order.CalculateSubTotal());
    }
}