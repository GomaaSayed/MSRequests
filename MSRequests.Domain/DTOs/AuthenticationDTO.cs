using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRequests.Domain.DTOs
{
    public class AuthenticationDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<string> Roles { get; set; }
    }
}
