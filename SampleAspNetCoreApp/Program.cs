using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SampleAspNetCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //.ConfigureServices(services =>
        //{
        //    services.AddTransient<IStartupFilter,
        //              TestMiddlewareStartupFilter>();
        //});

        public static IHostBuilder CreateHostBuilderNoStartup(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices(services =>
                {
                    //services.AddDbContext<ApplicationDbContext>(options =>
                    //options.UseSqlServer(
                    //    Configuration.GetConnectionString("DefaultConnection")));

                    //services.AddTransient < IStartupFilter, TestMiddlewareStartupFilter>();
                })
                .Configure((WebHostBuilderContext context, IApplicationBuilder app) =>
                {
                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        app.UseDeveloperExceptionPage();
                    }

                    //app.UseMiddleware<TestMiddleware>();

                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapGet("/", async context =>
                        {
                            await context.Response.WriteAsync("Hello World!");
                        });
                    });
                });
            });
    }
}
