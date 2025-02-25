using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Shared.CQRS;

namespace ZCommerce.Order.Application.Features.CQRS.Commands.AddressCommands.CreateAddressCommands
{
    public class CreateAddressCommand : ICommand
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
    }
}
