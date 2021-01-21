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
using Toolaku.Models.Product;
using Toolaku.Models.Service;
using Toolaku.Models.Services;
using Toolaku.Models.Pagingnation;

namespace ToolakuV2_API.Controllers
{
    [RoutePrefix("api/service")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ServicesController : ApiController
    {
        //--------------------------------------
        //--------------GET Method--------------
        //--------------------------------------

        [HttpGet]
        [Authorize]
        [Route("list")]
        /*
        public IHttpActionResult GetServiceList()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.GetServiceList(ad, Convert.ToInt32(tenantId));
                return Ok(response);
            }

        }
        */

        public IHttpActionResult GetServiceList(string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
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
                var response = ServicesBusiness.GetServiceList(ad, Convert.ToInt32(tenantId), searchKey, page);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("general")]
        public IHttpActionResult GetServiceGeneralInfo(int serviceId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.GetServiceGeneralInfo(ad, serviceId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("category")]
        public IHttpActionResult GetServiceCategory(int serviceId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.GetServiceCategory(ad, serviceId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("description")]
        public IHttpActionResult GetServiceDescription(int serviceId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.GetServiceDescription(ad, serviceId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("coverage/list")]
        /*
        public IHttpActionResult GetServiceCoverageList(int serviceId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.GetServiceCoverageList(ad, serviceId);
                return Ok(response);
            }

        }
        */
        public IHttpActionResult GetServiceCoverageList(int serviceId, string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            //ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            //var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;
                var response = ServicesBusiness.GetServiceCoverageList(ad, serviceId, searchKey, page);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("variant")]
        public IHttpActionResult GetServiceVariantDetails(int serviceVariantId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.GetServiceVariantDetails(ad, serviceVariantId);
                return Ok(response);
            }

        }



        //--------------------------------------
        //--------------PUT Method--------------
        //--------------------------------------

        [HttpPut]
        [Authorize]
        [Route("list/remove")]
        public IHttpActionResult DeleteServiceList(List<ServiceToRemove> serviceToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ServicesBusiness.DeleteServiceList(ad, userId, serviceToRemove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("enlist")]
        public IHttpActionResult EnlistService(List<ServiceToRemove> serviceToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ServicesBusiness.EnlistService(ad, userId, serviceToRemove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("general")]
        public IHttpActionResult UpdateServiceGeneral(ServiceGeneralUpdate serviceGeneralUpdate)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.UpdateServiceGeneral(ad, serviceGeneralUpdate);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("description")]
        public IHttpActionResult UpdateServiceDescription(ServiceDescriptionUpdate serviceDescriptionUpdate)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.UpdateServiceDescription(ad, serviceDescriptionUpdate);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("coverage/list")]
        public IHttpActionResult DeleteCoverageList(List<CoverageToRemove> coverageToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ServicesBusiness.DeleteCoverageList(ad, userId, coverageToRemove);
                return Ok(response);
            }

        }


        [HttpPut]
        [Authorize]
        [Route("variant")]
        public IHttpActionResult UpdateServiceVariant(ServiceVariant serviceVariant)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.UpdateServiceVariant(ad, serviceVariant);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("variant/remove")]
        public IHttpActionResult DeleteServiceVariant(int serviceVariantId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.DeleteServiceVariant(ad, serviceVariantId);
                return Ok(response);
            }

        }



        //---------------------------------------
        //--------------POST Method--------------
        //---------------------------------------
        [HttpPost]
        [Authorize]
        [Route("general")]
        public IHttpActionResult InsertServiceGeneral(ServiceGeneralRequest serviceGeneralRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(serviceGeneralRequest.serviceName))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Service Name is empty"));
            }

            if (string.IsNullOrWhiteSpace(serviceGeneralRequest.serviceNo))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Service No is empty"));
            }

            if (string.IsNullOrWhiteSpace(serviceGeneralRequest.shortDescription))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Short Description is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.InsertServiceGeneral(ad, Convert.ToInt32(tenantId), serviceGeneralRequest);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("category")]
        public IHttpActionResult UpdateServiceCategory(TenantServiceCategoryUpdate tenantserviceCategoryUpdate)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.UpdateServiceCategory(ad, tenantserviceCategoryUpdate);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("coverage/detail")]
        public IHttpActionResult InsertServiceCoverage(CoverageDetailInsert coverageDetailIn)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.InsertServiceCoverage(ad, coverageDetailIn);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("variant")]
        public IHttpActionResult InsertServiceVariant(int tenantServiceId, ServiceVariant serviceVariantRequest)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.InsertServiceVariant(ad, tenantServiceId, serviceVariantRequest);
                return Ok(response);
            }

        }


        //-----------------------------------------
        //--------------DELETE Method--------------
        //-----------------------------------------

        [HttpDelete]
        [Authorize]
        [Route("general/image")]
        public IHttpActionResult DeleteServiceImage(int serviceImageId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ServicesBusiness.DeleteServiceImage(ad, serviceImageId);
                return Ok(response);
            }

        }

    }
}
