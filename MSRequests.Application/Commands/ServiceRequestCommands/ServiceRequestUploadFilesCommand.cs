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
using MSRequests.Domain.Models;

namespace MSRequests.Application.Commands
{
    public class ServiceRequestUploadFilesCommand : IRequest<Response<string>>
    {
    
        public required List<ServiceRequestAttahcments> listOfAttachments { get; set; }
    }
}
