namespace DesignPatternsDemo.Domain.Vat;

public class Vat(Guid id, decimal value, DateTime effectiveFrom)
{
    public Guid Id { get; set; } = id;
    public decimal Value { get; set; } = value;
    public DateTime EffectiveFrom { get; set; } = effectiveFrom;
}