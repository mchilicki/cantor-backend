using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chilicki.Cantor
{
    public class WebApiDIConfiguration
    {
        readonly IConfiguration configuration;

        public WebApiDIConfiguration(
            IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void RegisterAspWebApiDependencies(IServiceCollection services)
        {            
            RegisterAspWebApiServices(services);
            services.RegisterAllDependencies(configuration);
        }

        private void RegisterAspWebApiServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }        
    }
}
