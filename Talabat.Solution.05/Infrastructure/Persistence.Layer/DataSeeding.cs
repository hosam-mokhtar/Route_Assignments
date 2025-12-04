using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Layer.Contracts;
using Domain.Layer.Models.IdentityModels;
using Domain.Layer.Models.ProductModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Layer.Data;

namespace Persistence.Layer
{
    public class DataSeeding(StoreDbContext _storeDbContext,
                             UserManager<ApplicationUser> _userManager,
                             RoleManager<IdentityRole> _roleManager) : IDataSeeding
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

        public async Task IdentityDataSeedAsync()
        {
            try
            {
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
                }


                if (!_userManager.Users.Any())
                {

                    var user01 = new ApplicationUser
                    {
                        Email = "hossammo@gmail.com",
                        DisplayName = "Hossam Mo",
                        PhoneNumber = "01234567890",
                        UserName = "hos"
                    };
                    var user02 = new ApplicationUser
                    {
                        Email = "momo@gmail.com",
                        DisplayName = "Mo Mo",
                        PhoneNumber = "01010101010",
                        UserName = "momo"
                    };
                    await _userManager.CreateAsync(user01, "P@ssw0rd");
                    await _userManager.CreateAsync(user02, "P@ssw0rd");

                    await _userManager.AddToRoleAsync(user01, "Admin");
                    await _userManager.AddToRoleAsync(user02, "SuperAdmin");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }   
}

