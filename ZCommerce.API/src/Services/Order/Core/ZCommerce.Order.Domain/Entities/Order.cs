using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Shared.Base;

namespace ZCommerce.Order.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } 
        public string Status { get; set; }
        public List<OrderItem> OrderItems { get; set; } 
        public Address Address { get; set; }

    }

    public enum OrderStatus
    {
        Created,
        Processing,
        Paid,
        Shipped,
        Delivered,
        Cancelled
    }

}
