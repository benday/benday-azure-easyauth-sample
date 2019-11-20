using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benday.EasyAuthDemo.WebUi.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Benday.EasyAuthDemo.WebUi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterTypes(services);

            services.AddMvc();

            // add authentication for development purposes
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = new PathString("/Security/Login");
                        options.LogoutPath = new PathString("/Security/Logout");
                    });
            

            services.AddAuthorization(options =>
            {
                options.AddPolicy(SecurityConstants.Policy_LoggedInUsingEasyAuth,
                              policy => policy.Requirements.Add(
                                  new LoggedInUsingEasyAuthRequirement()));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // this is required to do authentication without 
            // the whole security framework stuff
            app.UseAuthentication();
            
            app.UsePopulateClaimsMiddleware();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        void RegisterTypes(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUserInformation, UserInformation>();

            services.AddTransient<ISecurityConfiguration, SecurityConfiguration>();

            services.AddTransient<PopulateClaimsMiddleware>();

            services.AddSingleton<IAuthorizationHandler, LoggedInUsingEasyAuthHandler>();
        }
    }
}
