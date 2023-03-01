using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TEZAProject.Domain;
using TEZAProject.Domain.Auth;

namespace TEZAProject.Dal
{
     public class TEZAProjectDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
     {
          public TEZAProjectDbContext(DbContextOptions<TEZAProjectDbContext> options) : base(options)
          { }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               optionsBuilder.EnableSensitiveDataLogging();
          }

          public DbSet<UserProfile> UserProfiles { get; set; }

     }
}
