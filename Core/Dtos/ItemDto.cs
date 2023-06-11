using Shared.Enums;

namespace Core.Dtos;

public class ItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductType ProductType { get; set; }
}