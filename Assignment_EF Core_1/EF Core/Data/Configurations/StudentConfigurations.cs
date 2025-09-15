using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.Data.Configurations
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
                   .HasColumnName(SqlServerTypes.NVarChar(150))
                   .IsRequired(false);

            builder.Property(s => s.DepartmentId)
                   .HasColumnName("Dep_Id");
        }
    }
}
