using DesignPatternsDemo.Domain.Vat;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DesignPatternsDemo.Infrastructure.Vat;

public class VatMongoRepository : IVatRepository
{
    private readonly IMongoCollection<Domain.Vat.Vat> collection;

    public VatMongoRepository(
        IOptions<Settings> settings,
        IMongoClient mongoClient)
    {
        collection = mongoClient
            .GetDatabase(settings.Value.DatabaseName)
            .GetCollection<Domain.Vat.Vat>(settings.Value.VatCollectionName);
    }

    public async Task<Domain.Vat.Vat?> GetVatAsync(CancellationToken cancellationToken) =>
        await collection
            .Find(filter => filter.EffectiveFrom < DateTime.UtcNow)
            .FirstOrDefaultAsync(cancellationToken);

    public Task AddVatAsync(Domain.Vat.Vat vat, CancellationToken cancellationToken) => collection
            .InsertOneAsync(vat, cancellationToken: cancellationToken);
}