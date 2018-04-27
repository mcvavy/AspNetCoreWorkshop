using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Workshop.Middleware
{
    public class WorkshopMiddleware
    {
        private readonly RequestDelegate _next;

        public WorkshopMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/workshop"))
                await context.Response.WriteAsync("WorkshopMiddleware");
            await _next(context);
        }
    }
}
