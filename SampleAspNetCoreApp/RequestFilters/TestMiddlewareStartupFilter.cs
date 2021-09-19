using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using SampleAspNetCoreApp.Middlewares;
using System;

namespace SampleAspNetCoreApp.RequestFilters
{
    public class TestMiddlewareStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.UseMiddleware<TestMiddleware>();
                next(builder);
            };
        }
    }
}
