using Microsoft.AspNetCore.Builder;
using MovieManagement.Utilities.Middlewares;

namespace MovieManagement.Utilities
{
    public static class AppBuilderExtension
    {
        public static void CustomExceptionHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}