using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Order.Application.Interfaces;
using ZCommerce.Order.Persistence.Context;
using ZCommerce.Shared.Base;

namespace ZCommerce.Order.Persistence.Repositories
{
    public class AddressRepository : BaseRepository<Domain.Entities.Address>, IAddressRepository
    {
        public AddressRepository(OrderContext context) : base(context)
        {
        }

    }
}
