using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuarioFuncs.Models;

namespace UsuarioFuncs.Data
{
    public class AppDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) 
        : base(opt) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CustomIdentityUser admin = new CustomIdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(), //gerador de identificador unico
                Id = 99999
            };

            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();
            
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");
            builder.Entity<CustomIdentityUser>().HasData(admin);
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 99999, Name = "admin", NormalizedName = "ADMIN"}
            );
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>{ RoleId = 99999, UserId = 99999 }
            );

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 9999, Name = "regular", NormalizedName = "REGULAR"}
            );
        }
    }
}