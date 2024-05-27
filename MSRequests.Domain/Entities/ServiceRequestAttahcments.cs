using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MSRequests.Domain.Entities;
using System.Numerics;

namespace MSRequests.Domain.Models
{
    public class ServiceRequestAttahcments:BaseEntity
    {
        [Required]
        public Guid ServiceRequestID { get; set; }

        [ForeignKey("ServiceRequestID")]
        public ServiceRequest ServiceRequest { get; set; }

        public byte[] FileContent { get; set; }

    }
}
