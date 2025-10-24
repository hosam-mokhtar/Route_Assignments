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

            #region (1 - M) (T opic- Course) Relationship

            builder.HasOne(c => c.Topics)
                   .WithMany(t => t.Courses)
                   .IsRequired()
                   .HasForeignKey(c => c.TopicId);

            builder.Property(c => c.TopicId)
                   .HasColumnName("Top_ID");
            #endregion
        }
    }
}
