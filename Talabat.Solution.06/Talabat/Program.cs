<<<<<<< Updated upstream

using Domain.Layer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Layer;
using Persistence.Layer.Data;
=======
using System.Collections.Generic;
using Azure.Core;
using Domain.Layer.Contracts;
using Domain.Layer.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens.Experimental;
using Persistence.Layer;
using Persistence.Layer.Data;
using Persistence.Layer.Identity;
>>>>>>> Stashed changes
using Persistence.Layer.Repositories;
using Service.Layer;
using Service.Layer.Mapping_Profiles;
using ServiceAbstraction.Layer;
<<<<<<< Updated upstream
=======
using Shared.ErrorModels;
using Talabat.CustomMiddleWares;
using Talabat.Extensions;
using Talabat.Factories;
>>>>>>> Stashed changes

namespace Talabat
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Add Services to The Container

            builder.Services.AddControllers();
<<<<<<< Updated upstream
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDataSeeding,DataSeeding>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Mapping Register

            //builder.Services.AddAutoMapper(p => p.AddProfile(new ProductProfile()));
            //builder.Services.AddAutoMapper(p => p.AddProfiles(new ProductProfile(), ));

            //OR Dynamic 
            //Version AutoMapper 14.0.0
            //builder.Services.AddAutoMapper(typeof(ServiceLayerAssemblyReference).Assembly);

            //Latest Version AutoMapper 15.1.0
            builder.Services.AddAutoMapper((x) => { }, typeof(ServiceLayerAssemblyReference).Assembly);

            #endregion

            builder.Services.AddScoped<IServiceManager, ServiceManager>();

=======

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddswaggerService();

            #region Register User-Defined Services
            //Call Static Method 
            //ApplicationServicesRegisteration.AddApplicationServices(builder.Services);
            //or
            //Call Extension Method 
            builder.Services.AddApplicationServices();

            builder.Services.AddInfrastructureService(builder.Configuration);

            builder.Services.AddWebApplicationServices(builder.Configuration);


            #endregion

>>>>>>> Stashed changes
            #endregion

            var app = builder.Build();

            #region Data Seeding

<<<<<<< Updated upstream
            using var scope = app.Services.CreateScope(); 
            var seedObj = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await seedObj.DataSeedAsync();
=======
            await app.SeedDatabaseAsync();
>>>>>>> Stashed changes

            #endregion


            #region Configure the HTTP request pipeline.

<<<<<<< Updated upstream
=======

            //app.Use(async (RequestContent, NextMiddleWare) =>
            //{
            //    Console.WriteLine("Request Under Processing");
            //    await NextMiddleWare.Invoke();
            //    Console.WriteLine("Waiting Response");
            //});

            app.UseCustomExceptionMiddleWare();
            

>>>>>>> Stashed changes
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

<<<<<<< Updated upstream
            app.UseAuthorization();

=======

            app.UseAuthentication();
            app.UseAuthorization();


>>>>>>> Stashed changes
            app.UseStaticFiles();
            app.MapControllers();

            app.Run();

            #endregion
        }
    }
}
