namespace DesignPatternsDemo.Domain.Orders;

public record OrderItem(Guid ProductId, string ProductName, string Description, decimal UnitPrice);