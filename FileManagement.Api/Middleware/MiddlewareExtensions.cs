using Microsoft.AspNetCore.Builder;

namespace FileManagement.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}