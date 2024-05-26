using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSRequests.Application.Commands;
using MSRequests.Application.Commands.AuthCommands;
using MSRequests.Application.Commands.RequestServiceCommands;
using MSRequests.Application.Queries;
using MSRequests.Application.Queries.AuthQueries;

namespace MSRequests.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController(IMediator mediator) : ControllerBase
    {
        [HttpPost("DeleteServiceRequest")]
        public async Task<IActionResult> DeleteServiceRequest([FromBody] DeleteServiceRequestCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPost("SaveServiceRequest")]
        public async Task<IActionResult> SaveServiceRequest([FromBody] SaveServiceRequestCommand command)
        {
            var Result = await mediator.Send(command);
            return Ok(Result);
        }
        [HttpGet("GetAllServiceRequests")]
        public async Task<IActionResult> GetAllServiceRequests([FromBody] GetAllServiceRequestsQuery Query)
        {
            var Result = await mediator.Send(Query);
            return Ok(Result);
        }
        [HttpGet("GetAllServiceRequestsById")]
        public async Task<IActionResult> GetAllServiceRequestsById([FromBody] GetAllServiceRequestsByIdQuery Query)
        {
            var Result = await mediator.Send(Query);
            return Ok(Result);
        }
    }
}
