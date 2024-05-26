using MediatR;
using Microsoft.AspNetCore.Identity;
using MSRequests.Application.Commands.AuthCommands;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.IRepositories;
using MSRequests.Domain.Models;
using MSRequests.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Application.Handlers.AuthHandlers
{
    public class RegisterCommandHandler(IUserRepository userRepository)
     : IRequestHandler<RegisterCommand, Response<string>>
    {


        public Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var item = new UserInfoDTO
            {
                UserName = request.UserName,
                Email = request.Email,
                Phone = request.Phone,
                Password = request.Password,
            };
            return userRepository.RegisterAsync(item);
        }
    }
}
