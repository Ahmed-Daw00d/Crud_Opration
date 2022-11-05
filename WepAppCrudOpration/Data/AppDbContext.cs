using Microsoft.EntityFrameworkCore;
using WepAppCrudOpration.Models;

namespace WepAppCrudOpration.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //create schema 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Employee>().ToTable("Employees", "Hr");
        }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
