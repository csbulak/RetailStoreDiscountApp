using Shared.Enums;

namespace Core.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public UserType UserType { get; set; }
    public DateTime JoinDate { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
}