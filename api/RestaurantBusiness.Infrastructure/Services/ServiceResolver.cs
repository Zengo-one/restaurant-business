using Microsoft.Extensions.DependencyInjection;

namespace RestaurantBusiness.Infrastructure.Services
{
    public static class ServiceResolver
    {
        public static void Resolve(IServiceCollection services)
        {
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
    }
}
