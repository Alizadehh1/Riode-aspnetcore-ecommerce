using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Riode.Core.Providers;
using Riode.Data.DataContexts;
using Riode.Data.Entities;
using Riode.Data.Entities.Membership;
using System;

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

            services.AddIdentity<RiodeUser, RiodeRole>()
                .AddEntityFrameworkStores<RiodeDbContext>();

            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                //cfg.Password.RequiredUniqueChars = 1;
                cfg.Password.RequiredLength = 3;

                cfg.User.RequireUniqueEmail = true;

                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 3, 0);
            });

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/signin.html";
                cfg.AccessDeniedPath = "/accessdenied.html";

                cfg.ExpireTimeSpan = new TimeSpan(0, 5, 0);
                cfg.Cookie.Name = "Riode";
            });

            services.AddMediatR(this.GetType().Assembly);
            
            services.AddFluentValidation(cfg =>
            {
                cfg.RegisterValidatorsFromAssemblies(new[] { this.GetType().Assembly });
            });
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

                cfg.MapControllerRoute(name: "default-accessdenied", pattern: "accessdenied.html", defaults: new
                {
                    area = "",
                    controller = "account",
                    action = "accessdenied"
                });

                cfg.MapControllerRoute(name:"default-signin",pattern:"signin.html",defaults:new
                {
                    area="",
                    controller="account",
                    action="signin"
                });

                cfg.MapAreaControllerRoute(
                    name: "defaultAdmin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");
                cfg.MapControllerRoute("default",pattern:"{controller=home}/{action=index}/{id?}");

            });

        }
    }
}
