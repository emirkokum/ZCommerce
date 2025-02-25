using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Order.Domain.Entities;
using ZCommerce.Shared.CQRS;

namespace ZCommerce.Order.Application.Features.CQRS.Commands.OrderCommands.CreateOrderCommands
{
    public class CreateOrderCommand : ICommand
    {
        public Guid CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Domain.Entities.Address Address { get; set; }
    }
}
