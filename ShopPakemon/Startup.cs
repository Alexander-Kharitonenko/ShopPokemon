using AutoMapper;
using EntityForDatabase;
using EntityForDatabase.Entity;
using IRepositoryServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepositoryServises;
using ShopPakemon.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopPakemon
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
            services.AddDbContext<DbContextShopPakemon>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddControllersWithViews();

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = FacebookDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddFacebook(facebookOptions =>
            {

                facebookOptions.ClientId = Configuration["Facebook:ID"];
                facebookOptions.ClientSecret = Configuration["Facebook:Secret"];

            }).AddCookie();

            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping()); 
            });
            IMapper mapper = mappingConfig.CreateMapper(); 

            services.AddSingleton(mapper); 
        }

       
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

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
