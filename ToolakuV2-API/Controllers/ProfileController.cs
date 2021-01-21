using System.Web.Http;
using Toolaku.Library;
using Toolaku.Models.Account;
using Toolaku.Business;
using Toolaku.Models.Profile;
using Toolaku.Models.DTO;
using System.Web.Http.Cors;
using System.Security.Claims;
using System;
using System.Net.Http;
using System.Linq;
using ToolakuV2_API.Security;
using System.Collections.Generic;
using System.Net;
using Toolaku.Models.Pagingnation;

namespace ToolakuAPI.Controllers
{
    [RoutePrefix("api/profile")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ProfileController : ApiController
    {
        //--------------------------------------
        //--------------GET Method--------------
        //--------------------------------------

        [HttpGet]
        [Authorize]
        [Route("general")]
        public IHttpActionResult GetProfileGeneralInfo()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new GeneralInfoResponse();

                response = ProfileBusiness.GetProfileGeneralInfo(ad, userId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("edition")]
        public IHttpActionResult GetTenantEditionInfo(int TenantId)
        {
           
            using (Adapter ad = new Adapter())
            {
                var response = new TenantEditionInfoResponse();
                response = ProfileBusiness.GetTenantEditionInfo(ad, TenantId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("contact")]
        public IHttpActionResult GetProfileContact()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetProfileContact(ad, userId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("shareholder")]
        public IHttpActionResult GetProfileShareHolder()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetProfileShareHolder(ad, userId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("employee")]
        public IHttpActionResult GetProfileEmployee(string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ProfileBusiness.GetProfileEmployee(ad, tenantId, searchKey, page);
                return Ok(response);
            }

        }
        //before pagingnation
        /*
        public IHttpActionResult GetProfileEmployee()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetProfileEmployee(ad, userId);
                return Ok(response);
            }

        }
        */

        [HttpGet]
        [Authorize]
        [Route("user/setting")]
        public IHttpActionResult GetUserSetting()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetUserSetting(ad, userId);
                return Ok(response);
            }

        }

        //--------------Tenant Branch --------------
        [HttpGet]
        [Authorize]
        [Route("branch/list")]
        public IHttpActionResult GetBranchList()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId =="")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "There is no branch list. Please save General Info first";

