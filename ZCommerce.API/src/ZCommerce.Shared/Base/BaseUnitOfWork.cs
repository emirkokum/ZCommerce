using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Shared.Abstractions;

namespace ZCommerce.Shared.Base
{
    public class BaseUnitOfWork 
    {
        private readonly DbContext _dbContext;

        public BaseUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int SaveChanges()
             => _dbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();
    }
}

