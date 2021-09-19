using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAspNetCoreApp.Middlewares
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Test with https://localhost:5001?parameter=SomeValue
        public async Task Invoke(HttpContext httpContext)
        {
            var parameter = httpContext.Request.Query["parameter"];

            // какая то функциональность для переменной parameter

            await _next(httpContext);
        }
    }
}
