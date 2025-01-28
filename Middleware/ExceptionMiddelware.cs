using AppAPI.Errors;
using System.Net;
using System.Text.Json;

namespace AppAPI.Middleware
{
    public class ExceptionMiddelware(RequestDelegate next,ILogger<ExceptionMiddelware> logger,IHostEnvironment env)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);
                context.Response.ContentType="application/json";
                context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;

                var response = env.IsDevelopment() ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace)
                : new ApiException(context.Response.StatusCode, ex.Message, "Internal server error");

                var option=new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json=JsonSerializer.Serialize(response, option);
                await context.Response.WriteAsync(json);
            }
           
        }

    }
}
