namespace DesignPatternsDemo.Domain.Orders;

public class InStoreOrder : Order
{
    public int InvoiceNumber { get; set; }

    public InStoreOrder(Guid id,
        List<OrderItem> items,
        int invoiceNumber,
        DateTime orderDate) : base(id, orderDate, items)
    {
        Id = id;
        Items = items;
        InvoiceNumber = invoiceNumber;
        OrderDate = orderDate;
    }
}