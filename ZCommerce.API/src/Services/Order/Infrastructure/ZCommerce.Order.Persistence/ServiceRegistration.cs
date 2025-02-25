using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Order.Application.Interfaces;
using ZCommerce.Order.Persistence.Context;
using ZCommerce.Order.Persistence.Repositories;
using ZCommerce.Shared.Abstractions;
using ZCommerce.Shared.Base;

namespace ZCommerce.Order.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // OrderContext'i DI konteynırına ekleme ve bağlantı dizesiyle konfigüre etme
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderDatabase")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;
        }
    }

}
