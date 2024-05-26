using Azure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MSRequests.Application.Queries.AuthQueries;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.IRepositories;
using MSRequests.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Application.Handlers.AuthHandlers
{
    public class LoginQueryHandler(IUserRepository userRepository)
     : IRequestHandler<LoginQuery, Domain.DTOs.Response<AuthenticationDTO>>
    {
        public async Task<Domain.DTOs.Response<AuthenticationDTO>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            UserLoginDTO userLoginDTO = new UserLoginDTO();
            userLoginDTO.UserName = request.UserName;
            userLoginDTO.Password = request.Password;
            return await userRepository.LoginAsync(userLoginDTO);
        }
    }
}
