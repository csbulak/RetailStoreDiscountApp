using Shared.Enums;

namespace Core.Dtos;

public class CreateCustomerDto
{
    public string Name { get; set; }
    public UserType UserType { get; set; }
    public DateTime JoinDate { get; set; }
}