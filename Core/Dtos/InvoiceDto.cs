namespace Core.Dtos;

public class InvoiceDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public decimal DiscountedAmount { get; set; }
    public CustomerDto Customer { get; set; }
    public ICollection<DiscountDto> Discounts { get; set; }
    public ICollection<ItemDto> Items { get; set; }
}