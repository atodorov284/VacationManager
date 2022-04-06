using Microsoft.EntityFrameworkCore;
using VacationManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationManager.Repositories
{
    public class VacationManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TimeOff> TimeOffs { get; set; }


        public VacationManagerDbContext()
        {
            this.Users = this.Set<User>();
            this.Teams = this.Set<Team>();
            this.Projects = this.Set<Project>();
            this.TimeOffs = this.Set<TimeOff>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
             .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VacationMangerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = 1,
                    Username = "CEO",
                    Password = "CEOpass",
                    FirstName = "Admin",
                    LastName = "Istrator",
                    Role = 3
                });
        }
    }
}