using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor
{
    public static class WebApiDIConfiguration
    {
        public static void RegisterAspWebApiDependencies(this IServiceCollection services, IConfiguration configuration)
        {            
            services.RegisterAspWebApiServices();
            services.RegisterAllDependencies(configuration);
        }

        private static void RegisterAspWebApiServices(this IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }        
    }
}
