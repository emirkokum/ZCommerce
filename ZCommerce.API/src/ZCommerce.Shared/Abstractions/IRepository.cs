using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Shared.Base;

namespace ZCommerce.Shared.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        // Async CRUD Operations
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task RemoveAsync(T entity, CancellationToken cancellationToken = default);

        // Async Query Operations
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        // Advanced Async Operations
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        // Transaction & Save Support
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
