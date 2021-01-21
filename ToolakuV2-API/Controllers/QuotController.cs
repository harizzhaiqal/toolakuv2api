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
using Toolaku.Models.Sale;
using Toolaku.Models.Services;
using Toolaku.Models.Pagingnation;

namespace ToolakuV2_API.Controllers
{
    [RoutePrefix("api/quot")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class QuotController : ApiController
    {
        //--------------GET Method--------------

        [HttpGet]
        [Authorize]
        [Route("listall")]
        public IHttpActionResult GetQuotTenantInquiryRfqList(string searchKey = null, int RowsPerPage = 0, 
            int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = QuotBusiness.GetQuotTenantInquiryRfqList(ad, Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("inquiry/list")]
        public IHttpActionResult GetQuotTenantInquiryList(string searchKey = null, int RowsPerPage = 0,
            int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = QuotBusiness.GetQuotTenantInquiryList(ad, Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("inquiry/history/viewmodal")]
        public IHttpActionResult GetTenantInquiryHistoryViewModal(int tenantInquiryId)
        {
            using (Adapter ad = new Adapter())
            {

                var response = SaleBusiness.GetTenantInquiryHistoryViewModal(ad, true, "quot", Convert.ToInt32(tenantInquiryId));
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("rfq/list")]
        public IHttpActionResult GetQuotTenantRfqList(string searchKey = null, int RowsPerPage = 0,
            int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = QuotBusiness.GetQuotTenantRfqList(ad, Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("rfq/history/viewmodal")]
        public IHttpActionResult GetTenantRfqHistoryViewModal(int tenantRfqId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.GetTenantRfqHistoryViewModal(ad, true, "quot", Convert.ToInt32(tenantRfqId));
                return Ok(response);
            }
        }


        //--------------PUT Method--------------

        [HttpPut]
        [Authorize]
        [Route("inquiry/status")]
        public IHttpActionResult UpdateStatusInquiry(int tenantInquiryId, int inquiryStatusSaleId, int inquiryStatusQuotId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.UpdateStatusInquiry(ad, tenantInquiryId, inquiryStatusSaleId, inquiryStatusQuotId);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("rfq/status")]
        public IHttpActionResult UpdateStatusRfq(int tenantRfqId, int rfqStatusSaleId, int rfqStatusQuotId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.UpdateStatusRfq(ad, tenantRfqId, rfqStatusSaleId, rfqStatusQuotId);
                return Ok(response);
            }
        }


        //--------------POST Method--------------

        [HttpPost]
        [Authorize]
        [Route("inquiry/history")]
        public IHttpActionResult InsertQuotTenantInquiryHistory(TenantInquiryHistoryNew tenantInquiryHistoryNew)
        {
            using (Adapter ad = new Adapter())
            {
                tenantInquiryHistoryNew.inquiryStatusSaleId = 2;
                tenantInquiryHistoryNew.inquiryStatusQuotId = 3;
                tenantInquiryHistoryNew.flagSide = "Q";
                var response = SaleBusiness.InsertSaleTenantInquiryHistory(ad, tenantInquiryHistoryNew);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("rfq/history")]
        public IHttpActionResult InsertQuotTenantRfqHistory(TenantRfqHistoryNew tenantRfqHistoryNew)
        {
            using (Adapter ad = new Adapter())
            {
                tenantRfqHistoryNew.rfqStatusSaleId = 2;
                tenantRfqHistoryNew.rfqStatusQuotId = 3;
                tenantRfqHistoryNew.flagSide = "Q";
                var response = SaleBusiness.InsertSaleTenantRfqHistory(ad, tenantRfqHistoryNew);
                return Ok(response);
            }

        }

    }
}
