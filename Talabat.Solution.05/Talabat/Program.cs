
using Domain.Layer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Layer;
using Persistence.Layer.Data;
using Persistence.Layer.Repositories;
using Service.Layer;
using Service.Layer.Mapping_Profiles;
using ServiceAbstraction.Layer;

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

            #endregion

            var app = builder.Build();

            #region Data Seeding

            using var scope = app.Services.CreateScope(); 
            var seedObj = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await seedObj.DataSeedAsync();

            #endregion


            #region Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();

            #endregion
        }
    }
}
