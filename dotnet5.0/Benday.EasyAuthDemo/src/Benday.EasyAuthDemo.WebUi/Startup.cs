using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Benday.EasyAuthDemo.WebUi.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Benday.EasyAuthDemo.Api.DataAccess;
using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.Api.ServiceLayers;
using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EfCore.SqlServer;
using Benday.EasyAuthDemo.Api.DataAccess.SqlServer;
using Benday.EasyAuthDemo.Api.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDatabaseDeveloperPageExceptionFilter();

            RegisterTypes(services);

            ConfigureAuthentication(services);
            ConfigureAuthorization(services);
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = new PathString("/Security/Login");
                        options.LogoutPath = new PathString("/Security/Logout");
                    });
        }

        private void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, LoggedInUsingEasyAuthHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(SecurityConstants.Policy_LoggedInUsingEasyAuth,
                                policy => policy.Requirements.Add(
                                    new LoggedInUsingEasyAuthRequirement()));

                options.DefaultPolicy = options.GetPolicy(SecurityConstants.Policy_LoggedInUsingEasyAuth);
            });
        }

        private void RegisterTypes(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<PopulateClaimsMiddleware>();
            services.AddTransient<ISecurityConfiguration, SecurityConfiguration>();
            services.AddTransient<IUserInformation, UserInformation>();
            services.AddTransient<IUsernameProvider, UserInformation>();
            //services.AddTransient<IUsernameProvider, HttpContextUsernameProvider>();

            services.AddSingleton<IAuthorizationHandler, LoggedInUsingEasyAuthHandler>();


            services.AddDbContext<EasyAuthDemoDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("default")));

            services.AddTransient<IEasyAuthDemoDbContext, EasyAuthDemoDbContext>();

            services.AddTransient<ISearchStringParserStrategy, DefaultSearchStringParserStrategy>();

            // service layers
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IServiceLayer<Benday.EasyAuthDemo.Api.DomainModels.Person>, PersonService>();
            services.AddTransient<ILookupService, LookupService>();
            services.AddTransient<IServiceLayer<Benday.EasyAuthDemo.Api.DomainModels.Lookup>, LookupService>();


            // validators
            services.AddTransient<
                IValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.Person>,
                DefaultValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.Person>>();
            services.AddTransient<
                IValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.PersonEditorViewModel>,
                DefaultValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.PersonEditorViewModel>>();
            services.AddTransient<
                IValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.Lookup>,
                DefaultValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.Lookup>>();
            services.AddTransient<
                IValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.LookupEditorViewModel>,
                DefaultValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.LookupEditorViewModel>>();


            // repositories
            services.AddTransient<ISearchableRepository<Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity>, SqlEntityFrameworkPersonRepository>();
            services.AddTransient<
                Benday.EasyAuthDemo.Api.DataAccess.SqlServer.ILookupRepository,
                SqlEntityFrameworkLookupRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UsePopulateClaimsMiddleware();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
