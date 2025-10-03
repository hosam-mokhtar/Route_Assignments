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
        }
    }
}
