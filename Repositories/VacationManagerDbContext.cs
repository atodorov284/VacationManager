using Microsoft.EntityFrameworkCore;
using VacationManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Models.TimeOffs;

namespace VacationManager.Repositories
{
    public class VacationManagerDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<PaidTimeOff> PaidTimeOffs { get; set; }
        public virtual DbSet<SickTimeOff> SickTimeOffs { get; set; }
        public virtual DbSet<UnpaidTimeOff> UnpaidTimeOffs { get; set; }


        public VacationManagerDbContext()
        {
            this.Users = this.Set<User>();
            this.Teams = this.Set<Team>();
            this.Projects = this.Set<Project>();
            this.PaidTimeOffs = this.Set<PaidTimeOff>();
            this.SickTimeOffs = this.Set<SickTimeOff>();
            this.UnpaidTimeOffs = this.Set<UnpaidTimeOff>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
             .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VacationMangerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
