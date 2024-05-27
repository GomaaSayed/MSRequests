using MediatR;
using Microsoft.AspNetCore.Identity;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Application.Commands
{
    public class SaveServiceRequestCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required string RequestNumber { get; set; }
        public required string RequestDescription { get; set; }
        public required string RequestType { get; set; }
        public required int StatusID { get; set; } // e.g., 'Open', 'In Progress', 'Closed', 'On Hold',;Draft;
        public required int PriorityID { get; set; }  // e.g., 'Low', 'Medium', 'High'
        public required string AssignedToID { get; set; }
        public required bool ReadOnly { get; set; }
    }
}
