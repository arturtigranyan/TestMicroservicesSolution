using System.Net;
using System.Text.Json;
using Serilog;

namespace Test.Api.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unhandled exception occurred while processing the request.");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = JsonSerializer.Serialize(new
            {
                error = "An unexpected error occurred. Please try again later."
            });

            await context.Response.WriteAsync(response);
        }
    }
}