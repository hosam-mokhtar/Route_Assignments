using System.Text.Json;
using Azure;
using Domain.Layer.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
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

            // Create Response Object
            var response = new ErrorToReturn()
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = ex.Message

            };


            // Set Status Code for Response
            httpContext.Response.StatusCode = /*StatusCodes.Status500InternalServerError;*/ ex switch
            {

                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                BadRequestException badRequestEx=> GetBadRequestErrors(badRequestEx, response),
                _ => StatusCodes.Status500InternalServerError

            };

            // Set Content Type for Response
            //httpContext.Response.ContentType = "application/json";
            response.StatusCode = httpContext.Response.StatusCode;

            //Return Object as Json

            //var responseToReturn = JsonSerializer.Serialize(response);
            //await httpContext.Response.WriteAsync(responseToReturn);
            //or syntax
            await httpContext.Response.WriteAsJsonAsync(response);
        }


        private static int GetBadRequestErrors(BadRequestException badRequestException, ErrorToReturn response)
        {
            response.Errors = badRequestException.Errors;

            return StatusCodes.Status400BadRequest;

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
