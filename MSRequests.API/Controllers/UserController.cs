using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSRequests.Application.Commands.AuthCommands;
using MSRequests.Application.Queries.AuthQueries;

namespace MSRequests.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            return Ok(await mediator.Send(query));
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            var Result = await mediator.Send(command);
            return Ok(Result);
        }
    }
}
