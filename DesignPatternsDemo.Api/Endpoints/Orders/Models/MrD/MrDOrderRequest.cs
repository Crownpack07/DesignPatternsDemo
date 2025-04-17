namespace DesignPatternsDemo.Api.Endpoints.Orders.Models.MrD;

public record MrDOrderRequest(
    List<OrderItemModel> Items,
    DateTime OrderDate,
    int ReferenceId,
    int CustomerId,
    bool IsDelivery) : CreateOrderRequest(Items, OrderDate);