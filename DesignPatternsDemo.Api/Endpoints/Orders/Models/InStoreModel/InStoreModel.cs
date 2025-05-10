namespace DesignPatternsDemo.Api.Endpoints.Orders.Models.InStoreModel;

public record InStoreModel(
    Guid OrderId,
    List<OrderItemModel> Items,
    DateTime OrderDate,
    int InvoiceNumber, 
    decimal Total,
    decimal SubTotal)
    : OrderModel(OrderId, Items, OrderDate, Total, SubTotal);