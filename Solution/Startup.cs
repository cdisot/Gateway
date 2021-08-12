
using App.Service;
using CC.Core.DataPersistent;
using CC.Core.Mapping;
using CC.Core.Repositories;
using Domain.Core.CoreData;
using Domain.Core.Interface;
using Domain.Core.Mapping;
using Domain.Core.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.AutoMapper;
using System.Collections.Generic;

namespace Solution
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
            

            AutoMapperConfig.RegisterMapping();

            services.AddScoped<IStatus, Status>();
            services.AddScoped<IDevice, Device>();
            services.AddScoped<IGateway, Gateway>();

          
           
            services.AddScoped<IServiceApp, ServicesApp>();
            
            services.AddScoped<IGatewayRepository, GatewayRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IMapper, AutoMapperAdapter>();  
            AutoMapperConfig.RegisterMapping();


             services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataBaseConnection")));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
