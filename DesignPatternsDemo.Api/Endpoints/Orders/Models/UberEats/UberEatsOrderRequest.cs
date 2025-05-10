namespace DesignPatternsDemo.Api.Endpoints.Orders.Models.UberEats;

public record UberEatsOrderRequest(
    List<OrderItemModel> Items,
    DateTime OrderDate,
    int ReferenceId,
    int CustomerId,
    bool IsDelivery) : CreateOrderRequest(Items, OrderDate);