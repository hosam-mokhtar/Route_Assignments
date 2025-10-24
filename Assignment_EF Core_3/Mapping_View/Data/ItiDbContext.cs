using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Mapping_View.Data.Models;
using Mapping_View.Data.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace Mapping_View.Data
{
    internal class ItiDbContext : DbContext
    {
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<CourseInstructor> CoursesInstructors { get; set; }
        public DbSet<DepartmentsAndStudents> DepartmentsAndStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server = NO;
                                        database = ITI3;
                                        Trusted_Connection = True; 
                                        TrustServerCertificate = True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Create Empty Migration
            modelBuilder.Entity<DepartmentsAndStudents>()
                        .HasNoKey()                          // Because it's a view, not a table
                        .ToView("DepartmentsAndStudents");   // Matches the SQL view name


            #region Configuration Classes 

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #endregion
        }
    }
}
