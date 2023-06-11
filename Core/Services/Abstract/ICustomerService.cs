using Core.Entities;
using Core.Repositories.Ef.Abstract;

namespace Core.Services.Abstract;

public interface ICustomerService : IRepository<Customer>
{

}