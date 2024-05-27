using Microsoft.AspNetCore.Identity;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Domain.IRepositories
{
    public interface IServiceRequestRepository
    {
        Task<Response<string>> SaveServiceAsync(ServiceRequest model);
        Task<Response<string>> DeleteServiceRequestAsync(Guid Id);
        Task<ServiceRequestDTO> GetServiceRequestByIdAsync(Guid Id);
        Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestAsync();
        Task<Response<string>> SaveServiceRequestAttachmentsAsync(List<ServiceRequestAttahcments> serviceRequestAttahcments);
    }
}
