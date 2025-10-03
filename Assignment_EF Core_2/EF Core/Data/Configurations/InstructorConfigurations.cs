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
    internal class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        void IEntityTypeConfiguration<Instructor>.Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                   .HasColumnName("ID")
                   .UseIdentityColumn(1, 1);

            builder.Property(i => i.Name)
                   .HasColumnType(SqlServerTypes.NVarChar(30));

            builder.Property(i => i.Address)
                   .HasColumnType(SqlServerTypes.NVarChar(150))
                   .IsRequired(false);

            #region (1 - M) (Department - Instructors) Relationship
            builder.HasOne(i => i.Department)
                   .WithMany(d => d.Instructors)
                   .IsRequired()
                   .HasForeignKey(i => i.DepartmentId);

            builder.Property(i => i.DepartmentId)
                   .HasColumnName("Dept_ID");
            #endregion

            #region (1 - 1) (Department - Instructor) Relationship
            builder.HasOne(i => i.DepartmentToManage)
                   .WithOne(d => d.Manager)
                   .IsRequired()
                   .HasForeignKey<Instructor>(d => d.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
