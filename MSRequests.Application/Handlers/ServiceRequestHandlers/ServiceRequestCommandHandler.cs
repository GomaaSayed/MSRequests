using MediatR;
using Microsoft.AspNetCore.Identity;
using MSRequests.Application.Commands;
using MSRequests.Application.Commands.RequestServiceCommands;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.IRepositories;
using MSRequests.Domain.Models;
using MSRequests.Infrastructure.Contexts;
using MSRequests.Infrastructure.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Application.Handlers
{
    public class ServiceRequestCommandHandler(IServiceRequestRepository serviceRequestRepository)
     : IRequestHandler<SaveServiceRequestCommand, Response<string>>, IRequestHandler<DeleteServiceRequestCommand, Response<string>>, IRequestHandler<ServiceRequestUploadFilesCommand, Response<string>>
    {



        public Task<Response<string>> Handle(SaveServiceRequestCommand request, CancellationToken cancellationToken)
        {
            var ServiceRequest = new ServiceRequest
            {
                ID = request.Id,
                ReadOnly = request.ReadOnly,
                RequestNumber = request.RequestNumber,
                AssignedToID = request.AssignedToID,
                PriorityID = request.PriorityID,
                RequestDescription = request.RequestDescription,
                RequestType = request.RequestType,
                StatusID = request.StatusID,
                CreatedBy = request.UserId,
            };
            return serviceRequestRepository.SaveServiceAsync(ServiceRequest);
        }

        public Task<Response<string>> Handle(DeleteServiceRequestCommand request, CancellationToken cancellationToken)
        {
            return serviceRequestRepository.DeleteServiceRequestAsync(request.ServiceRequestId);
        }

        public async Task<Response<string>> Handle(ServiceRequestUploadFilesCommand request, CancellationToken cancellationToken)
        {
            return await serviceRequestRepository.SaveServiceRequestAttachmentsAsync(request.listOfAttachments);
        }
    }
}
