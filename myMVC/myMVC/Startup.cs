using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using myMVC.Data;
using myMVC.Data.Interfaces;
using myMVC.Data.Mocks;
using myMVC.Data.Models;
using myMVC.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC
{
    public class Startup
    {
        private IConfigurationRoot ConfString;

        public Startup(IWebHostEnvironment hostEnv)
        {
            ConfString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath)
                .AddJsonFile("dbsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((options) => 
            {
                options.UseSqlServer(ConfString.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAllOrders, OrderRepository>();
            services.AddScoped(sp => Cart.GetCart(sp));
            services.AddMvc().AddMvcOptions((options) => 
                options.EnableEndpointRouting = false
            );
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(endpoints => 
            {
                endpoints.MapRoute("default", "{controller = Home}/{action=Index}/{id?}");
                endpoints.MapRoute("categoryFilter", "Car/{action}/{category>}", defaults: new { Controller="Car", Action= "GetListCars" });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider
                    .GetRequiredService<AppDbContext>();
                DbObjects.Initial(context);
            }            
        }
    }
}
