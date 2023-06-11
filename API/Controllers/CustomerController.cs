using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseController;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CustomBaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            return CreateActionResultInstance(await _customerService.AddAsync(_mapper.Map<Customer>(createCustomerDto)));
        }
    }
}
