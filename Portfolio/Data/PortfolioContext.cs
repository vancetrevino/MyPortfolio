using Microsoft.EntityFrameworkCore;
using Portfolio.Models.BookingsModels;

namespace Portfolio.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<Models.BookingsModels.Employee> Employees { get; set; }
        public DbSet<Models.BookingsModels.Service> Services { get; set; }
        public DbSet<Models.BookingsModels.ServiceGroup> ServiceGroups { get; set; }
        public DbSet<Models.BookingsModels.EmployeeServiceAssignment> EmployeeServiceAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<ServiceGroup>().ToTable("ServiceGroup");
            modelBuilder.Entity<EmployeeServiceAssignment>().ToTable("EmployeeServiceAssignment");

            modelBuilder.Entity<EmployeeServiceAssignment>()
                .HasKey(e => new { e.EmployeeId, e.ServiceId });
        }
    }
}
