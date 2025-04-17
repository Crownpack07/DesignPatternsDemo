namespace DesignPatternsDemo.Domain.Orders;

public class MrDOrder : Order
{
    public int ReferenceId { get; set; }
    public int CustomerId { get; set; }
    public bool IsDelivery { get; set; }

    public MrDOrder(Guid id,
        DateTime orderDate,
        List<OrderItem> items,
        int referenceId,
        int customerId,
        bool isDelivery) : base(id, orderDate, items)
    {
        ReferenceId = referenceId;
        CustomerId = customerId;
        IsDelivery = isDelivery;
    }
}