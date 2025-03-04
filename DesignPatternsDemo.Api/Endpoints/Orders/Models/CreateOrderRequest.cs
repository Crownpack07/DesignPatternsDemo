namespace DesignPatternsDemo.Api.Endpoints.Orders.Models;

public record CreateOrderRequest(List<OrderItem> Items);

public record OrderItem(string Name);