using DesignPatternsDemo.Domain.Orders;

namespace DesignPatternsDemo.Api.Endpoints.Orders.Models;

public class OrderFactoryResolver : IOrderFactoryResolver
{
    private readonly IEnumerable<IOrderFactory> orderFactories;

    public OrderFactoryResolver(IEnumerable<IOrderFactory> orderFactories)
    {
        this.orderFactories = orderFactories;
    }

    public IOrderFactory Resolve(CreateOrderRequest request) => orderFactories
        .Single(o => o.IsApplicable(request));

    public IOrderFactory Resolve(Order value) => orderFactories
        .Single(o => o.IsApplicable(value));
}