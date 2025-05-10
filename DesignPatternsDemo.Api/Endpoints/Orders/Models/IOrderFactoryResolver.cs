using DesignPatternsDemo.Domain.Orders;

namespace DesignPatternsDemo.Api.Endpoints.Orders.Models;

public interface IOrderFactoryResolver
{
    public IOrderFactory Resolve(CreateOrderRequest request);
    public IOrderFactory Resolve(Order value);
}