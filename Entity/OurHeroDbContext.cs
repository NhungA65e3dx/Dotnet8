using Dotnet8.Model;
using Microsoft.EntityFrameworkCore;

namespace Dotnet8.Entity
{
    public class OurHeroDbContext : DbContext
    {
        public OurHeroDbContext(DbContextOptions<OurHeroDbContext> options) : base(options)
        {
        }
        public DbSet<OurHero> OurHeros { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OurHero>().HasKey(x => x.Id);

            modelBuilder.Entity<OurHero>().HasData(
                new OurHero
                {
                    Id = 1,
                    Name = "User",
                    UserName = "User",
                    Email = "User@123",
                    Password = "Password@123",
                    Role = "User",
                    isActive = true,
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    FirstName = "Admin",
                    LastName = "",
                    Username = "Admin",
                    Email = "Admin@123",
                    Password = "Admin",
                    Role = "Admin",
                }
            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,                   
                    UserName = "Customer",
                    Phone = "0125458752",
                    Email = "Customer@123",
                    Password = "Customer@123",
                    Role = "Customer",
                    isActive = true,
                }
            );
        }
    }
}
