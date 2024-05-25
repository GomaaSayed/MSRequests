using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Domain.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
