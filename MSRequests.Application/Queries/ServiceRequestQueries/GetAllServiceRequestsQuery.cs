﻿using Azure;
using MediatR;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Application.Queries
{
    public class GetAllServiceRequestsQuery()
     : IRequest<IEnumerable<ServiceRequestDTO>>
    {
    
    }
}
