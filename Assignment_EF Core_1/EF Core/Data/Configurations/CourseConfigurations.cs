using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.Data.Configurations
{
    internal class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        void IEntityTypeConfiguration<Course>.Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("ID")
                   .UseIdentityColumn(seed: 1, increment: 1);

            builder.Property(c => c.Name)
                   .HasMaxLength(30);

            builder.Property(c => c.Description)
                   .HasColumnType(SqlServerTypes.NVarChar(300));

            builder.Property(c => c.TopicId)
                   .HasColumnName("Top_ID");
        }
    }
}
