using DesignPatternsDemo.Api.Endpoints.Vat.Models;
using DesignPatternsDemo.Domain.Vat;
using FastEndpoints;

namespace DesignPatternsDemo.Api.Endpoints.Vat;

public class Create : Endpoint<CreateVatRequest, CreateVatResponse>
{
    private readonly IVatRepository vatRepository;

    public Create(IVatRepository vatRepository)
    {
        this.vatRepository = vatRepository;
    }
    public override void Configure()
    {
        Post("/vat");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CreateVatRequest request, CancellationToken ct)
    {
        var vat = new Domain.Vat.Vat(Guid.NewGuid(), request.Value, request.EffectiveFrom);
            
        await vatRepository.AddVatAsync(vat, ct);
        
        await SendAsync(new CreateVatResponse(vat.Id), cancellation: ct);
    }
}