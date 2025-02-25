using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Shared.Abstractions;

namespace ZCommerce.Order.Application.Interfaces
{
    public interface IAddressRepository : IRepository<Domain.Entities.Address>
    {
    }
}
