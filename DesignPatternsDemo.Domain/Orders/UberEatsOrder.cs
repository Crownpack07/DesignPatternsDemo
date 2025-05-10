namespace DesignPatternsDemo.Domain.Orders;

public class UberEatsOrder : Order
{
    public int ReferenceId { get; set; }
    public int CustomerId { get; set; }
    public bool IsDelivery { get; set; }

    public UberEatsOrder(Guid id, 
        List<OrderItem> items,
        DateTime orderDate,
        int referenceId,
        int customerId,
        bool isDelivery) : base(id, orderDate, items)
    {
        ReferenceId = referenceId;
        CustomerId = customerId;
        IsDelivery = isDelivery;
    }
}