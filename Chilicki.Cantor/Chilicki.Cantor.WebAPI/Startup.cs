using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chilicki.Cantor.WebAPI.Controllers.Base;
using Chilicki.Cantor.WebAPI.Configurations.Cors;

namespace Chilicki.Cantor.WebAPI
{
    public class Startup
    {
        IConfiguration Configuration { get; }
        IHostingEnvironment HostingEnvironment { get; }
        MvcConfiguration MvcConfiguration { get; }
        MediatRConfiguration MediatRConfiguration { get; }
        JwtAuthenticationConfiguration JwtAuthenticationConfiguration { get; }
        AutomapperConfiguration AutomapperConfiguration { get; }
        WebApiDIConfiguration WebApiDIConfiguration { get; }
        CorsConfiguration CorsConfiguration { get; }

        public Startup(IConfiguration configuration,
            IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
            MvcConfiguration = new MvcConfiguration();
            MediatRConfiguration = new MediatRConfiguration();
            JwtAuthenticationConfiguration = new JwtAuthenticationConfiguration(configuration);
            AutomapperConfiguration = new AutomapperConfiguration();
            WebApiDIConfiguration = new WebApiDIConfiguration(configuration);
            CorsConfiguration = new CorsConfiguration();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            CorsConfiguration.Configure(services);
            MvcConfiguration.Configure(services);
            MediatRConfiguration.Configure(services);
            JwtAuthenticationConfiguration.Configure(services);
            WebApiDIConfiguration.RegisterAspWebApiDependencies(services);
            AutomapperConfiguration.ConfigureAutomapper(services);
        }        

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMiddleware(typeof(ErrorMiddlewareHandler));
            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
