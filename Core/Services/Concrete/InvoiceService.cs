using AutoMapper;
using Core.Contexts.Ef;
using Core.Dtos;
using Core.Entities;
using Core.Repositories.Ef.Concrete;
using Core.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;
using Shared.Enums;
using System.Net;

namespace Core.Services.Concrete;

public class InvoiceService : Repository<Invoice>, IInvoiceService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDiscountService _discountService;

    public InvoiceService(AppDbContext dbContext, AppDbContext context, IMapper mapper, IDiscountService discountService) : base(dbContext)
    {
        _context = context;
        _mapper = mapper;
        _discountService = discountService;
    }


    public async Task<Response<InvoiceDto>> GetInvoiceById(Guid invoiceId)
    {
        var invoice = await _context.Invoices.Include(i => i.Customer).Include(i => i.Items).Include(i => i.Discounts)
            .Select(x => _mapper.Map<InvoiceDto>(x)).FirstOrDefaultAsync(x => x.Id.Equals(invoiceId));
        return invoice != null ? Response<InvoiceDto>.Success(invoice) : Response<InvoiceDto>.Fail(ErrorCodes.NotFound, HttpStatusCode.NotFound);
    }

    public async Task<Response<PaginatedList<InvoiceDto>>> GetInvoices(int pageIndex, int pageSize)
    {
        var invoices = _context.Invoices.Include(i => i.Customer).Include(i => i.Items).Include(i => i.Discounts)
            .Select(x => _mapper.Map<InvoiceDto>(x));

        var result = await PaginatedList<InvoiceDto>.CreateAsync(invoices, pageIndex, pageSize);
        return result.Items.Any() ? Response<PaginatedList<InvoiceDto>>.Success(result) : Response<PaginatedList<InvoiceDto>>.Fail(ErrorCodes.NotFound, HttpStatusCode.NotFound);
    }

    public async Task<Response<InvoiceDto>> CreateInvoice(CreateInvoiceDto createInvoiceDto)
    {
        // Calculate the discounted amount
        createInvoiceDto.Amount = await _discountService.CalculateDiscountedAmount(createInvoiceDto);
        var invoice = _mapper.Map<Invoice>(createInvoiceDto);
        var addResult = await base.AddAsync(invoice);
        var result = _mapper.Map<InvoiceDto>(addResult.Data);
        return Response<InvoiceDto>.Success(result);
    }

    public async Task<Response<InvoiceDto>> UpdateInvoice(UpdateInvoiceDto updateInvoiceDto)
    {
        // Calculate the discounted amount
        updateInvoiceDto.Amount = await _discountService.CalculateDiscountedAmount(updateInvoiceDto);
        var invoice = _mapper.Map<Invoice>(updateInvoiceDto);
        var updateAsync = await base.UpdateAsync(invoice);
        var result = _mapper.Map<InvoiceDto>(updateAsync.Data);
        return Response<InvoiceDto>.Success(result);
    }

    public async Task<Response<bool>> DeleteInvoice(Guid invoiceId)
    {
        try
        {
            var invoice = await _context.Invoices.Include(x => x.Items).Include(x => x.Discounts).FirstOrDefaultAsync(i => i.Id == invoiceId);
            if (invoice == null)
            {
                return Response<bool>.Fail(ErrorCodes.NotFound, HttpStatusCode.BadRequest);
            }
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return Response<bool>.Success(true);
        }
        catch (Exception e)
        {
            return Response<bool>.Fail(new List<ErrorDto>() { new ErrorDto(ErrorCodes.InternalServerError) { ErrorMessage = e.Message } }, HttpStatusCode.InternalServerError);
        }
    }
}