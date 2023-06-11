using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Core.Mapping;

public class CoreMapping : Profile
{
    public CoreMapping()
    {
        CreateMap<CreateCustomerDto, Customer>().ReverseMap();
        CreateMap<CreateDiscountDto, Discount>().ReverseMap();
        CreateMap<CreateInvoiceDto, Invoice>().ReverseMap();
        CreateMap<CreateItemDto, Item>().ReverseMap();
        CreateMap<CustomerDto, Customer>().ReverseMap();
        CreateMap<DiscountDto, Discount>().ReverseMap();
        CreateMap<InvoiceDto, Invoice>().ReverseMap();
        CreateMap<ItemDto, Item>().ReverseMap();

        CreateMap<UpdateCustomerDto, Customer>().ReverseMap();
        CreateMap<UpdateDiscountDto, Discount>().ReverseMap();
        CreateMap<UpdateInvoiceDto, Invoice>().ReverseMap();
        CreateMap<UpdateItemDto, Item>().ReverseMap();
    }
}