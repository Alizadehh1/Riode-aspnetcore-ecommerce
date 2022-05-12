using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Riode.WebUI.AppCode.Providers;
using Riode.WebUI.Models.DataContexts;

namespace Riode.WebUI
{
    public class Startup
    {
        readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(cfg=>
            {
                cfg.ModelBinderProviders.Insert(0, new BooleanBinderProvider());
            });

            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });

            services.AddDbContext<RiodeDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("cString"));
            });

            services.AddMediatR(this.GetType().Assembly);
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.InitDb();

            app.UseEndpoints(cfg =>{
                cfg.MapAreaControllerRoute(
                    name: "defaultAdmin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");
                cfg.MapControllerRoute("default",pattern:"{controller=home}/{action=index}/{id?}");

            });

        }
    }
}
