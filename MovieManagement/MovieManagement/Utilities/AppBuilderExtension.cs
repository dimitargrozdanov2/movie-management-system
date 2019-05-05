using Microsoft.AspNetCore.Builder;
using MovieManagement.Utilities.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
