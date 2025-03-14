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
            Log.Error(ex, "An unhandled exception has occurred."); 

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = JsonSerializer.Serialize(new
            {
                error = "An internal server error occurred."
            });

            await context.Response.WriteAsync(response);
        }
    }
}
