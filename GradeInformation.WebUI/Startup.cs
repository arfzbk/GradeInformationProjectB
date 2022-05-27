using GradeInformation.Business.Abstract;
using GradeInformation.Business.Concrete;
using GradeInformation.DataAccess.Abstract;
using GradeInformation.DataAccess.Concrete.EntityFramework;
using GradeInformation.DataAccess.Concrete.Identity;
using GradeInformation.WebUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeInformation.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            ServiceExtensions.ConfigureServices(ref services);
            
            services.AddMvc(p => p.EnableEndpointRouting = false);

            services.AddDbContext<AppIdentityDbContext>();

            services.AddIdentity<AppIdentityUser, AppIdentityRole>().
                AddEntityFrameworkStores<AppIdentityDbContext>().
                AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
               
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;
            });

            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/Security/Login";
                options.LogoutPath = "/Security/Logout";
                options.AccessDeniedPath = "/Security/AccessDenied";
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".AspNetCore.Security.Cookie",
                    Path = "/",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };

            });
            services.AddAuthentication();
            services.AddSession();
            services.AddDistributedMemoryCache();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseStaticFiles();
           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes => routes.MapRoute(name:"Default" , template:"{controller=home}/{action=index}/{id?}"));
            
            app.UseHttpsRedirection();
           
            app.UseRouting();
           

        }
    }
}
