using MediatR;
using MSRequests.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Application.Commands.AuthCommands
{
    public class RegisterCommand : IRequest<Response<string>>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}
