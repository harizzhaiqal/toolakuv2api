using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using Toolaku.Business;
using Toolaku.Library;
using Toolaku.Models;
using Toolaku.Models.DTO;
using Toolaku.Models.Admin;
using Toolaku.Models.Pagingnation;
using Toolaku.Models.Account;
using ToolakuV2_API.Security;

namespace ToolakuV2_API.Controllers
{
    [RoutePrefix("api/Admin")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class AdminController : ApiController
    {
        //--------------------------------------
        //--------------GET Method--------------
        //--------------------------------------
            

        [HttpGet]
        [Authorize]
        [Route("tenant/management/list")]
        public IHttpActionResult GetTenantManagementList(string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = AdminBusiness.GetTenantManagementList(ad, searchKey, page);
                return Ok(response);
            }
        }

        
        [HttpGet]
        [Authorize]
        [Route("notification/count")]
        public IHttpActionResult GetNotificationCount()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
               
                var response = AdminBusiness.GetNotificationCount(ad, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("notification/list")]
        public IHttpActionResult GetNotificationList()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = AdminBusiness.GetNotificationList(ad, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        //--------------------------------------
        //--------------PUT Method--------------
        //--------------------------------------

        /*
        [HttpPut]
        [AllowAnonymous]
        [Route("emailRecovery")]
        public IHttpActionResult PushEmailRecoveryPassword(string emailTo)
        {
            //using (Adapter ad = new Adapter())
            //{
                var response = AdminBusiness.PushEmailRecoveryPassword(emailTo);
                return Ok(response);
            //}
        }
        */



        public string RandomString(int size)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
           
            return builder.ToString();
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("password/recovery")]
        public IHttpActionResult PushEmailRecoveryPassword(RecoverPasswordUsername request)
        {
            //default password
            var newDefaultPassword = RandomString(6);
            var encryptedPwd = BSecurity.Encrypt_AES(newDefaultPassword, SecurityKeys.Salt, SecurityKeys.Aes, SecurityKeys.Iv);
            var mailBody = "For recovery, your password for username <strong>"+ request.emailTo + "</strong> is changed to <strong>" + newDefaultPassword + "</strong>. " +
                "For security reason, please login and change to a new password.";

            using (Adapter ad = new Adapter())
            {
                var response = AdminBusiness.PushEmailRecoveryPassword(ad, request.emailTo, "Toolaku Password Recovery", mailBody, encryptedPwd);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("notification")]
        public IHttpActionResult UpdateNotificationClose(NotificationUpdate request)
        {
            using (Adapter ad = new Adapter())
            {
                var response = AdminBusiness.UpdateNotificationClose(ad, request);
                return Ok(response);
            }
        }

        //--------------------------------------
        //--------------POST Method--------------
        //--------------------------------------

        [HttpPost]
        [Authorize]
        [Route("notification")]
        public IHttpActionResult InsertNotificationByTenant(NotificationInsert request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            request.CreatorUserId = Convert.ToInt32(userId);
            using (Adapter ad = new Adapter())
            {
                var response = AdminBusiness.InsertNotificationByTenant(ad, request);
                return Ok(response);
            }
        }

        //--------------------------------------
        //--------------DELETE Method--------------
        //--------------------------------------


    }
}
