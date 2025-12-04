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
using Persistence.Layer.Repositories;
using Service.Layer;
using Service.Layer.Mapping_Profiles;
using ServiceAbstraction.Layer;
using Shared.ErrorModels;
using Talabat.CustomMiddleWares;
using Talabat.Extensions;
using Talabat.Factories;

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

            #endregion

            var app = builder.Build();

            #region Data Seeding

            await app.SeedDatabaseAsync();

            #endregion


            #region Configure the HTTP request pipeline.


            //app.Use(async (RequestContent, NextMiddleWare) =>
            //{
            //    Console.WriteLine("Request Under Processing");
            //    await NextMiddleWare.Invoke();
            //    Console.WriteLine("Waiting Response");
            //});

            app.UseCustomExceptionMiddleWare();
            

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();


            app.UseStaticFiles();
            app.MapControllers();

            app.Run();

            #endregion
        }
    }
}
