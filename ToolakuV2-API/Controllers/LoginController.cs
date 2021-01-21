using System.Net.Http;
using System.Web.Http;
using Toolaku.Models.Account;
using Toolaku.Library;
using Toolaku.Business;
using ToolakuV2_API.Security;
using System;
using System.Security.Claims;
using System.Web.Http.Cors;
using System.Linq;

namespace ToolakuV2_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        [Route("tenant/register")]
        public IHttpActionResult Register([FromBody] SignUpRequest signUp)
        {
            var response = new RegisterResponse();
            try
            {
                if (string.IsNullOrWhiteSpace(signUp.Email))
                {
                    response.ReturnCode = -1;
                    response.ResponseMessage = "Email is empty";
                    return Ok(response);
                }

                if (string.IsNullOrWhiteSpace(signUp.Name))
                {
                    response.ReturnCode = -2;
                    response.ResponseMessage = "Name is empty";
                    return Ok(response);
                }

                if (string.IsNullOrWhiteSpace(signUp.MobileNo))
                {
                    response.ReturnCode = -3;
                    response.ResponseMessage = "Mobile Number is empty.";
                    return Ok(response);
                }

                if (string.IsNullOrWhiteSpace(signUp.Password))
                {
                    response.ReturnCode = -4;
                    response.ResponseMessage = "Password is empty";
                    return Ok(response);
                }

                //------ execute db call
                var encryptedPwd = BSecurity.Encrypt_AES(signUp.Password, SecurityKeys.Salt, SecurityKeys.Aes, SecurityKeys.Iv);

                using (Adapter ad = new Adapter())
                {
                    response = AccountBusiness.Register(ad, signUp, encryptedPwd);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("userdetail")]
        public IHttpActionResult UserDetail()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userIdClaim = Convert.ToInt32(principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value);

            //get user detail using username
            using (Adapter ad = new Adapter())
            {
                var response = AccountBusiness.GetLoginDetail(ad, userIdClaim);
                return Ok(response);
            }         
        }

        [HttpGet]
        [Authorize]
        [Route("module")]
        public IHttpActionResult GetUserModules()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userIdClaim = Convert.ToInt32(principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value);

            using (Adapter ad = new Adapter())
            {
                var response = new UserModules();

                response = AccountBusiness.GetUserModules(ad, userIdClaim);
                return Ok(response);
            }
        }

        //--------------PUT Method--------------
        [HttpPut]
        [Authorize]
        [Route("password/change")]
        public IHttpActionResult ChangePassword(ChangePasswordRequest request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            //------ execute db call
            var encryptedPwd = BSecurity.Encrypt_AES(request.NewPassword, SecurityKeys.Salt, SecurityKeys.Aes, SecurityKeys.Iv);

            using (Adapter ad = new Adapter())
            {
                var response = AccountBusiness.ChangePassword(ad, Convert.ToInt32(userId), encryptedPwd);
                return Ok(response);
            }
        }
    }
}
