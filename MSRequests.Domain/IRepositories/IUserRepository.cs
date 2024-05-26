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
    public interface IUserRepository
    {
        Task<Response<AuthenticationDTO>> LoginAsync(UserLoginDTO userLogin);
        Task<Response<string>> RegisterAsync(UserInfoDTO user);
    }
}
