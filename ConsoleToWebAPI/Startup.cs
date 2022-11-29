using ConsoleToWebAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            //Dependency Injection
           /*
            services.AddControllers();
            services.AddTransient<CustomMiddleware1>();
            services.AddSingleton<IProductRepository, TestRepository>();
            services.AddScoped<IProductRepository, ProductRepository>(); 
            services.AddTransient<IProductRepository, TestRepository>();
            services.TryAddSingleton<IProductRepository, ProductRepository>();
            services.TryAddScoped<IProductRepository, ProductRepository>();
            services.TryAddTransient<IProductRepository, ProductRepository>();
           
           */

            // Without using try and if we add diff repository of same interface then it will override
            // and with using add first time it will instantiate and second time it will skip
            services.TryAddTransient<IProductRepository, TestRepository>(); 
            services.TryAddTransient<IProductRepository, ProductRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from Run");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from Use-1 1 \n");

            //    await next();

            //    await context.Response.WriteAsync("Hello from Use-1 2 \n");
            //});

            //app.UseMiddleware<CustomMiddleware1>();

            //app.Map("/nitish", CutomCode);

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from Use-3 1 \n");

            //    await next();

            //    await context.Response.WriteAsync("Hello from Use-3 2 \n");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Request complete \n");
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from Run \n");
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void CutomCode(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from nitish \n");
            });
        }
    }
}
