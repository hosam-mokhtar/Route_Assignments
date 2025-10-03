using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Data
{
    internal class ItiDbContext : DbContext
    {
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<CourseInstructor> CoursesInstructors { get; set; }

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
            #region Configuration Classes (New Syntax)

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #endregion
        }
    }
}
