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
    public class ServiceRequest:BaseEntity
    {
       
        public string RequestNumber { get; set; }
       
        [Required]
        public string RequestDescription { get; set; }

        [Required]
        [MaxLength(50)]
        public string RequestType { get; set; }
        [Required]
        public int StatusID { get; set; } //Submitted, Reviewed, Approved, Rejected,Draft
        [Required]
        public int PriorityID { get; set; }  // e.g., 'Low', 'Medium', 'High'
    
        public string? AssignedToID { get; set; }
        [ForeignKey("AssignedToID")]
        public IdentityUser AssignedTo { get; set; }
        public ICollection<RequestHistory> requestHistories { get; set; }


    }
}
