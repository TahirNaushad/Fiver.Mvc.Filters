using Fiver.Mvc.Filters.Filters;
using Fiver.Mvc.Filters.Models.Home;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Fiver.Mvc.Filters
{
    public class Startup
    {
        public void ConfigureServices
            (IServiceCollection services)
        {
            services.AddScoped<IGreetingService, GreetingService>();

            services.AddScoped<GreetingServiceFilter>();
            
            services.AddMvc(options =>
            {
                options.Filters.Add(new AddDeveloperResultFilter("Tahir Naushad")); // instance
                options.Filters.Add(typeof(GreetDeveloperResultFilter)); // type
            });
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
