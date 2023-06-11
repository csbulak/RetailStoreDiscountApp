namespace Core.Dtos;

public class UpdateInvoiceDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public decimal DiscountedAmount { get; set; }
    public Guid CustomerId { get; set; }
    public ICollection<UpdateDiscountDto> Discounts { get; set; }
    public ICollection<UpdateItemDto> Items { get; set; }
}