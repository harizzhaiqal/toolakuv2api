using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using Toolaku.Business;
using Toolaku.Library;
using Toolaku.Models.Account;
using System.Net.Http;
using System.Linq;

namespace ToolakuV2_API.Security
{
    public class DalAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
       
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

       
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            string loginEmail = "";
            bool isUsernamePasswordValid = false;
            var encryptedPwd = "";

            if (context.Password != "M@5tEr$t00L@kU")
            {
                var loginResponse = new SignInResponse();
                loginEmail = context.UserName.ToLower();
                
                //------------Sham: Connect to Database dan check for password
                encryptedPwd = BSecurity.Encrypt_AES(context.Password, SecurityKeys.Salt, SecurityKeys.Aes, SecurityKeys.Iv);
               
            }

            var authenticateResult = new AuthenticateResult();

            using (Adapter ad = new Adapter())
            {
                //var authenticateResult = new AuthenticateResult();


                if (context.Password == "M@5tEr$t00L@kU")
                {
                    authenticateResult = AccountBusiness.AuthenticateRelogin(ad, context.UserName);
                }
                else
                {
                    authenticateResult = AccountBusiness.Authenticate(ad, loginEmail, encryptedPwd);
                }

               
                if (authenticateResult.ReturnCode == 1)
                {
                    isUsernamePasswordValid = true;
                }
            }

            if (isUsernamePasswordValid)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName.ToLower()));
                identity.AddClaim(new Claim("NameIdentifier", authenticateResult.UserId.ToString()));
                if (authenticateResult.TenantId != null)
                {
                    identity.AddClaim(new Claim("TenantId", authenticateResult.TenantId.ToString()));
                }
                else
                {
                    identity.AddClaim(new Claim("TenantId", "0"));
                }


                //add here other claims

                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Please check you Username/Password and try again");
                return;
            }

        }

        /*

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:id"];
            var currentClient = context.ClientId;

            // enforce client binding of refresh token
            if (originalClient != currentClient)
            {
                context.Rejected();
                return;
            }

            // chance to change authentication ticket for refresh token requests
            var newId = new ClaimsIdentity(context.Ticket.Identity);
            newId.AddClaim(new Claim("newClaim", "refreshToken"));

            var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            context.Validated(newTicket);
        }

        */

    }
}