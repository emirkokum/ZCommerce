using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Shared.Base;

namespace ZCommerce.Order.Domain.Entities
{
    public class Address : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
    }
}
