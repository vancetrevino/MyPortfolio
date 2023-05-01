using Portfolio.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
