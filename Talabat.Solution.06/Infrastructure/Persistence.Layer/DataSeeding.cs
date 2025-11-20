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

        public async Task DataSeedAsync()
        {
            try
            {
                //Production
                if ((await _storeDbContext.Database./*GetPendingMigrations()*/GetPendingMigrationsAsync()).Any())
                {
                    await _storeDbContext.Database.MigrateAsync();
                }

                if (!_storeDbContext.ProductTypes.Any())
                {
                    //var productTypessData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence.Layer\Data\DataSeed\types.json");
                    var productTypessData = File.OpenRead(@"..\Infrastructure\Persistence.Layer\Data\DataSeed\types.json");      //OpenRead return FileStream
                    //Convert string to C# Object
                    var types = await JsonSerializer.DeserializeAsync<List<ProductType>>(productTypessData);

                    if (types is not null && types.Any())
                    {
                        await _storeDbContext.ProductTypes.AddRangeAsync(types);
                    }
                }
                if (!_storeDbContext.ProductBrands.Any())
                {
                    var productBrandsData = File.OpenRead(@"..\Infrastructure\Persistence.Layer\Data\DataSeed\brands.json");
                    //Convert string to C# Object
                    var brands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBrandsData);

                    if (brands is not null && brands.Any())
                    {
                        await _storeDbContext.ProductBrands.AddRangeAsync(brands);
                    }
                }
                if (!_storeDbContext.Products.Any())
                {
                    var productsData = File.OpenRead(@"..\Infrastructure\Persistence.Layer\Data\DataSeed\products.json");
                    //Convert string to C# Object
                    var products = await JsonSerializer.DeserializeAsync<List<Product>>(productsData);

                    if (products is not null && products.Any())
                    {
                        await _storeDbContext.Products.AddRangeAsync(products);
                    }
                }

                await _storeDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                //todo:
            }
        }
    }
}
