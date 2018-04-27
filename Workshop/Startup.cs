using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Middleware;
using Workshop.Repositories;
using Workshop.Settings;

namespace Workshop
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<BlogSettings>(_configuration.GetSection("BlogSettings"));
            services.Configure<BlogSettings>(settings => settings.Title = "New title");

            services.AddMvc();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterType<BlogRepository>().As<IBlogRepository>();
            return new AutofacServiceProvider(containerBuilder.Build());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<WorkshopMiddleware>();
            app.Map("/workshop", appBuilder => appBuilder.Run(ctx => ctx.Response.WriteAsync("MapMiddleware")));

            app.UseMvc();
        }
    }
}
