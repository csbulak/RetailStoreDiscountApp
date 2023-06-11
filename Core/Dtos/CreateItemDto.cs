using Shared.Enums;

namespace Core.Dtos;

public class CreateItemDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductType ProductType { get; set; }
}