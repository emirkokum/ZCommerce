using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZCommerce.Order.Application.Features.CQRS.Commands.AddressCommands.CreateAddressCommands;
using ZCommerce.Order.Application.Features.CQRS.Commands.OrderCommands.CreateOrderCommands;
using ZCommerce.Order.Application.Interfaces;
using ZCommerce.Shared.CQRS;

namespace ZCommerce.Order.Application
{
    public static class ServiceRegistration
    {
        public static void AddAplicationServices(this IServiceCollection services,IConfiguration confugiration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
            services.AddScoped<ICommandHandler<CreateOrderCommand>, CreateOrderCommandHandler>();
            services.AddScoped<ICommandHandler<CreateAddressCommand>, CreateAddressCommandHandler>();
        }
    }
}
