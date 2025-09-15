using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Data.Configurations;
using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Data
{
    internal class ItiDbContext : DbContext
    {

        #region DbSets
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Instructor> Instructors { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Topic> Topics { get; set; }
        //public DbSet<CourseInstructor> CourseInstructors { get; set; }
        //public DbSet<StudentCourse> StudentCourses { get; set; } 
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server = NO;
                                  database = ITI2;
                                  Trusted_Connection = True; 
                                  TrustServerCertificate = True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Fluent API (Old Syntax)

            // Poco Class (Course)
            //modelBuilder.Entity<Course>().HasKey(c => c.Id);

            //modelBuilder.Entity<Course>().Property(c => c.Id)
            //                             .HasColumnName("ID")
            //                             .UseIdentityColumn(seed: 1, increment: 1);

            //modelBuilder.Entity<Course>().Property(c => c.Name)
            //                             .HasMaxLength(30);

            //modelBuilder.Entity<Course>().Property(c => c.Description)
            //                             .HasColumnType(SqlServerTypes.NVarChar(300));

            //modelBuilder.Entity<Course>().Property(c => c.TopicId)
            //                             .HasColumnName("Top_ID");
            #endregion

            #region Fluent API (New Syntax)

            // Poco Class (CourseInstructor)
            //modelBuilder.Entity<CourseInstructor>(entityBuilder =>
            //{
            //    entityBuilder.ToTable("Course_Inst");

            //    entityBuilder.HasKey(ci => new { ci.InstructorId, ci.CourseId });

            //    entityBuilder.Property(ci => ci.InstructorId)
            //                                 .HasColumnName("inst_ID");

            //    entityBuilder.Property(ci => ci.CourseId)
            //                                 .HasColumnName("Course_ID");

            //    entityBuilder.Property(ci => ci.Evaluate)
            //                                 .HasColumnType(SqlServerTypes.NVarChar(200));
            //});

            // Poco Class (Department)
            //modelBuilder.Entity<Department>(entityBuilder =>
            //{
            //    entityBuilder.HasKey(d => d.Id);

            //    entityBuilder.Property(d => d.Id)
            //                 .HasColumnName("ID")
            //                 .UseIdentityColumn(1, 1);

            //    entityBuilder.Property(d => d.Name)
            //                 .HasColumnName(SqlServerTypes.NVarChar(50));

            //    entityBuilder.Property(d => d.HiringDate)
            //                 .HasDefaultValueSql("getdate()");     // Sql Server Provider will assign Value

            //    entityBuilder.Property(d => d.InstructorId)
            //                 .HasColumnName("Ins_ID");
            //});

            // Poco Class (Instructor)
            //modelBuilder.Entity<Instructor>(entityBuilder =>
            //{
            //    entityBuilder.HasKey(i => i.Id);

            //    entityBuilder.Property(i => i.Id)
            //                 .HasColumnName("ID")
            //                 .UseIdentityColumn(1, 1);

            //    entityBuilder.Property(i => i.Name)
            //                 .HasColumnName(SqlServerTypes.NVarChar(30));

            //    entityBuilder.Property(i => i.Address)
            //                 .HasColumnName(SqlServerTypes.NVarChar(150))
            //                 .IsRequired(false);

            //    entityBuilder.Property(i => i.DepartmentId)
            //                 .HasColumnName("Dept_ID");
            //});

            // Poco Class (Student)
            //modelBuilder.Entity<Student>(entityBuilder =>
            //{
            //    entityBuilder.HasKey(s => s.Id);

            //    entityBuilder.Property(s => s.Id)
            //                 .HasColumnName("ID")
            //                 .UseIdentityColumn(1, 1);

            //    entityBuilder.Property(s => s.FirstName)
            //                 .HasColumnName("FName")
            //                 .HasColumnType(SqlServerTypes.NVarChar(30));

            //    entityBuilder.Property(s => s.LastName)
            //                 .HasColumnName("LName")
            //                 .HasColumnType(SqlServerTypes.NVarChar(30));

            //    entityBuilder.Property(s => s.Address)
            //                 .HasColumnName(SqlServerTypes.NVarChar(150))
            //                 .IsRequired(false);

            //    entityBuilder.Property(s => s.DepartmentId)
            //                 .HasColumnName("Dep_Id");
            //});

            // Poco Class (StudentCourse)
            //modelBuilder.Entity<StudentCourse>(entityBuilder =>
            //{
            //    entityBuilder.ToTable("Stud_Course");

            //    entityBuilder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            //    entityBuilder.Property(sc => sc.StudentId)
            //                                 .HasColumnName("stud_ID");

            //    entityBuilder.Property(sc => sc.CourseId)
            //                                 .HasColumnName("Course_ID");
            //});

            // Poco Class (Topic)
            //modelBuilder.Entity<Topic>(entityBuilder =>
            //{
            //    entityBuilder.HasKey(t => t.Id);

            //    entityBuilder.Property(t => t.Id)
            //                 .HasColumnName("ID")
            //                 .UseIdentityColumn(1, 1);

            //    entityBuilder.Property(t => t.Name)
            //                 .HasColumnName(SqlServerTypes.NVarChar(50));
            //});

            #endregion

            #region Configuration Classes (Old Syntax)

            //modelBuilder.ApplyConfiguration(new CourseConfigurations());
            //modelBuilder.ApplyConfiguration(new StudentConfigurations());
            //modelBuilder.ApplyConfiguration(new InstructorConfigurations());
            //modelBuilder.ApplyConfiguration(new TopicConfigurations());
            //modelBuilder.ApplyConfiguration(new DepartmentConfigurations());
            //modelBuilder.ApplyConfiguration(new CourseInstructorConfigurations());
            //modelBuilder.ApplyConfiguration(new StudentCourseConfigurations());

            #endregion

            #region Configuration Classes (New Syntax)

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #endregion

        }
    }
}
