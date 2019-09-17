using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using KayWashApp.DataAccess;
using Unity.WebApi;
using KayWashApp.DataAccess.Repositories;
using KayWashApp.DataAccess.Model;
using Dto;
using KayWashApp.Services;

namespace KayWashApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICarDetailerService, CarDetailerService>();

            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICarDetailerRepository, CarDetailerRepository>();

            //services.AddDbContext<KayWashDbContext>(options => options.UseSqlServer(KayWashDbContext.DbConnectionString));
            //services.AddTransient<CarRepository>();
            //services.AddTransient<WasherRepository>();

            services.AddDbContext<KayWashAppContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("KayWashAppContext")));

            //ConfigureUnity();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KayWashApp API", Version = "v1" });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "KayWashApp V1");
            });


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });


            InitializeMapper();

        }

        private void InitializeMapper()
        {
            //var config = new MapperConfiguration(x =>
            //{
            //    x.CreateMap<Washer, WasherDto>();
            //    x.CreateMap<Car, CarDto>();
            //    x.CreateMap<Customer, CustomerDto>();
            //});
        }

        //private void ConfigureUnity()
        //{
        //    var container = UnityContainerSingleton.Instance.Container;

        //    Configuration.DependencyResolver = new UnityDependencyResolver(container);

        //    UnityRegistration.RegisterServices();
        //}
    }
}
