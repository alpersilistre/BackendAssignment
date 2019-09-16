using ClayBackendCase.API.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayBackendCase.API.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Lock> Locks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 1,
                Name = "Clay Solutions",
                Created = DateTime.UtcNow
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                Created = DateTime.UtcNow
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = "User",
                Created = DateTime.UtcNow
            });

            modelBuilder.Entity<Lock>().HasData(new Lock
            {
                Id = 1,
                Name = "Clay Tunnel Lock",
                Created = DateTime.UtcNow,
                CompanyId = 1,
                IsLocked = true
            });

            modelBuilder.Entity<Lock>().HasData(new Lock
            {
                Id = 2,
                Name = "Clay Office Lock",
                Created = DateTime.UtcNow,
                CompanyId = 1,
                IsLocked = true
            });
        }
    }
}
