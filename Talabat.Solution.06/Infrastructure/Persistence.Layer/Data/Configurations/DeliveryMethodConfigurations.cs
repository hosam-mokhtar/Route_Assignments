using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.OrderModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Layer.Data.Configurations
{
    public class DeliveryMethodConfigurations : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DelieveryMethods");
            builder.Property(d => d.Price).HasColumnType("decimal(8,2)");
            builder.Property(d => d.ShortName).HasColumnType("varchar(50)");
            builder.Property(d => d.Description).HasColumnType("varchar(50)");
            builder.Property(d => d.DeliveryTime).HasColumnType("varchar(50)");
        }
    }
}
