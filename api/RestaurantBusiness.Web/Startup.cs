using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantBusiness.DAL.Interfaces;
using RestaurantBusiness.DAL.Repositories;
using RestaurantBusiness.Domain.DatabaseConfiguration;
using RestaurantBusiness.Domain.Models;

namespace RestaurantBusiness.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CosmosDbSettings>(Configuration.GetSection(nameof(CosmosDbSettings)));
            services.AddTransient<IRepository<Restaurant>, RestaurantRepository>();
            services.AddCors(options =>
            {
                options.AddPolicy("Any policy", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Any policy");
            app.UseMvc();
        }
    }
}
