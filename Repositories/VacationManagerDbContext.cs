using Microsoft.EntityFrameworkCore;
using VacationManager.Models;

namespace VacationManager.Repositories
{
    /// <summary>
    /// Class VacationManagerDbContext.
    /// Implements the <see cref="DbContext" />
    /// </summary>
    /// <seealso cref="DbContext" />
    public class VacationManagerDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Gets or sets the teams.
        /// </summary>
        /// <value>The teams.</value>
        public DbSet<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Gets or sets the time offs.
        /// </summary>
        /// <value>The time offs.</value>
        public DbSet<TimeOff> TimeOffs { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="VacationManagerDbContext"/> class.
        /// </summary>
        public VacationManagerDbContext()
        {
            this.Users = this.Set<User>();
            this.Teams = this.Set<Team>();
            this.Projects = this.Set<Project>();
            this.TimeOffs = this.Set<TimeOff>();
        }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
             .UseSqlServer(@"Server=localhost;Database=VacationManagerDb;Trusted_Connection=True;");
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.</remarks>
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
