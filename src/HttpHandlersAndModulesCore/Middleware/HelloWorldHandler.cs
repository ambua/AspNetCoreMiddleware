using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpHandlersAndModulesCore.Middleware
{
    public class HelloWorldHandler
    {
        private readonly RequestDelegate _next;
        public HelloWorldHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Do something with context near the beginning of request processing.

            await _next.Invoke(context);

            var response = context.Response;
            await response.WriteAsync("<html>");
            await response.WriteAsync("<body>");
            await response.WriteAsync("<h1>Hello from a synchronous custom HTTP handler.</h1>");
            await response.WriteAsync("</body>");
            await response.WriteAsync("</html>");

            // Clean up.
        }
    }
}
