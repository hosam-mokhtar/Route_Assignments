using Microsoft.AspNetCore.Mvc;
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

        public static IServiceCollection AddWebApplicationServices(this IServiceCollection Services)
        {

            /*builder.*/Services.Configure<ApiBehaviorOptions>((options) =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorResponse;
            });

            return Services;
        }
    }
}
