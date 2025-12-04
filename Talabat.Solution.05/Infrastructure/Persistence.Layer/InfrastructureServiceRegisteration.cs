using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Contracts;
using Domain.Layer.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Layer.Data;
using Persistence.Layer.Identity;
using Persistence.Layer.Repositories;
using Service.Layer;
using ServiceAbstraction.Layer;
using StackExchange.Redis;

namespace Persistence.Layer
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection Services,
                                                                  IConfiguration _configuration)
        {

            /*builder.*/
            Services.AddDbContext</*StoreDbContext*/StoreIdentityDbContext>(options =>
            {
                options.UseSqlServer(/*builder.Configuration*/_configuration.GetConnectionString(/*"DefaultConnection"*/ "IdentityConnection"));
            });

            Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(/*builder.Configuration*/_configuration.GetConnectionString("DefaultConnection"));
            });

            /*builder.*/
            Services/*AddIdentity*/.AddIdentityCore<ApplicationUser/*, IdentityRole*/>()
                                   .AddRoles<IdentityRole>()
                                   .AddEntityFrameworkStores<StoreIdentityDbContext>();

            /*builder.*/
            Services.AddScoped<IDataSeeding, DataSeeding>();
            /*builder.*/
            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            Services.AddScoped<IBasketRepository, BasketRepository>();

            Services.AddSingleton<IConnectionMultiplexer>((_) =>
            {
                return ConnectionMultiplexer.Connect(/*"localhost"*/_configuration.GetConnectionString("RedisConnectionString")   !   );
            });

            return Services;
        }
    }
}
