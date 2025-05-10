namespace DesignPatternsDemo.Infrastructure;

public class Settings
{
    public string DatabaseName { get; init; } = null!;
    public string OrdersCollectionName { get; init; } = null!;
    public string VatCollectionName { get; init; } = null!;
}