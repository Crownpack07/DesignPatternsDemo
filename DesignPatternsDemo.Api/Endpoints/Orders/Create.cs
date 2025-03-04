using DesignPatternsDemo.Api.Endpoints.Orders.Models;
using FastEndpoints;

namespace DesignPatternsDemo.Api.Endpoints.Orders;

public class Create : Endpoint<CreateOrderRequest, CreateOrderResponse>
{
    public override void Configure()
    {
        Post("/order");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CreateOrderRequest request, CancellationToken ct)
    {
        await SendAsync(new CreateOrderResponse($"Order Created for items: {string.Join(',', request.Items)}", Guid.NewGuid()), cancellation: ct);
    }
}