using BookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:BookStoreConnection"]); //Establish connection string for where to connect to database
            });

            services.AddScoped<IBookRepository, EFBookRepository>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints =>
                {
                    //Adjust the endpoints to be more user friendly      
                    endpoints.MapControllerRoute(                                   //User can type /category/P(page) to navigate to a specific page of the category
                        "catpage",
                        "{category}/P{page:int}",
                        new { Controller = "Home", action = "Index" });

                    endpoints.MapControllerRoute(                                   //User can type /category in URL to filter by category
                        "category",
                        "{category}",
                        new { Controller = "Home", action = "Index", page = 1 });

                    endpoints.MapControllerRoute(                                   //user can type /P and the page to navigate to in the URL
                        "pagination",
                        "AllBooks/P{page:int}",
                        new { Controller = "Home", action = "Index" });

                    endpoints.MapDefaultControllerRoute();
                });

            });

            SeedData.EnsurePopulated(app); //When app starts, it will call the EnsurePopulated function that will insert data into the database if there is none
        }
    }
}
