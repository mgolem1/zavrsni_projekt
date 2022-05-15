using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Rental.DbModels;
using Rental.Repositories;
using Rental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        private void SetupDbContext(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("zavrsni");
            services.AddEntityFrameworkSqlServer().AddDbContext<zavrsniContext>(options => options.UseSqlServer(connString));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<LoginRepository>();
            services.AddScoped<LoginServices>();

            
            SetupDbContext(services); // ovime se omogucilo spajanje svih servisa i repozitorija na kontekst baze
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
            });
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
        public class SessionUserTimeout : ActionFilterAttribute
        {
            
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if(context.HttpContext.Session==null || !context.HttpContext.Session.TryGetValue("SessionUser",out byte[] val))
                {
                    context.Result= 
                        new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            contoller="Login",
                            action="SignIn"
                        }));
                }
                base.OnActionExecuting(context);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Prijava Korisnika",
                    pattern: "prijava/korisnik",
                    defaults: new { controller = "Login", action = "Signin" });


                endpoints.MapControllerRoute(
                    name: "Registracija korisnika",
                    pattern: "registracija/korisnik",
                    defaults: new { controller = "Login", action = "SignUpKlijent" });

            });
        }
    }
}
