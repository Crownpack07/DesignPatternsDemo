namespace DesignPatternsDemo.Api.Endpoints.Orders.Models;

public record OrderModel(Guid OrderId, List<OrderItemModel> Items, DateTime OrderDate, decimal Total, decimal SubTotal)
{
    public List<OrderItemModel> Items { get; set; } = Items;
}