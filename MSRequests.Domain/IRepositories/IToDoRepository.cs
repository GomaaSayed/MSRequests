using MSRequests.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Domain.IRepositories
{
    public interface IToDoRepository
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task<int> CreateAsync(ToDoItem item);
    }
}
