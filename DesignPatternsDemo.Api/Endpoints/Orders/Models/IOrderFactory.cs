
using DesignPatternsDemo.Domain.Orders;

namespace DesignPatternsDemo.Api.Endpoints.Orders.Models;

public interface IOrderFactory
{
    public bool IsApplicable(CreateOrderRequest request);

    public bool IsApplicable(Order value);

    public Order Create(CreateOrderRequest request);
    
    public OrderModel Map(Order value, decimal vat);
}