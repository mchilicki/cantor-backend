using Chilicki.Cantor.Application.Configurations.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Chilicki.Cantor
{
    public class JwtAuthenticationConfiguration
    {
        readonly IConfiguration configuration;

        public JwtAuthenticationConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(IServiceCollection services)
        {
            var authenticationSettingsSection = configuration.GetSection(nameof(AuthenticationSettings));
            services.Configure<AuthenticationSettings>(authenticationSettingsSection);
            var authenticationSettings = authenticationSettingsSection.Get<AuthenticationSettings>();
            var key = Encoding.ASCII.GetBytes(authenticationSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
