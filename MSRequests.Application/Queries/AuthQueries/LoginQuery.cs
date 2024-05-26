using Azure;
using MediatR;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Application.Queries.AuthQueries
{
    public class LoginQuery()
     : IRequest<Domain.DTOs.Response<AuthenticationDTO>>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
