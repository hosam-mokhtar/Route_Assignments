using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

namespace MVC
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Register Services in DI Container

            builder.Services.AddControllersWithViews();

            #endregion

            var app = builder.Build();

            #region Map

            //app.MapGet("/", () => "Hello World!");                    //Default
            ////app.MapGet("/", () => "Hello World!");                  //Default - Make Error

            ////Static Segment
            ////app.MapGet("/hossam", async (context) =>
            ////{
            ////    await context.Response.WriteAsync("Hello hossam");
            ////});

            ////Static Segment
            //app.MapGet("/hossam", () => "Hello------hossam");

            ////Dynamic Segment
            //app.MapGet("/{name}", async (context) =>
            //{
            //    var n = context.GetRouteValue("name");
            //    await context.Response.WriteAsync($"Hello {n}!");
            //});

            ////Mixed Segment
            //app.MapGet("/mr{name}", async (context) =>
            //{
            //    var name = context.GetRouteValue("name");
            //    await context.Response.WriteAsync($"Hello Mr :{name}");
            //});

            #endregion

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller}/{action}/{id?}",
               defaults: new { controller = "Movies", action = "Index" },
               constraints: new { Id = new IntRouteConstraint() }
            );

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                //pattern:"/Movies/Index"                                            //wrong
                //pattern: "{controller=Movies}/{action=Index}"
                //pattern: "{controller=Movies}/{action=Index}/{id?}/{name}"         //wrong Logic code --- Correct : name -> QueryString
                //pattern: "{controller=Movies}/{action=Index}/{id?}"
                //pattern: "{controller=Movies}/{action=Index}/{id:int?}"


                pattern: "{controller =Home}/{action = Index}/{id:int?}"
               );



            app.Run();
        }
    }
}
