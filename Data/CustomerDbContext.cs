using HealthCheckSample.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCheckSample.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {            
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
