using MSRequests.Domain.Models;
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

        [ForeignKey("RequestID")]
        public ServiceRequest ServiceRequest { get; set; }

        [Required]
        public int StatusID { get; set; }

        [Required]
        public string ChangedByID { get; set; }

        [ForeignKey("ChangedByID")]
        public IdentityUser ChangedBy { get; set; }
        public DateTime DateChanged { get; set; } = DateTime.UtcNow;

        public string Notes { get; set; }
    }

}
