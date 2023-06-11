using Shared.Enums;

namespace Core.Entities;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public ProductType ProductType { get; set; }
}