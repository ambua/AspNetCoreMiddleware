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
            await response.WriteAsync($"<h1>Hello from a custom HTTP handler.{context.Request.Host}, {DateTimeOffset.Now}</h1>");


            // Clean up.
        }
    }
}
