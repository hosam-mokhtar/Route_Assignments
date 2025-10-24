using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapping_View.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mapping_View.Data.Configurations
{
    internal class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        void IEntityTypeConfiguration<Student>.Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .HasColumnName("ID")
                   .UseIdentityColumn(1, 1);

            builder.Property(s => s.FirstName)
                   .HasColumnName("FName")
                   .HasColumnType(SqlServerTypes.NVarChar(30));

            builder.Property(s => s.LastName)
                   .HasColumnName("LName")
                   .HasColumnType(SqlServerTypes.NVarChar(30));

            builder.Property(s => s.Address)
                   .HasColumnType(SqlServerTypes.NVarChar(150))
                   .IsRequired(false);


            #region (1 - M) (Department - Student) Relationship
            builder.HasOne(s => s.Department)
                   .WithMany(d => d.Students)
                   .IsRequired()
                   .HasForeignKey(s => s.DepartmentId);

            builder.Property(s => s.DepartmentId)
                   .HasColumnName("Dep_Id");
            #endregion
        }
    }
}

