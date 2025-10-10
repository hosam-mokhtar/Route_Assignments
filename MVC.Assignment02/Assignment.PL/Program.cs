using Assignment.DAL.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Assignment.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services : Add services to the DI container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ApplicationDbContext>(); //Register Service
            //Give CLR Permission to Inject This Service, If needed

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                //var conString = builder.Configuration["ConnectionStrings:DefaultConnection"];
                //or syntax
                //var conString = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
                //or syntax
                var conString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(/*"connectionstring"*/);
            }
            );



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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
