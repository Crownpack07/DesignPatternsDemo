using DesignPatternsDemo.Domain.Orders;
using DesignPatternsDemo.Kernel;

namespace DesignPatternsDemo.Api.Endpoints.Orders.Models.InStoreModel;

public class InStoreOrderFactory : IOrderFactory
{
    private readonly ICustomMapper<OrderItemModel, OrderItem> orderItemMapper;
    private readonly ICustomMapper<OrderItem, OrderItemModel> orderItemModelMapper;

    public InStoreOrderFactory(ICustomMapper<OrderItemModel, OrderItem> orderItemMapper,
        ICustomMapper<OrderItem, OrderItemModel> orderItemModelMapper)
    {
        this.orderItemMapper = orderItemMapper;
        this.orderItemModelMapper = orderItemModelMapper;
    }

    public bool IsApplicable(CreateOrderRequest request)
    {
        return request is InStoreOrderRequest;
    }

    public bool IsApplicable(Order value)
    {
        return value is InStoreOrder;
    }

    public Order Create(CreateOrderRequest request)
    {
        var orderRequest = request as InStoreOrderRequest;

        if (orderRequest == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return new InStoreOrder(Guid.NewGuid(),
            orderRequest.Items.Select(orderItemMapper.Map).ToList(),
            orderRequest.InvoiceNumber,
            orderRequest.OrderDate);
    }

    public OrderModel Map(Order value, decimal vat)
    {
        var order = value as InStoreOrder;

        if (order == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new InStoreModel(order.Id,
            order.Items.Select(orderItemModelMapper.Map).ToList(),
            order.OrderDate,
            order.InvoiceNumber,
            order.CalculateTotal(vat),
            order.CalculateSubTotal());
    }
}