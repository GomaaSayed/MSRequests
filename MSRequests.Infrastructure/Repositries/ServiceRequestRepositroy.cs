using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.IRepositories;
using MSRequests.Domain.Models;
using MSRequests.Infrastructure.Contexts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace MSRequests.Infrastructure.Repositries
{
    public class ServiceRequestRepositroy : IServiceRequestRepository
    {
        private readonly MSRDBContext _DBContext;

        public ServiceRequestRepositroy(MSRDBContext DBContext)
        {
            _DBContext = DBContext;

        }
        public async Task<Response<string>> DeleteServiceRequestAsync(Guid Id)
        {
            var serviceRequest = _DBContext.ServiceRequest.FirstOrDefault(s => s.ID == Id);
            if (serviceRequest == null)
                return new Response<string>() { Message = "The service request not found", Success = false };
            else
            {
                _DBContext.ServiceRequest.Remove(serviceRequest);
                _DBContext.SaveChanges();
                return new Response<string>() { Message = "OK", Success = true };
            }
        }

        public async Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestAsync()
        {
            var result = await (from SR in _DBContext.ServiceRequest
                                join user in _DBContext.Users on SR.AssignedToID equals user.Id
                                join createdBy in _DBContext.Users on SR.CreatedBy equals new Guid(createdBy.Id)
                                select new ServiceRequestDTO
                                {
                                    AssignedToName = user.UserName,
                                    StatusName = SR.StatusID == 1 ? "Draft" : (SR.StatusID == 2 ? "Submitted" : (SR.StatusID == 3 ? "Reviewe" : (SR.StatusID == 4 ? "Approved" : "Rejected"))),
                                    RequestDescription = SR.RequestDescription,
                                    RequestNumber = SR.RequestNumber,
                                    RequestType = SR.RequestType,
                                    PriorityName = SR.PriorityID == 1 ? "Low" : (SR.PriorityID == 2 ? "Medium" : "High"),
                                    AssignedToID = SR.AssignedToID,
                                    CreatedBy = new Guid(createdBy.Id),
                                    CreatedByName = createdBy.UserName,
                                    CreatedOn = SR.CreatedOn,
                                    IsDeleted = SR.IsDeleted,
                                    LastModifiedBy = SR.LastModifiedBy,
                                    LastModifiedOn = SR.LastModifiedOn

                                }).ToListAsync();
            return result;
        }

        public async Task<ServiceRequestDTO> GetServiceRequestByIdAsync(Guid Id)
        {
            var result = await (from SR in _DBContext.ServiceRequest
                                join user in _DBContext.Users on SR.AssignedToID equals user.Id
                                join createdBy in _DBContext.Users on SR.CreatedBy equals new Guid(createdBy.Id)
                                select new ServiceRequestDTO
                                {
                                    AssignedToName = user.UserName,
                                    StatusName = SR.StatusID == 1 ? "Draft" : (SR.StatusID == 2 ? "Submitted" : (SR.StatusID == 3 ? "Reviewe" : (SR.StatusID == 4 ? "Approved" : "Rejected"))),
                                    RequestDescription = SR.RequestDescription,
                                    RequestNumber = SR.RequestNumber,
                                    RequestType = SR.RequestType,
                                    PriorityName = SR.PriorityID == 1 ? "Low" : (SR.PriorityID == 2 ? "Medium" : "High"),
                                    AssignedToID = SR.AssignedToID,
                                    CreatedBy = new Guid(createdBy.Id),
                                    CreatedByName = createdBy.UserName,
                                    CreatedOn = SR.CreatedOn,
                                    IsDeleted = SR.IsDeleted,
                                    LastModifiedBy = SR.LastModifiedBy,
                                    LastModifiedOn = SR.LastModifiedOn

                                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Response<string>> SaveServiceAsync(ServiceRequest model)
        {
            Response<string> response = new Response<string>();
            var OldServiceRequest = await _DBContext.ServiceRequest.FirstOrDefaultAsync(s => s.ID == model.ID);
            if (OldServiceRequest != null)
            {
                OldServiceRequest.PriorityID = model.PriorityID;
                OldServiceRequest.AssignedToID = model.AssignedToID;
                OldServiceRequest.StatusID = model.StatusID;
                OldServiceRequest.RequestDescription = model.RequestDescription;
                OldServiceRequest.LastModifiedBy = model.LastModifiedBy;
                OldServiceRequest.LastModifiedOn = DateTime.Now;
                OldServiceRequest.CreatedBy = model.CreatedBy;
                OldServiceRequest.RequestNumber = model.RequestNumber;

                _DBContext.ServiceRequest.Update(OldServiceRequest);
                await _DBContext.SaveChangesAsync();
                response.Message = "Entity updated successfully";
                response.Success = true;


            }
            else
            {
                model.CreatedOn = DateTime.Now;
                _DBContext.ServiceRequest.Add(model);
                await _DBContext.SaveChangesAsync();
                response.Message = "Entity added successfully";
                response.Success = true;
            }
            return response;
        }
    }
}