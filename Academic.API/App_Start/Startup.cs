using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TokenBasedAuthentication.Providers;

[assembly: OwinStartup(typeof(Academic.API.App_Start.Startup))]

namespace Academic.API.App_Start
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/v1/token"),
                Provider = new OAuthCustomeTokenProvider(), // We will create
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                AllowInsecureHttp = true,
                RefreshTokenProvider = new OAuthCustomRefreshTokenProvider() // We will create

            };

            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
