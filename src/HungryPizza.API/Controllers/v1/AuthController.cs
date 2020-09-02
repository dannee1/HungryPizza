using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HungryPizza.Domain.Commands.Autenticacao;

namespace HungryPizza.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromQuery] string login, [FromQuery] string password)
        {
            try
            {
                var result = await _mediator.Send(new AuthCommand(login, password));
                if (result.Ok)
                    return Ok(result.Data);
                return BadRequest(result.Errors);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}
