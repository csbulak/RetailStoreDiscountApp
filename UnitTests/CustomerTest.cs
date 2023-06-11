using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Services.Abstract;
using Moq;
using Shared.Dtos;
using Shared.Enums;

namespace UnitTests;

public class CustomerTest
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerTest()
    {
        var customerServiceMock = new Mock<ICustomerService>();
        var mapperMock = new Mock<IMapper>();

        // ICustomerService üzerindeki AddAsync metodunun davranışını yapılandırın
        customerServiceMock.Setup(service => service.AddAsync(It.IsAny<Customer>()))
                           .ReturnsAsync(Response<Customer>.Success(new Customer()));

        // IMapper üzerindeki Map metodunun davranışını yapılandırın
        mapperMock.Setup(mapper => mapper.Map<Customer>(It.IsAny<CreateCustomerDto>()))
                  .Returns(new Customer { /* Customer nesnesini yapılandırın */ });

        _customerService = customerServiceMock.Object;
        _mapper = mapperMock.Object;
    }

    [Fact]
    public async Task CreateCustomer_WhenTrueParameter_ShouldReturnTrue()
    {
        var customer = new CreateCustomerDto
        {
            JoinDate = DateTime.Now,
            Name = "Cemal Bulak",
            UserType = UserType.Employee
        };

        var result = await _customerService.AddAsync(_mapper.Map<Customer>(customer));
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public async Task CreateCustomer_WhenNullUserType_ShouldReturnFalse()
    {
        var customer = new CreateCustomerDto
        {
            JoinDate = DateTime.Now,
            Name = "Cemal Bulak"
        };

        var result = await _customerService.AddAsync(_mapper.Map<Customer>(customer));
        Assert.False(result.IsSuccessful);
    }

    [Fact]
    public async Task CreateCustomer_WhenNullParameters_ShouldReturnFalse()
    {
        var result = await _customerService.AddAsync(_mapper.Map<Customer>(new CreateCustomerDto()));
        Assert.False(result.IsSuccessful);
    }
}