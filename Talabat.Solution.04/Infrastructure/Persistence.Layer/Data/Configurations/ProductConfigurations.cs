using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Layer.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Configure Relation
            builder.HasOne(p => p.ProductBrand)
                   .WithMany()
                   .HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.ProductType)
                   .WithMany()
                   .HasForeignKey(p => p.TypeId);

            builder.Property(p => p.Name).HasColumnType("nvarchar(200)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(500)");


            //builder.Property(p => p.Price).HasColumnType("decimal(10,2)");

            //More Readable and Support Sql Providers
            builder.Property(p => p.Price).HasPrecision(10,2);

        }
    }
}
