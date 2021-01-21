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
using Toolaku.Models.HR;
using Toolaku.Models.Pagingnation;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ToolakuV2_API.Controllers
{ 
        [RoutePrefix("api/HR")]
        [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
        public class ClaimController : ApiController
        {

        //--------------------------------------
        //--------------GET Method--------------
        //--------------------------------------


        [HttpGet]
        [Authorize]
        [Route("claim/personalClaimList")]
        public IHttpActionResult GetPersonalClaimList(string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ClaimBusiness.GetPersonalClaimList(ad, Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("claim/personalClaim")]
        public IHttpActionResult GetPersonalClaimDetails(int claimId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetPersonalClaimDetails(ad, Convert.ToInt32(claimId));
                return Ok(response);
            }

        }




        [HttpGet]
        [Authorize]
        [Route("claim/travelClaimList")]
        public IHttpActionResult GetTravelClaimList(string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ClaimBusiness.GetTravelClaimList(ad, Convert.ToInt32(userId),  searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("claim/travellingClaim")]
        public IHttpActionResult GetTravellingClaimDetails(int travelId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetTravellingClaimDetails(ad, Convert.ToInt32(travelId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("claim/phoneAllowanceClaimList")]
        public IHttpActionResult GetPhoneAllowanceClaimList(string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ClaimBusiness.GetPhoneAllowanceClaimList(ad, Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("claim/phoneAllowanceClaim")]
        public IHttpActionResult GetPhoneAllowanceClaimDetails(int phoneId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetPhoneAllowanceClaimDetails(ad, Convert.ToInt32(phoneId));
                return Ok(response);
            }

        }


        [HttpGet]
        [Authorize]
        [Route("claim/medicalClaimList")]
        public IHttpActionResult GetMedicalClaimList(string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ClaimBusiness.GetMedicalClaimList(ad, Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("claim/medicalClaim")]
        public IHttpActionResult GetMedicalClaimDetails(int medicalId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetMedicalClaimDetails(ad, Convert.ToInt32(medicalId));
                return Ok(response);
            }

        }


        [HttpGet]
        [Authorize]
        [Route("claim/purchaseItemClaimList")]
        public IHttpActionResult GetPurchaseItemClaimList(string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ClaimBusiness.GetPurchaseItemClaimList(ad, Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }
        }



        [HttpGet]
        [Authorize]
        [Route("claim/purchaseItemClaim")]
        public IHttpActionResult GetPurchaseItemClaimDetails(int purchaseId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetPurchaseItemClaimDetails(ad, Convert.ToInt32(purchaseId));
                return Ok(response);
            }

        }


        [HttpGet]
        [Authorize]
        [Route("claim/personalClaim/travelling")]
        public IHttpActionResult GetPersonalClaimTravellingList(int claimId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetPersonalClaimTravellingList(ad, Convert.ToInt32(claimId));
                return Ok(response);
            }

        }


        [HttpGet]
        [Authorize]
        [Route("claim/personalClaim/phone")]
        public IHttpActionResult GetPersonalClaimPhoneList(int claimId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetPersonalClaimPhoneList(ad, Convert.ToInt32(claimId));
                return Ok(response);
            }

        }


        [HttpGet]
        [Authorize]
        [Route("claim/personalClaim/medical")]
        public IHttpActionResult GetPersonalClaimMedicalList(int claimId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetPersonalClaimMedicalList(ad, Convert.ToInt32(claimId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("claim/personalClaim/purchaseItem")]
        public IHttpActionResult GetPersonalClaimPurchaseList(int claimId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetPersonalClaimPurchaseList(ad, Convert.ToInt32(claimId));
                return Ok(response);
            }

        }


        [HttpGet]
        [Authorize]
        [Route("claim/attachmentTravel")]
        public IHttpActionResult GetAttachmentTravelling(int travelId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetAttachmentTravelling(ad, Convert.ToInt32(travelId));
                return Ok(response);
            }

        }


        [HttpGet]
        [Authorize]
        [Route("claim/attachmentPhoneAllowance")]
        public IHttpActionResult GetAttachmentPhoneAllowance(int phoneId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetAttachmentPhoneAllowance(ad, Convert.ToInt32(phoneId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("claim/attachmentMedical")]
        public IHttpActionResult GetAttachmentMedical(int medicalId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetAttachmentMedical(ad, Convert.ToInt32(medicalId));
                return Ok(response);
            }

        }


        [HttpGet]
        [Authorize]
        [Route("claim/attachmentPurchaseItem")]
        public IHttpActionResult GetAttachmentPurchaseItem(int purchaseId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetAttachmentPurchaseItem(ad, Convert.ToInt32(purchaseId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("claim/waitingApprovalClaimList")]
        public IHttpActionResult GetWaitingApprovalClaimList(string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ClaimBusiness.GetWaitingApprovalClaimList(ad, Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("claim/approvedClaimList")]
        public IHttpActionResult GetApprovedClaimList(string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ClaimBusiness.GetApprovedClaimList(ad, Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("claim/claimReport")]
        public IHttpActionResult GetClaimReport(int claimId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.GetClaimReport(ad, Convert.ToInt32(claimId));
                return Ok(response);
            }

        }




        //--------------------------------------
        //--------------PUT Method--------------
        //--------------------------------------


        [HttpPut]
        [Authorize]
        [Route("claim/personalClaimUpsert")]
        public IHttpActionResult UpdatePersonalClaim(UpdatePersonalClaim updatePersonalClaim)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(updatePersonalClaim.Date))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NoContent, "Customer Date is Empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.UpdatePersonalClaim(ad, updatePersonalClaim);
                return Ok(response);
            }

        }



        [HttpPut]
        [Authorize]
        [Route("claim/travellingUpsert")]
        public IHttpActionResult UpdateTravellingClaim(UpdateTravellingClaim updateTravellingClaim)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(updateTravellingClaim.Date))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NoContent, "Customer Date is Empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.UpdateTravellingClaim(ad, updateTravellingClaim);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("claim/phoneAllowanceUpsert")]
        public IHttpActionResult UpdatePhoneAllowanceClaim(UpdatePhoneAllowanceClaim updatePhoneAllowanceClaim)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(updatePhoneAllowanceClaim.Date))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NoContent, "Customer Date is Empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.UpdatePhoneAllowanceClaim(ad, updatePhoneAllowanceClaim);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("claim/medicalClaimUpsert")]
        public IHttpActionResult UpdateMedicalClaim(UpdateMedicalClaim updateMedicalClaim)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(updateMedicalClaim.Date))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NoContent, "Customer Date is Empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.UpdateMedicalClaim(ad, updateMedicalClaim);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("claim/purchaseItemUpsert")]
        public IHttpActionResult UpdatePurchaseClaim(UpdatePurchaseClaim updatePurchaseClaim)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(updatePurchaseClaim.Date))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NoContent, "Customer Date is Empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.UpdatePurchaseClaim(ad, updatePurchaseClaim);
                return Ok(response);
            }

        }


        [HttpPut]
        [Authorize]
        [Route("claim/addApprover")]
        public IHttpActionResult ClaimAddApprover(UpdateClaimApprovers request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.UpdateClaimApprover(ad, request.ClaimId, request.UserIds);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("claim/updateClaimStatusApprove")]
        public IHttpActionResult UpdateClaimStatusApprove(UpdateClaimStatus updateClaimStatus)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ClaimBusiness.UpdateClaimStatusApprove(ad, updateClaimStatus);
                return Ok(response);
            }

        }


        [HttpPut]
        [Authorize]
        [Route("claim/updateClaimStatusReject")]
        public IHttpActionResult UpdateClaimStatusReject(UpdatePersonalClaim updatePersonalClaim)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.UpdateClaimStatusReject(ad, updatePersonalClaim);
                return Ok(response);
            }

        }






        //--------------------------------------
        //--------------POST Method--------------
        //--------------------------------------

        [HttpPost]
        [Authorize]
        [Route("claim/personalClaimUpsert")]
        public IHttpActionResult InsertPersonalClaim(InsertPersonalClaim request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertPersonalClaim(ad, request, Convert.ToInt32(userId), Convert.ToInt32(tenantId), Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }




        [HttpPost]
        [Authorize]
        [Route("claim/travellingUpsert")]
        public IHttpActionResult InsertTravellingClaim(InsertTravellingClaim request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertTravellingClaim(ad, request, Convert.ToInt32(userId), Convert.ToInt32(tenantId), Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }



        [HttpPost]
        [Authorize]
        [Route("claim/phoneAllowanceUpsert")]
        public IHttpActionResult InsertPhoneAllowanceClaim(InsertPhoneAllowanceClaim request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertPhoneAllowanceClaim(ad, request, Convert.ToInt32(userId), Convert.ToInt32(tenantId), Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("claim/medicalClaimUpsert")]
        public IHttpActionResult InsertMedicalClaim(InsertMedicalClaim request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertMedicalClaim(ad, request, Convert.ToInt32(userId), Convert.ToInt32(tenantId), Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("claim/purchaseItemUpsert")]
        public IHttpActionResult InsertPurchaseItemClaim(InsertPurchaseItemClaim request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertPurchaseItemClaim(ad, request, Convert.ToInt32(userId), Convert.ToInt32(tenantId), Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("claim/personalClaimTravellingUpsert")]
        public IHttpActionResult InsertPersonalClaimTravelling(InsertTravellingClaim request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertPersonalClaimTravelling(ad, request, Convert.ToInt32(userId), Convert.ToInt32(tenantId), Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("claim/personalClaimPhoneUpsert")]
        public IHttpActionResult InsertPersonalClaimPhone(InsertPhoneAllowanceClaim request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertPersonalClaimPhone(ad, request, Convert.ToInt32(userId), Convert.ToInt32(tenantId), Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("claim/personalClaimMedicalUpsert")]
        public IHttpActionResult InsertPersonalClaimMedical(InsertMedicalClaim request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertPersonalClaimMedical(ad, request, Convert.ToInt32(userId), Convert.ToInt32(tenantId), Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("claim/personalClaimPurchaseUpsert")]
        public IHttpActionResult InsertPersonalClaimPurchaseItem(InsertPurchaseItemClaim request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertPersonalClaimPurchaseItem(ad, request, Convert.ToInt32(userId), Convert.ToInt32(tenantId), Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("claim/attachmentTravel")]
        public IHttpActionResult InsertAttachmentTravel(InsertClaimAttachment upsert)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertAttachmentTravel(ad, upsert, Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("claim/attachmentPhoneAllowance")]
        public IHttpActionResult InsertAttachmentPhoneAllowance(InsertClaimAttachment upsert)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertAttachmentPhoneAllowance(ad, upsert, Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("claim/attachmentMedical")]
        public IHttpActionResult InsertAttachmentMedical(InsertClaimAttachment upsert)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertAttachmentMedical(ad, upsert, Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("claim/attachmentPurchaseItem")]
        public IHttpActionResult InsertAttachmentPurchaseItem(InsertClaimAttachment upsert)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var creatorUserId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ClaimBusiness.InsertAttachmentPurchaseItem(ad, upsert, Convert.ToInt32(creatorUserId));
                return Ok(response);
            }
        }





        //-----------------------------------------
        //--------------DELETE Method--------------
        //-----------------------------------------


        [HttpPut]
        [Authorize]
        [Route("personalClaim/delete")]
        public IHttpActionResult DeletePersonalClaimList(List<DeletePersonalClaim> deletePersonalClaim)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ClaimBusiness.DeletePersonalClaimList(ad, userId, tenantId, deletePersonalClaim);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("claim/deleteClaimTravel")]
        public IHttpActionResult DeleteClaim_Travellling(List<DeleteClaimItem> deleteClaimItem)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ClaimBusiness.DeleteClaim_Travelling(ad, userId, tenantId, deleteClaimItem);
                return Ok(response);
            }

        }



        [HttpPut]
        [Authorize]
        [Route("travellingClaim/delete")]
        public IHttpActionResult DeleteTravellingClaimList(List<DeleteTravellingClaim> deleteTravellingClaim)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ClaimBusiness.DeleteTravellingClaimList(ad, userId, tenantId, deleteTravellingClaim);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("medicalClaim/delete")]
        public IHttpActionResult DeleteMedicalClaimList(List<DeleteMedicalClaim> deleteMedicalClaim)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ClaimBusiness.DeleteMedicalClaimList(ad, userId, tenantId, deleteMedicalClaim);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("phoneAllowanceClaim/delete")]
        public IHttpActionResult DeletePhoneAllowanceClaimList(List<DeletePhoneAllowanceClaim> deletePhoneAllowanceClaim)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ClaimBusiness.DeletePhoneAllowanceClaimList(ad, userId, tenantId, deletePhoneAllowanceClaim);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("purchaseItemClaim/delete")]
        public IHttpActionResult DeletePurchaseItemClaimList(List<DeletePurchaseItemClaim> deletePurchaseItemClaim)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ClaimBusiness.DeletePurchaseItemClaimList(ad, userId, tenantId, deletePurchaseItemClaim);
                return Ok(response);
            }

        }


        [HttpPut]
        [Authorize]
        [Route("claim/deleteAttachmentTravelling")]
        public IHttpActionResult DeleteAttachmentTravelling(List<DeleteAttachmentClaim> ids)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ClaimBusiness.DeleteAttachmentTravelling(ad, ids);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("claim/deleteAttachmentPhone")]
        public IHttpActionResult DeleteAttachmentPhone(List<DeleteAttachmentClaim> ids)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ClaimBusiness.DeleteAttachmentPhone(ad, ids);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("claim/deleteAttachmentMedical")]
        public IHttpActionResult DeleteAttachmentMedical(List<DeleteAttachmentClaim> ids)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ClaimBusiness.DeleteAttachmentMedical(ad, ids);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("claim/deleteAttachmentPurchase")]
        public IHttpActionResult DeleteAttachmentPurchaseItem(List<DeleteAttachmentClaim> ids)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ClaimBusiness.DeleteAttachmentPurchaseItem(ad, ids);
                return Ok(response);
            }
        }



    }

}