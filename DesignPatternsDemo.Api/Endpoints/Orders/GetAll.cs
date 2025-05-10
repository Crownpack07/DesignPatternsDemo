using DesignPatternsDemo.Api.Endpoints.Orders.Models;
using DesignPatternsDemo.Domain.Orders;
using DesignPatternsDemo.Domain.Vat;
using DesignPatternsDemo.Kernel.Exceptions;
using FastEndpoints;

namespace DesignPatternsDemo.Api.Endpoints.Orders;

public class GetAll : EndpointWithoutRequest<List<OrderModel>>
{
    private readonly IOrderFactoryResolver factoryResolver;
    private readonly IOrderRepository orderRepository;
    private readonly IVatRepository vatRepository;

    public GetAll(IOrderFactoryResolver factoryResolver,
        IOrderRepository orderRepository, IVatRepository vatRepository)
    {
        this.factoryResolver = factoryResolver;
        this.orderRepository = orderRepository;
        this.vatRepository = vatRepository;
    }

    public override void Configure()
    {
        Get("/order");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var orders = await orderRepository.GetAllAsync(ct);

        if (orders.Count == 0)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        var vat = await vatRepository.GetVatAsync(ct);

        if (vat == null)
        {
            throw new NotFoundException(nameof(vat));
        }

        var orderModel = orders
            .Select(o => factoryResolver
                .Resolve(o)
                .Map(o, vat.Value))
            .ToList();

        await SendAsync(orderModel, cancellation: ct);
    }
}