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
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        void IEntityTypeConfiguration<Department>.Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                   .HasColumnName("ID")
                   .UseIdentityColumn(1, 1);

            builder.Property(d => d.Name)
                   .HasColumnType(SqlServerTypes.NVarChar(50));

            builder.Property(d => d.HiringDate)
                   .HasDefaultValueSql("getdate()");     // Sql Server Provider will assign Value


            #region (1 - M) (Department - Student) Relationship
            builder.HasMany(d => d.Students)
                   .WithOne(s => s.Department)
                   .IsRequired(false)
                   .HasForeignKey(s => s.DepartmentId);
            #endregion

            #region (1 - M) (Department - Instructors) Relationship
            builder.HasMany(d => d.Instructors)
                   .WithOne(i => i.Department)
                   .IsRequired()
                   .HasForeignKey(i => i.DepartmentId);
            #endregion

            #region (1 - 1) (Department - Instructor) Relationship
            builder.HasOne(d => d.Manager)
                   .WithOne(i => i.DepartmentToManage)
                   .IsRequired()
                   .HasForeignKey<Instructor>(d => d.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
}
}
