using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Shared.Base;

namespace ZCommerce.Infrastructure.Services
{
    public class OrderUnitOfWork : BaseUnitOfWork
    {
        public OrderUnitOfWork(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
