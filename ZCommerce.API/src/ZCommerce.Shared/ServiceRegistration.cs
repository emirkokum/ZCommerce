using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Shared.Abstractions;
using ZCommerce.Shared.Base;

namespace ZCommerce.Shared
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
