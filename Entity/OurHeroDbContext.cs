﻿using Dotnet8.Model;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OurHero>().HasKey(x => x.Id);

            modelBuilder.Entity<OurHero>().HasData(
                new OurHero
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "",
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
                    Email = "Admin",
                    Password = "Admin",
                }
            );
        }
    }
}
