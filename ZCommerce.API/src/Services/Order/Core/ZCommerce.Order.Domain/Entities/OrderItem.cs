using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Shared.Base;

namespace ZCommerce.Order.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; } 
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } 
        public int Quantity { get; set; } 
        public decimal TotalPrice => UnitPrice * Quantity;
        public Order Order { get; set; } 
    }

}
