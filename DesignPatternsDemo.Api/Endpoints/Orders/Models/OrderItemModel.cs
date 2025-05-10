namespace DesignPatternsDemo.Api.Endpoints.Orders.Models;

public record OrderItemModel(Guid ProductId, string ProductName, string Description, decimal UnitPrice);