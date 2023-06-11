namespace Core.Entities;

public class Discount
{
    public Guid Id { get; set; }
    public decimal Percentage { get; set; }
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}