                return Ok(responsenull);
            }

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetBranchList(ad, tenantId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("branch/detail")]
        public IHttpActionResult GetBranchDetail(int branchId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "There is no branch list. Please save General Info first";

                return Ok(responsenull);
            }

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetBranchDetail(ad, branchId);
                return Ok(response);
            }
        }

        //--------------Tenant Agency --------------
        [HttpGet]
        [Authorize]
        [Route("agency/list")]
        public IHttpActionResult GetCorporateList()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "There is no corporate registration list. Please save General Info first";

                return Ok(responsenull);
            }

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetCorporateList(ad, Convert.ToInt32(tenantId));
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("agency/detail")]
        public IHttpActionResult GetCorporateDetail(int tenantAgencyId )
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "There is no branch list. Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetCorporateDetail(ad, tenantAgencyId);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("agency/code")]
        public IHttpActionResult GetAgencyCode(int tenantAgencyId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetAgencyCode(ad, tenantAgencyId);
                return Ok(response);
            }
        }

        //--------------Tenant Certificate --------------
        [HttpGet]
        [Authorize]
        [Route("certification/list")]
        public IHttpActionResult GetTenantCertificate()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetTenantCertificate(ad, Convert.ToInt32(tenantId));
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("certification/detail")]
        public IHttpActionResult GetTenantCertificateDetail(int tenantCertificationId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetTenantCertificateDetail(ad, tenantCertificationId);
                return Ok(response);
            }
        }

        //--------------Tenant Award --------------
        [HttpGet]
        [Authorize]
        [Route("award/list")]
        public IHttpActionResult GetTenantAward()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetTenantAward(ad,Convert.ToInt32(tenantId));
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("award/detail")]
        public IHttpActionResult GetTenantAwardDetail(int tenantAwardId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetTenantAwardDetail(ad, tenantAwardId);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("user/list")]
        public IHttpActionResult GetTenantUserList(string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            var response2 = new RegisterResponse();

            if (string.IsNullOrWhiteSpace(tenantId))
            {
                response2.ReturnCode = -4;
                response2.ResponseMessage = "Please fill in all information in Profile first";
                return Ok(response2);
            }

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ProfileBusiness.GetTenantUserList(ad, Convert.ToInt32(tenantId), searchKey, page);
                return Ok(response);
            }
        }

        //before pagingnation
        /*
        public IHttpActionResult GetTenantUserList()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetTenantUserList(ad, Convert.ToInt32(tenantId));
                return Ok(response);
            }
        }
        */

        [HttpGet]
        [Authorize]
        [Route("role/list")]
        public IHttpActionResult GetTenantRoleList(string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ProfileBusiness.GetTenantRoleList(ad, Convert.ToInt32(tenantId), searchKey, page);
                return Ok(response);
            }
        }
        /*
        public IHttpActionResult GetTenantRoleList()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetTenantRoleList(ad, Convert.ToInt32(tenantId));
                return Ok(response);
            }
        }*/

        [HttpGet]
        [Authorize]
        [Route("user/detail")]
        public IHttpActionResult GetTenantUserDetail(int userId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetTenantUserDetail(ad, userId);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("role/detail")]
        public IHttpActionResult GetTenantRoleDetail(int roleId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetTenantRoleDetail(ad, roleId);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("tenant/role")]
        public IHttpActionResult GetTenantRoleReference()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetTenantRoleReference(ad, Convert.ToInt32(tenantId));
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("tenant/module")]
        public IHttpActionResult GetTenantModuleReference()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.GetTenantModuleReference(ad, Convert.ToInt32(tenantId));
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("userDepartmentRole/list")]
        public IHttpActionResult GetUserDepartmentRoleList(int userRoleId, string searchKey = null, int RowsPerPage = 0,
       int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ProfileBusiness.GetUserDepartmentRoleList(ad, userRoleId, searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("userDepartmentRole/details")]
        public IHttpActionResult GetDepartmentRoleDetails(int id)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetDepartmentRoleDetails(ad, id);
                return Ok(response);
            }
        }



        //--------------------------------------
        //--------------PUT Method--------------
        //--------------------------------------
        [HttpPut]
        [Authorize]
        [Route("general")]
        public IHttpActionResult UpdateGeneralInfo(GeneralInfoRequest generalInfo)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            var response = new BasicApiResponse();

            if (string.IsNullOrWhiteSpace(generalInfo.CompanyName))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Company Name is empty"));
            }

            if (string.IsNullOrWhiteSpace(generalInfo.BRNo))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Registration No is empty"));
            }

            if (generalInfo.DateIncorporated == "0001-01-02T02:58:14.000Z")
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Date is empty"));
            }

            if (generalInfo.CountryId == "0")
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Country is empty"));
            }

            if (string.IsNullOrWhiteSpace(generalInfo.Address1))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Registered Address is empty"));
            }

            if (string.IsNullOrWhiteSpace(generalInfo.Postcode))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Poscode is empty"));
            }

            if (generalInfo.StateId == "0")
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "State is empty"));
            }
            /*
            if (generalInfo.CityId == "0")
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "City is empty"));
            }
            */
            if (string.IsNullOrWhiteSpace(generalInfo.City))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "City is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                response = ProfileBusiness.UpdateGeneralInfo(ad, userId, generalInfo);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("contact")]
        public IHttpActionResult UpdateContactInfo(ProfileContactRequest profileContact)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateContactInfo(ad, userId, profileContact);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("edition")]
        public IHttpActionResult UpdateTenantEdition(TenantEditionInfoUpsert edition)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateTenantEdition(ad, edition);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("shareholder")]
        public IHttpActionResult UpdateProfileShareHolder(ProfileShareholder profileShareholder)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateProfileShareholder(ad, userId, profileShareholder);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("employee")]
        public IHttpActionResult UpdateProfileEmployee(ProfileEmployee profileEmployee)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateProfileEmployee(ad, userId, profileEmployee);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("branch")]
        public IHttpActionResult UpdateTenantBranch(TenantBranch tenantBranch)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateTenantBranch(ad, userId, tenantBranch);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("agency/code")]
        public IHttpActionResult DeleteAgencyCode(CodeToRemoves codeToRemoves)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.DeleteAgencyCode(ad, userId, codeToRemoves);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("certificate/detail")]
        public IHttpActionResult UpdateTenantCertificateDetail(TenantCertificateUpdate tenantCertificateUpdate)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateTenantCertificateDetail(ad, tenantCertificateUpdate);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("award/detail")]
        public IHttpActionResult UpdateTenantAwardDetail(TenantAwardUpdate tenantAwardUpdate)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateTenantAwardDetail(ad, tenantAwardUpdate);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("user/list")]
        public IHttpActionResult DeleteTenantUserDetail(List<UserIdToRemove> userIdToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.DeleteTenantUserDetail(ad, userIdToRemove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("role/list")]
        public IHttpActionResult DeleteTenantRoleDetail(List<RoleToRemove> roleToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.DeleteTenantRoleDetail(ad, roleToRemove);
                return Ok(response);
            }

        }

        

        //--------------MyUsers --------------
        [HttpPut]
        [Authorize]
        [Route("user/detail")]
        public IHttpActionResult UpdateTenantUser(UserDetail userDetail)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            var encryptedPwd = BSecurity.Encrypt_AES(userDetail.Password, SecurityKeys.Salt, SecurityKeys.Aes, SecurityKeys.Iv);

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateTenantUser(ad, Convert.ToInt32(tenantId), userDetail.Password.Trim() != "" ? encryptedPwd : "", userDetail);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("role/detail")]
        public IHttpActionResult UpdateTenantRole(TenantRole tenantRole)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateTenantRole(ad, Convert.ToInt32(tenantId), tenantRole);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("corporate/detail")]
        public IHttpActionResult UpdateCorporateDetail(CorporateRegistrationUpdate corporateDetail)
        {

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateCorporateDetail(ad,corporateDetail);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("userDepartmentRole")]
        public IHttpActionResult UpdateUserDepartmentRole(UpdateUserDepartmentRole request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateUserDepartmentRole(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        //---------------------------------------
        //--------------POST Method--------------
        //---------------------------------------
        [HttpPost]
        [Authorize]
        [Route("employee")]
        public IHttpActionResult InsertProfileEmployee(ProfileEmployeeNew profileEmployee)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.InsertProfileEmployee(ad, userId, profileEmployee);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("branch")]
        public IHttpActionResult InsertTenantBranch(TenantBranchRequest tenantBranch)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.InsertTenantBranch(ad, userId, tenantId, tenantBranch);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("corporate/detail")]
        public IHttpActionResult InsertCorporateDetail(CorporateRegistration corporateDetail)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.InsertCorporateDetail(ad, tenantId, corporateDetail);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("corporate/code")]
        public IHttpActionResult InsertCorporateCode(AgencyCodeInsert agencyCodeInsert)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.InsertCorporateCode(ad, tenantId, agencyCodeInsert);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("user/setting")]
        public IHttpActionResult UpdateUserSetting(UserSetting userSetting)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.UpdateUserSetting(ad, Convert.ToInt32(userId), userSetting);
                return Ok(response);
            }

        }

        //--------------Tenant Certficate --------------

        [HttpPost]
        [Authorize]
        [Route("certificate/detail")]
        public IHttpActionResult InsertCertificateDetail(TenantCertificateNew tenantCertificateNew)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.InsertCertificateDetail(ad, Convert.ToInt32(tenantId), tenantCertificateNew);
                return Ok(response);
            }

        }

        //--------------Tenant Award --------------
        [HttpPost]
        [Authorize]
        [Route("award/detail")]
        public IHttpActionResult InsertAwardDetail(TenantAwardNew tenantAwardNew)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.InsertAwardDetail(ad, Convert.ToInt32(tenantId), tenantAwardNew);
                return Ok(response);
            }

        }

        //--------------MyUsers --------------
        [HttpPost]
        [Authorize]
        [Route("user/detail")]
        public IHttpActionResult InsertTenantUser(UserDetailNew userDetailNew)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            if (userDetailNew.Password == null)
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "No Password provided. Please input password";

                return Ok(responsenull);
            }

            if (userDetailNew.Username.Trim() == "" || userDetailNew.Username == null)
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "No Email provided. Please input email";

                return Ok(responsenull);
            }

            var encryptedPwd = BSecurity.Encrypt_AES(userDetailNew.Password, SecurityKeys.Salt, SecurityKeys.Aes, SecurityKeys.Iv);

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.InsertTenantUser(ad, Convert.ToInt32(tenantId), encryptedPwd, userDetailNew);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("role/detail")]
        public IHttpActionResult InsertTenantRole(TenantRoleNew tenantRoleNew)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            if (tenantId == "")
            {
                var responsenull = new BasicApiResponse();
                responsenull.ReturnCode = 204;
                responsenull.ResponseMessage = "Please save General Info first";

                return Ok(responsenull);
            }
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.InsertTenantRole(ad, Convert.ToInt32(tenantId), tenantRoleNew);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("userDepartmentRole")]
        public IHttpActionResult InsertUserDepartmentRole(InsertUserDepartmentRole request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.InsertUserDepartmentRole(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }





        //-----------------------------------------
        //--------------DELETE Method--------------
        //-----------------------------------------
        [HttpDelete]
        [Authorize]
        [Route("employee/delete")]
        public IHttpActionResult DeleteProfileEmployee(int tenantEmployeeId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.DeleteProfileEmployee(ad, userId, tenantEmployeeId);
                return Ok(response);
            }

        }

        [HttpDelete]
        [Authorize]
        [Route("branch")]
        public IHttpActionResult DeleteTenantBranch(int tenantBranchId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.DeleteTenantBranch(ad, userId, tenantBranchId);
                return Ok(response);
            }

        }

        [HttpDelete]
        [Authorize]
        [Route("agency/list")]
        public IHttpActionResult DeleteCorporateRegistration(int tenantAgencyId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.DeleteCorporateRegistration(ad, userId, tenantAgencyId);
                return Ok(response);
            }

        }

        [HttpDelete]
        [Authorize]
        [Route("certification/list")]
        public IHttpActionResult DeleteTenantCertification(int tenantCertificationId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.DeleteTenantCertification(ad, tenantCertificationId);
                return Ok(response);
            }

        }

        [HttpDelete]
        [Authorize]
        [Route("award/list")]
        public IHttpActionResult DeleteTenantAward(int tenantAwardId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.DeleteTenantAward(ad, tenantAwardId);
                return Ok(response);
            }

        }


        [HttpPut]
        [Authorize]
        [Route("userDepartmentRole/delete")]
        public IHttpActionResult DeleteUserDepartmentRole(List<ProfileListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProfileBusiness.DeleteUserDepartmentRole(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }



    }
}