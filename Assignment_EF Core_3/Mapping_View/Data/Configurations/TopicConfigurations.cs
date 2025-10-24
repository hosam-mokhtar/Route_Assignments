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
    internal class TopicConfigurations : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasColumnName("ID")
                   .UseIdentityColumn(1, 1);

            builder.Property(t => t.Name)
                   .HasColumnType(SqlServerTypes.NVarChar(50));

            #region (1 - M) (T opic- Course) Relationship
            builder.HasMany(t => t.Courses)
                   .WithOne(c => c.Topics)
                   .IsRequired(false)
                   .HasForeignKey(c => c.TopicId);
            #endregion
        }
    }
}
