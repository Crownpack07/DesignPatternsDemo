namespace DesignPatternsDemo.Domain.Orders;

public abstract class Order
{
    public Guid Id { get; init; }
    public List<OrderItem> Items { get; set; }
    public DateTime OrderDate { get; init; }
    
    protected Order(Guid id, DateTime orderDate, List<OrderItem> items)
    {
        Id = id;
        OrderDate = orderDate;
        Items = items;
    }

    public decimal CalculateSubTotal() => Items.Sum(i => i.UnitPrice);
    
    public decimal CalculateTotal(decimal vat)
    {
        var subTotal= Items.Sum(i => i.UnitPrice);
        
        return subTotal + (subTotal * vat);
    }
}