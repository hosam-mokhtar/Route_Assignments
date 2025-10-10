using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//using Assignment.DAL.Data.Configurations;
//or
using System.Reflection;


namespace Assignment.DAL.Data.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }
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
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
