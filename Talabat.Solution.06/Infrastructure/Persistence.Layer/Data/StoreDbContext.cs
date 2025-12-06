using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
<<<<<<< Updated upstream
using Domain.Layer.Models;
=======
using Domain.Layer.Models.ProductModels;
>>>>>>> Stashed changes
using Microsoft.EntityFrameworkCore;

namespace Persistence.Layer.Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }


        public StoreDbContext(DbContextOptions<StoreDbContext> options) :base(options)
        {
            
        }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectReference).Assembly);
            //or
            //modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            //using System.Reflection;
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //or
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);

        }
    }
}
