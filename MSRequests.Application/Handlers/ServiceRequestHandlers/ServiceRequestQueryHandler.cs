using Azure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MSRequests.Application.Queries;
using MSRequests.Application.Queries.AuthQueries;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.IRepositories;
using MSRequests.Domain.Models;
using MSRequests.Infrastructure.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Application.Handlers.AuthHandlers
{
    public class ServiceRequestQueryHandler(IServiceRequestRepository serviceRequestRepository)
     : IRequestHandler<GetAllServiceRequestsQuery, IEnumerable<ServiceRequestDTO>>, IRequestHandler<GetAllServiceRequestsByIdQuery, ServiceRequestDTO>
    {
        public async Task<IEnumerable<ServiceRequestDTO>> Handle(GetAllServiceRequestsQuery request, CancellationToken cancellationToken)
        {
            return await serviceRequestRepository.GetAllServiceRequestAsync();
        }

        public async Task<ServiceRequestDTO> Handle(GetAllServiceRequestsByIdQuery request, CancellationToken cancellationToken)
        {
            return await serviceRequestRepository.GetServiceRequestByIdAsync(request.ServiceRequestId);
        }
    }
}
