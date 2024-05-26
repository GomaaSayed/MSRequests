using MediatR;
using MSRequests.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Application.Commands.RequestServiceCommands
{
    public class DeleteServiceRequestCommand : IRequest<Response<string>>
    {
        public required Guid ServiceRequestId { get; set; }


    }
}
