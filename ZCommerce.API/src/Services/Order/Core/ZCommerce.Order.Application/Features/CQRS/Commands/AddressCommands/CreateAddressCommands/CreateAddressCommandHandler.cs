using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCommerce.Order.Application.Features.CQRS.Commands.OrderCommands.CreateOrderCommands;
using ZCommerce.Order.Application.Interfaces;
using ZCommerce.Shared.CQRS;

namespace ZCommerce.Order.Application.Features.CQRS.Commands.AddressCommands.CreateAddressCommands
{
    public class CreateAddressCommandHandler : ICommandHandler<CreateAddressCommand>
    {
        private readonly IAddressRepository _addressRepository;

        public CreateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IResult> Handle(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            var addressEntity = new Domain.Entities.Address
            {
                OrderId = command.OrderId,
                CustomerId = command.CustomerId,
                District = command.District,
                City = command.City,
                AddressDetail = command.AddressDetail
            };

            await _addressRepository.AddAsync(addressEntity);
            await _addressRepository.SaveChangesAsync(cancellationToken);

            return new SuccessResult("Address created successfully");
        }
    }
}
