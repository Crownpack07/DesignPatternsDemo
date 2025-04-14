namespace DesignPatternsDemo.Api.Endpoints.Orders.Models.InStoreModel;

public record InStoreOrderRequest(
    List<OrderItemModel> Items,
    DateTime OrderDate,
    int InvoiceNumber)
    : CreateOrderRequest(Items, OrderDate);