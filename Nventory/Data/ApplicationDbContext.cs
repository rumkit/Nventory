using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nventory.Models;

namespace Nventory.Data
{
    public class ApplicationDbContext : IdentityDbContext<NventoryUser,NventoryRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // any guid
            const string adminRoleId = "C8C481A4-FBFA-4CB4-9CBC-4E00FBD94EDA";
            const string adminUserId = "646166C4-5E06-4976-AB63-6B0957E06F5F";
            
            builder.Entity<NventoryRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            });

            var hasher = new PasswordHasher<NventoryUser>();
            builder.Entity<NventoryUser>().HasData(new NventoryUser
            {
                Id = adminUserId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@example.com",
                NormalizedEmail = "admin@example.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "themoststrongpassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });
        }
    }    
}
