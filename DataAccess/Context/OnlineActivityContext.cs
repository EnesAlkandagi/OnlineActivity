using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.Dtos.Concrete.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class OnlineActivityContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public OnlineActivityContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=OnlineActivity; Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash("admin123", out passwordHash, out passwordSalt);
            modelBuilder.Entity<User>().HasData(new User { Id = 1, FirstName = "ADMİN", LastName = "ADMİN", Email = "admin@gmail.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "USER" },
                new Role { Id = 2, Name = "ADMİN" });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 1, RoleId = 2, UserId = 1 });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<Firm> Firms { get; set; }

    }
}
