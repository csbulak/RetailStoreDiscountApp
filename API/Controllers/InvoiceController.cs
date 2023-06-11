using Core.Dtos;
using Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseController;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : CustomBaseController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/invoices
        [HttpGet]
        public async Task<IActionResult> GetInvoices(int pageIndex, int pageSize)
        {
            return CreateActionResultInstance(await _invoiceService.GetInvoices(pageIndex, pageSize));
        }

        // GET: api/invoices/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetInvoice(Guid id)
        {
            return CreateActionResultInstance(await _invoiceService.GetInvoiceById(id));
        }

        // POST: api/invoices
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(CreateInvoiceDto invoice)
        {
            return CreateActionResultInstance(await _invoiceService.CreateInvoice(invoice));
        }

        // PUT: api/invoices/{id}
        [HttpPut]
        public async Task<IActionResult> UpdateInvoice(UpdateInvoiceDto invoice)
        {
            return CreateActionResultInstance(await _invoiceService.UpdateInvoice(invoice));
        }

        // DELETE: api/invoices/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            return CreateActionResultInstance(await _invoiceService.DeleteInvoice(id));
        }
    }
}
