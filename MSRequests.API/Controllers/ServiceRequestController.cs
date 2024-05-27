using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSRequests.Application.Commands;
using MSRequests.Application.Commands.AuthCommands;
using MSRequests.Application.Commands.RequestServiceCommands;
using MSRequests.Application.Queries;
using MSRequests.Application.Queries.AuthQueries;
using MSRequests.Domain.Models;

namespace MSRequests.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class ServiceRequestController(IMediator mediator) : ControllerBase
    {
        [HttpPost("DeleteServiceRequest")]
        public async Task<IActionResult> DeleteServiceRequest([FromBody] DeleteServiceRequestCommand command)
        {
            return Ok(await mediator.Send(command));
        }
      
        [HttpPost("SaveAndUpdateServiceRequest")]
        public async Task<IActionResult> SaveServiceRequest([FromBody] SaveServiceRequestCommand command)
        {
            var Result = await mediator.Send(command);
            return Ok(Result);
        }
        [HttpGet("GetAllServiceRequests")]
        public async Task<IActionResult> GetAllServiceRequests()
        {
            GetAllServiceRequestsQuery query = new GetAllServiceRequestsQuery();
            var Result = await mediator.Send(query);
            return Ok(Result);
        }
        [HttpGet("ViewServiceRequestStatus")]
        public async Task<IActionResult> GetAllServiceRequestsById(Guid Id)
        {
            GetAllServiceRequestsByIdQuery query = new GetAllServiceRequestsByIdQuery
            {
                ServiceRequestId = Id,
            };
            var Result = await mediator.Send(query);
            return Ok(Result);
        }
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files, Guid ServiceRequestId)
        {
            List<ServiceRequestAttahcments> serviceRequestAttahcments = new List<ServiceRequestAttahcments>();

            foreach (var file in files)
            {
                ServiceRequestAttahcments requestAttahcments = new ServiceRequestAttahcments();

                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    var fileContents = stream.ToArray();
                    requestAttahcments.FileContent = fileContents;
                    requestAttahcments.ServiceRequestID = ServiceRequestId;
                    serviceRequestAttahcments.Add(requestAttahcments);



                }
            }
            ServiceRequestUploadFilesCommand serviceRequestUploadFilesCommand = new ServiceRequestUploadFilesCommand
            {
                listOfAttachments = serviceRequestAttahcments,
            };
            var result = await mediator.Send(serviceRequestUploadFilesCommand);
            return Ok(result);

        }
    }
}
