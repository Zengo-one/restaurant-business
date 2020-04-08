using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantBusiness.Infrastructure.Configuration;
using RestaurantBusiness.Infrastructure.DependencyInjection;
using RestaurantBusiness.Infrastructure.Mapper;
using RestaurantBusiness.Infrastructure.Services;

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
            ServiceConfiguration.Configure(services, Configuration);
            DependencyResolver.Resolve(services, Configuration);
            ServiceResolver.Resolve(services);
            MapperResolver.Resolve(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AppConfiguration.Configure(app);
        }
    }
}
