namespace Core.Dtos;

public class CreateInvoiceDto
{
    public decimal Amount { get; set; }
    public decimal DiscountedAmount { get; set; }
    public Guid CustomerId { get; set; }
    public ICollection<CreateDiscountDto> Discounts { get; set; }
    public ICollection<CreateItemDto> Items { get; set; }
}