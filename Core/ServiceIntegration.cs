using Core.Contexts.Ef;
using Core.Mapping;
using Core.Repositories.Ef.Abstract;
using Core.Repositories.Ef.Concrete;
using Core.Services.Abstract;
using Core.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ServiceIntegration
{
    public static IServiceCollection AddCoreRegister(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AppDbConn") ?? String.Empty;

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(CoreMapping));
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IDiscountService, DiscountService>();
        services.AddScoped<IInvoiceService, InvoiceService>();

        return services;
    }
}