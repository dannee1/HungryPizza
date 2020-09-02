using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HungryPizza.Domain.Commands.Order;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Models.Inputs;

namespace HungryPizza.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public OrderController(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("unauthenticated")]
        public async Task<IActionResult> OrderWithoutLogin([FromBody] UnauthenticatedOrderInput order)
        {
            var result = await _mediator.Send(new NewOrderCommand(order.Pizzas, null, order.Address));
            if (result.Ok)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] OrderInput order)
        {
            var login = User.Identity.Name;
            var user = await _userRepository.Get(login);
            var result = await _mediator.Send(new NewOrderCommand(order.Pizzas, user.Id, null));
            if (result.Ok)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }
    }
}
