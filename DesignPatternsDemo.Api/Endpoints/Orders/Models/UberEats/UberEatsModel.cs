namespace DesignPatternsDemo.Api.Endpoints.Orders.Models.UberEats;

public record UberEatsModel(Guid OrderId,
    List<OrderItemModel> Items,
    DateTime OrderDate, 
    int ReferenceId,
    int CustomerId,
    bool IsDelivery,
    decimal Total,
    decimal SubTotal): OrderModel(OrderId, Items, OrderDate, Total, SubTotal);