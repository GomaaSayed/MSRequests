using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; } = DateTime.Now;
        public Guid LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
