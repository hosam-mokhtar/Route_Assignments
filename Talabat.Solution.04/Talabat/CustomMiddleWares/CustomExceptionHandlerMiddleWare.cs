using System.Text.Json;
using Domain.Layer.Exceptions;
using Microsoft.OpenApi.MicrosoftExtensions;
using Shared.ErrorModels;

namespace Talabat.CustomMiddleWares
{
    public class CustomExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleWare> _logger;

        public CustomExceptionHandlerMiddleWare(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);

                await HandleNotFoundEndPointAsync(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went Wrong");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            // Set Status Code for Response
            httpContext.Response.StatusCode = /*StatusCodes.Status500InternalServerError;*/ ex switch
            {

                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError

            };

            // Set Content Type for Response
            //httpContext.Response.ContentType = "application/json";

            // Create Response Object
            var response = new ErrorToReturn()
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = ex.Message

            };

            //Return Object as Json

            //var responseToReturn = JsonSerializer.Serialize(response);
            //await httpContext.Response.WriteAsync(responseToReturn);
            //or syntax
            await httpContext.Response.WriteAsJsonAsync(response);
        }

        private static async Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var response = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = $"End Point {httpContext.Request.Path} is Not Found"
                };

                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
