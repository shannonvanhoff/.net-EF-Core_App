//using Webapi.Data.Entities;
using Microsoft.EntityFrameworkCore;

using Webapi.Data.Entities;
namespace Webapi.Data.Migrations

{
    public class AppContext : DbContext
    {

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; } 
        public DbSet <HTask> HTasks { get; set; }
        public  DbSet<Helper> helpers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {
            
         //   modelBuilder.Entity<HTask>()
           //      .HasOne(t => t.Helper)
             //    .WithMany() // A Helper can have many HTasks
               //  .HasForeignKey(t => t.Helper)
                 //.OnDelete(DeleteBehavior.Restrict);
        }//
        //public DbSet<HelpersDto> Help { get; set; }

        //public DbSet<TaskDto> Task { get; set; }
    
}
