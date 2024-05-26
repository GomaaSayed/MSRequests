using Microsoft.AspNetCore.Identity;
using MSRequests.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSRequests.Domain.Models;

namespace MSRequests.Domain.DTOs
{
    public class ServiceRequestDTO:BaseEntity
    {

        public string RequestNumber { get; set; }
        public string RequestDescription { get; set; }
        public bool  ReadOnly { get; set; }
        public string RequestType { get; set; }
        public int StatusID { get; set; } // e.g., 'Open', 'In Progress', 'Closed', 'On Hold'
        public string StatusName { get; set; }
        public int PriorityID { get; set; }  // e.g., 'Low', 'Medium', 'High'
        public string PriorityName { get; set; }
        public string? AssignedToID { get; set; }
        public string AssignedToName { get; set; }
        public string CreatedByName { get; set; }
        public string LastModifiedByName { get; set; }

    }
}
