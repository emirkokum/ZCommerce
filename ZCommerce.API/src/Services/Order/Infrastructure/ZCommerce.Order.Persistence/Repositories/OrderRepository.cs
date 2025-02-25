using Microsoft.EntityFrameworkCore;
using ZCommerce.Order.Application.Interfaces;
using ZCommerce.Order.Persistence.Context;
using ZCommerce.Shared.Abstractions;
using ZCommerce.Shared.Base;

namespace ZCommerce.Order.Persistence.Repositories
{

    public class OrderRepository : BaseRepository<Domain.Entities.Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {
        }

    }
}
