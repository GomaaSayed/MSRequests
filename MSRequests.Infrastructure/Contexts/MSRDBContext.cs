using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MSRequests.Domain.Models;
using MSRequests.Domain.Entities;

namespace MSRequests.Infrastructure.Contexts
{
    public class MSRDBContext : IdentityDbContext<IdentityUser>
    {
        public MSRDBContext(DbContextOptions<MSRDBContext> options) : base(options) { }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }
        public DbSet<ServiceRequestAttahcments> ServiceRequestAttahcments { get; set; }
        public DbSet<RequestHistory> RequestHistory { get; set; }
    

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>().ToTable("Users", "dbo");
            builder.Entity<IdentityRole>().ToTable("Roles", "dbo");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "dbo");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "dbo");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "dbo");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "dbo");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "dbo");

        }
    }
}
