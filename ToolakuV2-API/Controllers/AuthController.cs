using System.Net.Http;
using System.Web.Http;
using Toolaku.Models.Account;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace ToolakuV2_API.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("api/auth/post/")]
        public HttpResponseMessage Post(SignInRequest challenge)
        {
            // return error if password is not correct
            if (!this.IsPasswordValid(challenge.Email, challenge.Password))
            {
                return this.Request.CreateUnauthorizedResponse();
            }

            JwtSecurityToken token = this.GetAuthenticationTokenForUser(challenge.Email);

            return this.Request.CreateResponse(HttpStatusCode.OK, new
            {
                Token = token.RawData,
                Username = challenge.Email
            });
        }

        private JwtSecurityToken GetAuthenticationTokenForUser(string username)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username)
            };

            var signingKey = this.GetSigningKey();
            var audience = this.GetSiteUrl(); // audience must match the url of the site
            var issuer = this.GetSiteUrl(); // audience must match the url of the site 

            JwtSecurityToken token = AppServiceLoginHandler.CreateToken(
                claims,
                signingKey,
                audience,
                issuer,
                TimeSpan.FromHours(24)
                );

            return token;
        }

        private bool IsPasswordValid(string username, string password)
        {
            // this is where we would do checks agains a database

            return true;
        }

        private string GetSiteUrl()
        {
            var settings = this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                return DebugAuthSettings.ValidAudiences;
            }
            else
            {
                return "https://" + settings.HostName + "/";
            }
        }

        private string GetSigningKey()
        {
            var settings = this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // this key is for debuggint and testing purposes only
                // this key should match the one supplied in Startup.MobileApp.cs
                return DebugAuthSettings.SigningKey;
            }
            else
            {
                return Environment.GetEnvironmentVariable("WEBSITE_AUTH_SIGNING_KEY");
            }
        }

    }
}
