using Microsoft.EntityFrameworkCore;

namespace ZCommerce.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Address> Addresses { get; set; }
        public DbSet<Domain.Entities.Order> Orders { get; set; }
        public DbSet<Domain.Entities.OrderItem> OrderItems { get; set; }

    }
}
