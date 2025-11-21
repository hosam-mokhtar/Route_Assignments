using Assignment.BLL;
using Assignment.BLL.Mapping_Profiles;
using Assignment.BLL.Services.AttachmentService;
using Assignment.BLL.Services.Classes;
using Assignment.BLL.Services.Interfaces;
using Assignment.DAL.Data.Contexts;
using Assignment.DAL.Models.IdentityModels;
using Assignment.DAL.Repositories.Classes;
using Assignment.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services : Add services to the DI container.

            //builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            builder.Services.AddScoped<ApplicationDbContext>(); //Register Service
            //Give CLR Permission to Inject This Service, If needed

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                //var conString = builder.Configuration["ConnectionStrings:DefaultConnection"];
                //or syntax
                //var conString = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
                //or syntax
                var conString = builder.Configuration.GetConnectionString("DefaultConnection");
                //options.UseLazyLoadingProxies().UseSqlServer(conString);
                //or
                options.UseSqlServer(conString).UseLazyLoadingProxies();
            }

            //,ServiceLifetime.Scoped                   //AddDbContext is Scoped (By Default) 
            
            );

            //builder.Services.AddScoped<DepartmentRepository>();      //No Delvelop against interface



            #region Comment Because using Lazy Loading Proxies
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            #endregion


            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            ///////////////////////////////////////////////////////////////////////////////////////
            //Old Version AutoMapper 14.0.0
            //builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            //builder.Services.AddAutoMapper(typeof(ProjectReference).Assembly);
            //or
            //builder.Services.AddAutoMapper((x) => { }, typeof(MappingProfiles).Assembly);
            //if Class MappingProfiles is (not) Public
            //builder.Services.AddAutoMapper((x) => { }, typeof(ProjectReference).Assembly);
            //or
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));

            // if you have more Mapping Profiles
            //builder.Services.AddAutoMapper(M => M.AddProfiles(new MappingProfiles(),));
            ///////////////////////////////////////////////////////////////////////////////////////


            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                //options.User.RequireUniqueEmail = true;
                //options.Password.RequireLowercase = true;
                //options.Password.RequireUppercase = true;


            })
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthentication();   
            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                //pattern: "{controller=Home}/{action=Index}/{id?}");
                pattern: "{controller=Account}/{action=register}/{id?}");

            app.Run();
        }
    }
}
