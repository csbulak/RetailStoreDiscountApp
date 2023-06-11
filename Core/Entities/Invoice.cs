namespace Core.Entities;

public class Invoice
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public decimal DiscountedAmount { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<Discount> Discounts { get; set; }
    public ICollection<Item> Items { get; set; }
}