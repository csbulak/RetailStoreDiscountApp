using Core.Contexts.Ef;
using Core.Entities;
using Core.Repositories.Ef.Concrete;
using Core.Services.Abstract;

namespace Core.Services.Concrete;

public class CustomerService : Repository<Customer>, ICustomerService
{
    public CustomerService(AppDbContext dbContext) : base(dbContext)
    {
    }
}