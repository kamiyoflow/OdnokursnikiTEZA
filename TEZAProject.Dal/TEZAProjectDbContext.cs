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
          public DbSet<Post> Posts { get; set; }
          public DbSet<Comment> Comments { get; set; }

          protected override void OnModelCreating(ModelBuilder builder)
          {
               
               base.OnModelCreating(builder);

               builder.Entity<User>()
                    .HasOne(p => p.UserProfile)
                    .WithOne(b => b.User)
                    .HasForeignKey<UserProfile>(x => x.UserId);


          }

     }
}
