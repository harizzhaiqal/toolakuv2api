using System.Web.Http;
using Microsoft.Owin;
using Owin;
using System.Configuration;
using Microsoft.az

[assembly: OwinStartup(typeof(ToolakuV2_API.App_Start.Startup))]

namespace ToolakuV2_API.App_Start
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = DebugAuthSettings.SigningKey,
                    ValidAudiences = new[] { DebugAuthSettings.ValidAudiences },
                    ValidIssuers = new[] { DebugAuthSettings.ValidIssuers },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
        }
    }
}
