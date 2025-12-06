using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Talabat.Factories;

namespace Talabat.Extensions
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddswaggerService(this IServiceCollection Services)
        {
            /*builder.*/Services.AddEndpointsApiExplorer();
            /*builder.*/Services.AddSwaggerGen();
        
            return Services;
        }

        public static IServiceCollection AddWebApplicationServices(this IServiceCollection Services, IConfiguration configuration)
        {

            /*builder.*/Services.Configure<ApiBehaviorOptions>((options) =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorResponse;
            });
            Services.ConfigureJwtAuthentication(configuration);
            return Services;
        }

        public static void ConfigureJwtAuthentication(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddAuthentication(Config =>
            {
                Config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Config =>
            {
                Config.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JwtOptions:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = configuration["JwtOptions:Audience"],

                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(
                                       Encoding.UTF8.GetBytes(configuration["JwtOptions:SecretKey"]!)),
                };
            });
        }
    }
}
