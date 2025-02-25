using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCommerce.Order.Application.Features.CQRS.Results.AddressResults
{
    public class GetAdressByIdQueryResult
    {
        public Guid AddressId { get; set; }
        public Guid OrderId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
    }
}
