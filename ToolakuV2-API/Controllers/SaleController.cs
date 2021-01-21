using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using Toolaku.Business;
using Toolaku.Library;
using Toolaku.Models.Sale;
using Toolaku.Models.Pagingnation;

namespace ToolakuV2_API.Controllers
{
    [RoutePrefix("api/sale")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class SaleController : ApiController
    {
        //--------------GET Method--------------

        [HttpGet]
        [Authorize]
        [Route("listall")]
        public IHttpActionResult GetSaleTenantInquiryRfqList(string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = SaleBusiness.GetSaleTenantInquiryRfqList(ad, Convert.ToInt32(tenantId), searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("inquiry/list")]
        public IHttpActionResult GetSaleTenantInquiryList(string searchKey = null, int RowsPerPage = 0,
           int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = SaleBusiness.GetSaleTenantInquiryList(ad, Convert.ToInt32(tenantId), searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("inquiry")]
        public IHttpActionResult GetSaleTenantInquiryDetails(int tenantInquiryId)
        {           
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.GetSaleTenantInquiryDetails(ad, tenantInquiryId);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("inquiry/history/list")]
        public IHttpActionResult GetSaleTenantInquiryHistoryList(int tenantInquiryId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.GetSaleTenantInquiryHistoryList(ad, Convert.ToInt32(tenantInquiryId));
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
                var response = SaleBusiness.GetTenantInquiryHistoryViewModal(ad, true, "sale", Convert.ToInt32(tenantInquiryId));
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("rfq/list")]
        public IHttpActionResult GetSaleTenantRfqList(string searchKey = null, int RowsPerPage = 0,
            int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = SaleBusiness.GetSaleTenantRfqList(ad, Convert.ToInt32(tenantId), searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("rfq")]
        public IHttpActionResult GetSaleTenantRfqDetails(int tenantRfqId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.GetSaleTenantRfqDetails(ad, Convert.ToInt32(tenantRfqId));
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("rfq/history/list")]
        public IHttpActionResult GetSaleTenantRfqHistoryList(int tenantRfqId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.GetSaleTenantRfqHistoryList(ad, Convert.ToInt32(tenantRfqId));
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
                var response = SaleBusiness.GetTenantRfqHistoryViewModal(ad, true, "sale", Convert.ToInt32(tenantRfqId));
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("rfq/item/list")]
        public IHttpActionResult GetSaleTenantRfqItemList(int tenantRfqId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.GetSaleTenantRfqItemList(ad, Convert.ToInt32(tenantRfqId));
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("tender/rfq/list")]
        public IHttpActionResult GetSaleTenderRfqList(string searchKey = null, int RowsPerPage = 0,
           int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
           
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = SaleBusiness.GetSaleTenderRfqList(ad, searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("tender/rfq")]
        public IHttpActionResult GetSaleTenderRfqDetails(int tenderRfqId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.GetTenderRfqViewModal(ad, Convert.ToInt32(tenderRfqId));
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("rfq/variant/list")]
        public IHttpActionResult GetSaleTenantRfqItemVariantList(int tenantRfqId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.GetSaleTenantRfqItemVariantList(ad, Convert.ToInt32(tenantRfqId));
                return Ok(response);
            }
        }


        //--------------PUT Method--------------

        [HttpPut]
        [Authorize]
        [Route("inquiry/status")]
        public IHttpActionResult UpdateStatusInquiry(TenantInquiryUpdateStatusRequest request)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.UpdateStatusInquiry(ad, request.tenantInquiryId, request.inquiryStatusSaleId, request.inquiryStatusQuotId);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("rfq/status")]
        public IHttpActionResult UpdateStatusRfq(TenantRfqUpdateStatusRequest request)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.UpdateStatusRfq(ad, request.tenantRfqId, request.rfqStatusSaleId, request.rfqStatusQuotId);
                return Ok(response);
            }
        }

        //--------------POST Method--------------

        [HttpPost]
        [Authorize]
        [Route("inquiry/history")]
        public IHttpActionResult InsertSaleTenantInquiryHistory(TenantInquiryHistoryNew tenantInquiryHistoryNew)
        {
            using (Adapter ad = new Adapter())
            {
                tenantInquiryHistoryNew.inquiryStatusSaleId = 3;
                tenantInquiryHistoryNew.inquiryStatusQuotId = 2;
                tenantInquiryHistoryNew.flagSide = "S";
                var response = SaleBusiness.InsertSaleTenantInquiryHistory(ad, tenantInquiryHistoryNew);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("rfq/history")]
        public IHttpActionResult InsertSaleTenantRfqHistory(TenantRfqHistoryNew tenantRfqHistoryNew)
        {
            using (Adapter ad = new Adapter())
            {
                tenantRfqHistoryNew.rfqStatusSaleId = 3;
                tenantRfqHistoryNew.rfqStatusQuotId = 2;
                tenantRfqHistoryNew.flagSide = "S";
                var response = SaleBusiness.InsertSaleTenantRfqHistory(ad, tenantRfqHistoryNew);
                return Ok(response);
            }

        }
    }
}
