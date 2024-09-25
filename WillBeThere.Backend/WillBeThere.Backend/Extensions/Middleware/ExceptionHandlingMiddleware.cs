using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WillBeThere.Backend.Extensions.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            // Itt különböző kivételeket különböző státuszkódokkal kezelhetsz
            if (exception is ArgumentNullException)
            {

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Invalid input provided.",
                    //Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"
                };

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                // return context.Response.WriteAsync("Invalid input provided.");
                return context.Response.WriteAsJsonAsync(problemDetails);
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync("An unexpected error occurred.");
        }
    }
}
