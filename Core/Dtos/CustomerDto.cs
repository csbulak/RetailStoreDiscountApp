using Shared.Enums;

namespace Core.Dtos;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public UserType UserType { get; set; }
    public DateTime JoinDate { get; set; }
}