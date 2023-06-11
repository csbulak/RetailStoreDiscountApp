using Core.Contexts.Ef;
using Core.Dtos;
using Core.Entities;
using Core.Repositories.Ef.Concrete;
using Core.Services.Abstract;
using Shared.Enums;

namespace Core.Services.Concrete;

public class DiscountService : Repository<Discount>, IDiscountService
{
    private readonly ICustomerService _customerService;

    public DiscountService(AppDbContext dbContext, ICustomerService customerService) : base(dbContext)
    {
        _customerService = customerService;
    }

    // Helper method to calculate discounted amount
    public async Task<decimal> CalculateDiscountedAmount(CreateInvoiceDto invoice)
    {
        var customer = await _customerService.GetByIdAsync(invoice.CustomerId);

        var discountedAmount = invoice.Amount;

        // Rule 1: If the user is an employee of the store, he gets a 30% discount
        var employeeDiscount = customer.Data is { UserType: UserType.Employee } ? (discountedAmount * 0.3m) : 0;

        // Rule 2: If the user is an affiliate of the store, he gets a 10% discount
        var affiliateDiscount = customer.Data is { UserType: UserType.Affiliate } ? (discountedAmount * 0.1m) : 0;

        // Rule 3: If the user has been a customer for over 2 years, he gets a 5% discount
        var customerDiscount = customer.Data != null && (DateTime.Now - customer.Data.JoinDate).TotalDays > 365 * 2 ? (discountedAmount * 0.05m) : 0;

        // Rule 4: For every $100 on the bill, there would be a $5 discount
        var billDiscount = Math.Floor(discountedAmount / 100) * 5;

        // Rule 5: The percentage based discounts do not apply on groceries
        var hasGroceries = invoice.Items.Any(item => item.ProductType == ProductType.Grocery);
        var groceryDiscount = hasGroceries ? invoice.Amount : 0;

        discountedAmount -= (employeeDiscount + affiliateDiscount + customerDiscount + billDiscount + groceryDiscount);

        return discountedAmount;
    }

    public async Task<decimal> CalculateDiscountedAmount(UpdateInvoiceDto invoice)
    {
        var customer = await _customerService.GetByIdAsync(invoice.CustomerId);

        var discountedAmount = invoice.Amount;

        // Rule 1: If the user is an employee of the store, he gets a 30% discount
        var employeeDiscount = customer.Data is { UserType: UserType.Employee } ? (discountedAmount * 0.3m) : 0;

        // Rule 2: If the user is an affiliate of the store, he gets a 10% discount
        var affiliateDiscount = customer.Data is { UserType: UserType.Affiliate } ? (discountedAmount * 0.1m) : 0;

        // Rule 3: If the user has been a customer for over 2 years, he gets a 5% discount
        var customerDiscount = customer.Data != null && (DateTime.Now - customer.Data.JoinDate).TotalDays > 365 * 2 ? (discountedAmount * 0.05m) : 0;

        // Rule 4: For every $100 on the bill, there would be a $5 discount
        var billDiscount = Math.Floor(discountedAmount / 100) * 5;

        // Rule 5: The percentage based discounts do not apply on groceries
        var hasGroceries = invoice.Items.Any(item => item.ProductType == ProductType.Grocery);
        var groceryDiscount = hasGroceries ? invoice.Amount : 0;

        discountedAmount -= (employeeDiscount + affiliateDiscount + customerDiscount + billDiscount + groceryDiscount);

        return discountedAmount;
    }
}