using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Layer.Contracts;
using Domain.Layer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Layer.Data;

namespace Persistence.Layer
{
    public class DataSeeding(StoreDbContext _storeDbContext) : IDataSeeding
    {

        public void DataSeed()
        {
            try
            {
                if (_storeDbContext.Database.GetPendingMigrations().Any())
                {
                    _storeDbContext.Database.Migrate();
                }

                if (!_storeDbContext.ProductTypes.Any())
                {
                    var productTypessData = File.ReadAllText(@"..\Infrastructure\Persistence.Layer\Data\DataSeed\types.json");
                    //Convert string to C# Object
                    var types = JsonSerializer.Deserialize<List<ProductType>>(productTypessData);

                    if (types is not null && types.Any())
                    {
                        _storeDbContext.ProductTypes.AddRange(types);
                    }
                }
                if (!_storeDbContext.ProductBrands.Any())
                {
                    var productBrandsData = File.ReadAllText(@"..\Infrastructure\Persistence.Layer\Data\DataSeed\brands.json");
                    //Convert string to C# Object
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsData);

                    if (brands is not null && brands.Any())
                    {
                        _storeDbContext.ProductBrands.AddRange(brands);
                    }
                }
                if (!_storeDbContext.Products.Any())
                {
                    var productsData = File.ReadAllText(@"..\Infrastructure\Persistence.Layer\Data\DataSeed\products.json");
                    //Convert string to C# Object
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    if (products is not null && products.Any())
                    {
                        _storeDbContext.Products.AddRange(products);
                    }
                }

                _storeDbContext.SaveChanges();
            }
            catch (Exception)
            {
                //todo:
            }
        }
    }
}
