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
                   .HasColumnName(SqlServerTypes.NVarChar(50));

            builder.Property(d => d.HiringDate)
                   .HasDefaultValueSql("getdate()");     // Sql Server Provider will assign Value

            builder.Property(d => d.InstructorId)
                   .HasColumnName("Ins_ID");
        }
    }
}
