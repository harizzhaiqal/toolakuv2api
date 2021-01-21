using System;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using ToolakuV2_API.Security;

[assembly: OwinStartup(typeof(ToolakuV2_API.Startup))]

namespace ToolakuV2_API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/tenant/auth"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(5),
                Provider = new DalAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();


            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
