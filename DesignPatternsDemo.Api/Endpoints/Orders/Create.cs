using DesignPatternsDemo.Api.Endpoints.Orders.Models;
using DesignPatternsDemo.Domain.Orders;
using FastEndpoints;

namespace DesignPatternsDemo.Api.Endpoints.Orders;

public class Create : Endpoint<CreateOrderRequest, CreateOrderResponse>
{
    private readonly IOrderFactoryResolver factoryResolver;
    private readonly IOrderRepository orderRepository;

    public Create(IOrderFactoryResolver factoryResolver, 
        IOrderRepository orderRepository)
    {
        this.factoryResolver = factoryResolver;
        this.orderRepository = orderRepository;
    }
    
    public override void Configure()
    {
        Post("/order");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CreateOrderRequest request, CancellationToken ct)
    {
        var order = factoryResolver 
            .Resolve(request)
            .Create(request);
            
        await orderRepository.AddOrderAsync(order, ct);
        
        await SendAsync(new CreateOrderResponse(order.Id), cancellation: ct);
    }
}