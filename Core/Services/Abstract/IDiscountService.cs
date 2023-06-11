using Core.Dtos;
using Core.Entities;
using Core.Repositories.Ef.Abstract;

namespace Core.Services.Abstract;

public interface IDiscountService : IRepository<Discount>
{
    public Task<decimal> CalculateDiscountedAmount(CreateInvoiceDto invoice);
    public Task<decimal> CalculateDiscountedAmount(UpdateInvoiceDto invoice);
}