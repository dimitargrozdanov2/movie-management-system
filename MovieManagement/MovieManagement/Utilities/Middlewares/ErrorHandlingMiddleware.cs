using Microsoft.AspNetCore.Http;
using MovieManagement.Services.Exceptions;
using System;
using System.Threading.Tasks;

namespace MovieManagement.Utilities.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context);
            }
            catch (EntityAlreadyExistsException ex)
            {
                context.Response.Redirect($"/home/alreadyexistserror?error={ex.Message}");
            }
            catch (EntityInvalidException ex)
            {
                context.Response.Redirect($"/home/invalid?error={ex.Message}");
            }
            catch (Exception ex)
            {
                context.Response.Redirect($"/home/servererror={ex.Message}");
            }
        }
    }
}