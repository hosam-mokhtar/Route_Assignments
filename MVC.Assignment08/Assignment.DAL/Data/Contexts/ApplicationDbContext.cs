using System.Data.Common;
using Assignment.DAL.Models.DepartmentModel;
using Assignment.DAL.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Assignment.DAL.Data.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
                 : /*DbContext*/IdentityDbContext<ApplicationUser>(options)
    {
        //public DbSet</*IdentityUser*/ ApplicationDbContext> IdentityUsers { get; set; }
        //public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connection string");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Old Syntax
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
            //or
            //modelBuilder.ApplyConfiguration(new DepartmentConfigurations());

            //New Syntax
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //or
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
