using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZCommerce.Order.Application.Features.CQRS.Commands.AddressCommands.CreateAddressCommands;

namespace ZCommerce.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
