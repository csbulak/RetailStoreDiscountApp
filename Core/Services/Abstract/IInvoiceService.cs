using Core.Dtos;
using Core.Entities;
using Core.Repositories.Ef.Abstract;
using Shared.Dtos;

namespace Core.Services.Abstract;

public interface IInvoiceService : IRepository<Invoice>
{
    public Task<Response<InvoiceDto>> GetInvoiceById(Guid invoiceId);
    public Task<Response<PaginatedList<InvoiceDto>>> GetInvoices(int pageIndex, int pageSize);
    public Task<Response<InvoiceDto>> CreateInvoice(CreateInvoiceDto createInvoiceDto);
    public Task<Response<InvoiceDto>> UpdateInvoice(UpdateInvoiceDto createInvoiceDto);
    public Task<Response<bool>> DeleteInvoice(Guid invoiceId);
}