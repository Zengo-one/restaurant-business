using Microsoft.AspNetCore.Builder;

namespace RestaurantBusiness.Infrastructure.Configuration
{
    public static class AppConfiguration
    {
        public static void Configure(IApplicationBuilder app)
        {
            app.UseCors("Any policy");
            app.UseMvc();
        }
    }
}
