using DesignPatternsDemo.Api.Endpoints.Orders.Models;
using DesignPatternsDemo.Domain.Orders;
using DesignPatternsDemo.Domain.Vat;
using DesignPatternsDemo.Kernel.Exceptions;
using FastEndpoints;

namespace DesignPatternsDemo.Api.Endpoints.Orders;

public class Get : Endpoint<GetOrderRequest, OrderModel>
{
    private readonly IOrderFactoryResolver factoryResolver;
    private readonly IOrderRepository orderRepository;
    private readonly IVatRepository vatRepository;

    public Get(IOrderFactoryResolver factoryResolver,
        IOrderRepository orderRepository,
        IVatRepository vatRepository)
    {
        this.factoryResolver = factoryResolver;
        this.orderRepository = orderRepository;
        this.vatRepository = vatRepository;
    }

    public override void Configure()
    {
        Get("/order/{orderId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetOrderRequest request, CancellationToken ct)
    {
        var result = await orderRepository.GetByIdAsync(request.OrderId, ct);

        if (result == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var vat = await vatRepository.GetVatAsync(ct);

        if (vat == null)
        {
            throw new NotFoundException(nameof(vat));
        }

        var orderModel = factoryResolver
            .Resolve(result)
            .Map(result, vat.Value);

        await SendAsync(orderModel, cancellation: ct);
    }
}