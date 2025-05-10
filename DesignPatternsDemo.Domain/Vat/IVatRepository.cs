namespace DesignPatternsDemo.Domain.Vat;

public interface IVatRepository
{
    public Task<Vat?> GetVatAsync(CancellationToken cancellationToken);
    
    public Task AddVatAsync(Vat vat, CancellationToken cancellationToken);
}