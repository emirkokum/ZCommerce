using ZCommerce.Infrastructure.Services;
using ZCommerce.Order.Application.Interfaces;
using ZCommerce.Order.Domain.Entities;
using ZCommerce.Shared.Abstractions;
using ZCommerce.Shared.CQRS;

namespace ZCommerce.Order.Application.Features.CQRS.Commands.OrderCommands.CreateOrderCommands
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderWriteRepository)
        {
            _orderRepository = orderWriteRepository;
        }

        public async Task<IResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderEntity = new Domain.Entities.Order
            {
                CustomerId = command.CustomerId,
                TotalPrice = command.TotalPrice,
                Status = command.Status,
                OrderItems = command.OrderItems,
                Address = command.Address
            };

            await _orderRepository.AddAsync(orderEntity);

            return new SuccessResult("Order created successfully");
        }
    }
}
