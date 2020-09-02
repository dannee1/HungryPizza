using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HungryPizza.Domain;
using HungryPizza.Domain.Commands.Order;
using HungryPizza.Domain.Commands.User;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Models;
using HungryPizza.Domain.Models.Inputs;

namespace HungryPizza.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        public UserController(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }


        [ProducesResponseType(typeof(OderUserModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpGet("order")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var login = User.Identity.Name;
                var user = await _userRepository.Get(login);
                if (user == null)
                    return BadRequest(GenericCommandResult.Failure(new List<string> { ErrorMessages.UserNotExists }));

                var result = await _mediator.Send(new GetOrderFromUserCommand(user.Id));
                if (result.Ok)
                    return Ok(result.Data);
                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                //logar erro em algum lugar
                return StatusCode(500, ex.Message);
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(500)]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] UserInput input)
        {
            try
            {
                var result = await _mediator.Send(
                new NewUserCommand(
                    input.Name,
                    input.Login,
                    input.Password,
                    input.ConfirmPassword,
                    input.Addresses,
                    input.DDD,
                    input.Phone)
                );
                if (result.Ok)
                    return Ok();
                return BadRequest(result.Errors);
            }
            catch(Exception ex)
            {
                //logar erro em algum lugar
                return StatusCode(500, ex.Message);
            }
        }
    }
}
