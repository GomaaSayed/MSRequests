﻿using MSRequests.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MSRequests.Domain.Entities
{

    public class RequestHistory : BaseEntity
    {


        [Required]
        public Guid ServiceRequestID { get; set; }

        [ForeignKey("ServiceRequestID")]
        public ServiceRequest ServiceRequest { get; set; }

        [Required]
        public int StatusID { get; set; }

        public string Notes { get; set; }
        List<ServiceRequestAttahcments> serviceRequestAttahcments { get; set; }
    }

}
