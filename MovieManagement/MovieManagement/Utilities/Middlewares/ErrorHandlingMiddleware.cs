using Microsoft.AspNetCore.Http;
using MovieManagement.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
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
            catch (EntityAlreadyExistsException)
            {
                context.Response.Redirect("/home/alreadyexistserror");
            }
            catch (EntityInvalidException ex)
            {
                context.Response.Redirect("/home/invalid");
            }
            catch (Exception)
            {
                context.Response.Redirect("/home/servererror");
            }
        }
    }
}
