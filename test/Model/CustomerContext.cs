
using Microsoft.EntityFrameworkCore;
namespace test.Model

{
    public class CustomerContext:DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) 
            : base(options) 
        {

        }

        public DbSet<CustomerDto> Customers { get; set; } = null;
        public DbSet<HelpersDto> Helpers { get; set; }

        public DbSet<TaskDto> Task { get; set; }
    }
}
