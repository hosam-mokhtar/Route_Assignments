using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapping_Inheritance.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mapping_Inheritance.Data
{
    public class MyCompanyContext : DbContext
    {
        #region Dbsets (TPCT)
        //public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        //public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }

        #endregion

        #region Dbsets (TPH)
        //public DbSet<Employee> Employees { get; set; }
           ////public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
           ////public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }

        #endregion

        #region Dbsets (TPT)
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server = NO;
                                        database = InheritanceCompany;
                                        Trusted_Connection = True; 
                                        TrustServerCertificate = True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TPH

            //modelBuilder.Entity<FullTimeEmployee>()
            //    .HasBaseType(typeof(Employee));
            //modelBuilder.Entity<PartTimeEmployee>()
            //            .HasBaseType(typeof(Employee));


            //if you need to Change Discriminator Column Name & HasValues

            //modelBuilder.Entity<Employee>()
            //            .HasDiscriminator<string>("EmpType")
            //            .HasValue<FullTimeEmployee>("FTE")
            //            .HasValue<PartTimeEmployee>("PTE");

            #endregion

            #region TPT

            modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployee");
            modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployee");

            #endregion
        }

    }
}
