using DesignPatternsDemo.Domain.Vat;

namespace DesignPatternsDemo.Infrastructure.Vat;

public class VatLocalRepository : IVatRepository
{
    private readonly List<Domain.Vat.Vat> vats =
    [
        new(Guid.NewGuid(), 0.015m, new DateTime(2018, 4, 18))
    ];

    public Task<Domain.Vat.Vat?> GetVatAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(vats
            .OrderByDescending(v => v.EffectiveFrom)
            .FirstOrDefault(v => v.EffectiveFrom > DateTime.UtcNow));
    }

    public Task AddVatAsync(Domain.Vat.Vat vat, CancellationToken cancellationToken)
    {
        vats.Add(vat);
        return Task.FromResult(vat);
    }
}