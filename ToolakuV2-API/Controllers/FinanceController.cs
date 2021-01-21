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
using Toolaku.Models.Finance;
using Toolaku.Models.Pagingnation;
using Toolaku.Models.Product;

namespace ToolakuV2_API.Controllers
{
    [RoutePrefix("api/finance")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class FinanceController : ApiController
    {
        //--------------POST Method--------------

        [HttpPost]
        [Authorize]
        [Route("customer")]
        public IHttpActionResult InsertTenantCustomer(TenantCustomer tenantCustomerRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(tenantCustomerRequest.Name))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NoContent, "Customer Name is Empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.InsertTenantCustomer(ad, Convert.ToInt32(tenantId), tenantCustomerRequest);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("quotation/info")]
        public IHttpActionResult InsertQuotationInfo(QuotationInfoRequest quotationInfoRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (quotationInfoRequest.CustomerId == 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Customer is empty.Please select Customer"));
            }

            if (string.IsNullOrWhiteSpace(quotationInfoRequest.QuotationTitle))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Quotation Title is Empty"));
            }

            if (string.IsNullOrWhiteSpace(quotationInfoRequest.QuotationNo))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Quotation No is empty"));
            }

            if (string.IsNullOrWhiteSpace(quotationInfoRequest.QuotationDate))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Quotation Date  is empty"));
            }
            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.InsertQuotationInfo(ad, Convert.ToInt32(tenantId), quotationInfoRequest);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("quotation/item")]
        public IHttpActionResult InsertQuotationItem(QuotationItemRequest quotationItemRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(quotationItemRequest.ItemName))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Item Name is Empty"));
            }

            if (quotationItemRequest.Quantity < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Quantity is empty"));
            }

            if (quotationItemRequest.Price < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Item Price  is empty"));
            }
            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.InsertQuotationItem(ad, quotationItemRequest);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("invoice/info")]
        public IHttpActionResult InsertInvoiceInfo(InvoiceInfoRequest invoiceInfoRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (invoiceInfoRequest.CustomerId == 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Customer is empty.Please select Customer"));
            }

            if (string.IsNullOrWhiteSpace(invoiceInfoRequest.InvoiceTitle))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Invoice Title is Empty"));
            }

            if (string.IsNullOrWhiteSpace(invoiceInfoRequest.InvoiceNo))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invoice No is empty"));
            }

            if (string.IsNullOrWhiteSpace(invoiceInfoRequest.InvoiceDate))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invoice Date is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.InsertInvoiceInfo(ad, Convert.ToInt32(tenantId), invoiceInfoRequest);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("invoice/item")]
        public IHttpActionResult InsertInvoiceItem(InvoiceItemRequest invoiceItemRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(invoiceItemRequest.ItemName))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Item Name is Empty"));
            }

            if (invoiceItemRequest.Quantity < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Quantity is empty"));
            }

            if (invoiceItemRequest.Price < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Item Price  is empty"));
            }
            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.InsertInvoiceItem(ad, invoiceItemRequest);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("invoice/receipt")]
        public IHttpActionResult InsertInvoicePayment(InvoiceReceipt invoiceReceipt)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(invoiceReceipt.ReceiptDate))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Date is Empty"));
            }

            if (invoiceReceipt.Amount < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Amount must be more than 0"));
            }

            if (invoiceReceipt.PaymentMethodId < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Payment Method is empty"));
            }
            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.InsertInvoicePayment(ad, invoiceReceipt);
                return Ok(response);
            }

        }



        //--------------GET Method--------------
        [HttpGet]
        [Authorize]
        [Route("customer/list")]
        public IHttpActionResult GetCustomerList(string searchKey = null, int RowsPerPage = 0,
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

                var response = FinanceBusiness.GetCustomerList(ad, Convert.ToInt32(tenantId), searchKey, page);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("customer")]
        public IHttpActionResult GetCustomer(int customerId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetCustomer(ad, Convert.ToInt32(customerId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("quotation/list")]
        public IHttpActionResult GetQuotationList(string searchKey = null, int RowsPerPage = 0,
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

                var response = FinanceBusiness.GetQuotationList(ad, Convert.ToInt32(tenantId), Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("quotation/info")]
        public IHttpActionResult GetQuotationInfo(int quotationId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetQuotationInfo(ad, Convert.ToInt32(quotationId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("quotation/item/list")]
        public IHttpActionResult GetQuotationItemList(int quotationId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetQuotationItemList(ad, Convert.ToInt32(quotationId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("quotation/item")]
        public IHttpActionResult GetQuotationItem(int itemId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetQuotationItem(ad, Convert.ToInt32(itemId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("invoice/list")]
        public IHttpActionResult GetInvoiceList(string searchKey = null, int RowsPerPage = 0, int PageNumber = 0, 
        string OrderScript = "", string ColumnFilterScript = "")
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

                var response = FinanceBusiness.GetInvoiceList(ad, Convert.ToInt32(tenantId), Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("invoice/info")]
        public IHttpActionResult GetInvoiceInfo(int invoiceId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetInvoiceInfo(ad, Convert.ToInt32(invoiceId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("invoice/item/list")]
        public IHttpActionResult GetInvoiceItemList(int invoiceId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetInvoiceItemList(ad, Convert.ToInt32(invoiceId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("invoice/item")]
        public IHttpActionResult GetInvoiceItem(int itemId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetInvoiceItem(ad, Convert.ToInt32(itemId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("item/product/list")]
        public IHttpActionResult GetProductList()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetProductList(ad, Convert.ToInt32(tenantId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("item/service/list")]
        public IHttpActionResult GetServiceList()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetServiceList(ad, Convert.ToInt32(tenantId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("invoice/receipt")]
        public IHttpActionResult GetPaymentDue(int invoiceId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetPaymentDue(ad, invoiceId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("receipt/list")]
        public IHttpActionResult GetReceiptList(int invoiceId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetReceiptList(ad, Convert.ToInt32(invoiceId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("invoice/preview")]
        public IHttpActionResult GetInvoicePreview(int invoiceId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetInvoicePreview(ad, Convert.ToInt32(invoiceId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("payment/method")]
        public IHttpActionResult GetPaymentMethod()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetPaymentMethod(ad);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("receipt/preview")]
        public IHttpActionResult GetReceiptPreview(int receiptId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetReceiptPreview(ad, Convert.ToInt32(receiptId));
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("quotation/preview")]
        public IHttpActionResult GetQuotationPreview(int quotationId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.GetQuotationPreview(ad, Convert.ToInt32(quotationId));
                return Ok(response);
            }

        }

        //--------------PUT Method--------------
        [HttpPut]
        [Authorize]
        [Route("customer")]
        public IHttpActionResult UpdateTenantCustomer(TenantCustomerUpdateRequest tenantCustomerUpdateRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(tenantCustomerUpdateRequest.Name))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NoContent, "Customer Name is Empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = FinanceBusiness.UpdateTenantCustomer(ad, tenantCustomerUpdateRequest);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("quotation/info")]
        public IHttpActionResult UpdateQuotationInfo(QuotationInfoUpdateRequest quotationInfoUpdateRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (quotationInfoUpdateRequest.CustomerId == 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Customer is empty.Please select Customer"));
            }

            if (string.IsNullOrWhiteSpace(quotationInfoUpdateRequest.QuotationTitle))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Quotation Title is Empty"));
            }

            if (string.IsNullOrWhiteSpace(quotationInfoUpdateRequest.QuotationNo))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Quotation No is empty"));
            }

            if (string.IsNullOrWhiteSpace(quotationInfoUpdateRequest.QuotationDate))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Quotation Date  is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.UpdateQuotationInfo(ad, quotationInfoUpdateRequest);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("quotation/item")]
        public IHttpActionResult UpdateQuotationItem(QuotationItemUpdateRequest quotationItemUpdateRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(quotationItemUpdateRequest.ItemName))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Item Name is Empty"));
            }

            if (quotationItemUpdateRequest.Quantity < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Quantity is empty"));
            }

            if (quotationItemUpdateRequest.Price < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Item Price  is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.UpdateQuotationItem(ad, quotationItemUpdateRequest);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("invoice/info")]
        public IHttpActionResult UpdateInvoiceInfo(InvoiceInfoUpdateRequest invoiceInfoUpdateRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (invoiceInfoUpdateRequest.CustomerId == 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Customer is empty.Please select Customer"));
            }

            if (string.IsNullOrWhiteSpace(invoiceInfoUpdateRequest.InvoiceTitle))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Invoice Title is Empty"));
            }

            if (string.IsNullOrWhiteSpace(invoiceInfoUpdateRequest.InvoiceNo))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invoice No is empty"));
            }

            if (string.IsNullOrWhiteSpace(invoiceInfoUpdateRequest.InvoiceDate))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Invoice Date  is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.UpdateInvoiceInfo(ad, invoiceInfoUpdateRequest);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("invoice/item")]
        public IHttpActionResult UpdateInvoiceItem(InvoiceItemUpdateRequest invoiceItemUpdateRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(invoiceItemUpdateRequest.ItemName))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Item Name is Empty"));
            }

            if (invoiceItemUpdateRequest.Quantity < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Quantity is empty"));
            }

            if (invoiceItemUpdateRequest.Price < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Item Price  is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.UpdateInvoiceItem(ad, invoiceItemUpdateRequest);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("invoice/approval")]
        public IHttpActionResult ApproveInvoice(InvoiceToApprove invoiceToApprove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (invoiceToApprove.InvoiceId < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "InvoiceId is empty"));
            }

            if (invoiceToApprove.StatusId < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Status is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.ApproveInvoice(ad, invoiceToApprove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("invoice/confirm")]
        public IHttpActionResult ConfirmInvoice(InvoiceToConfirm invoiceToConfirm)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (invoiceToConfirm.InvoiceId < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "InvoiceId is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.ConfirmInvoice(ad, invoiceToConfirm);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("quotation/send")]
        public IHttpActionResult SendQuotation(QuotationToConfirm quotationToConfirm)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (quotationToConfirm.QuotationId < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "QuotationId is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.SendQuotation(ad, quotationToConfirm);
                return Ok(response);
            }

        }


        [HttpPut]
        [Authorize]
        [Route("quotation/convert")]
        public IHttpActionResult ConvertQuotation(QuotationToConfirm quotationToConfirm)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (quotationToConfirm.QuotationId < 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "QuotationId is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = new InvoiceIdAfterConvert();

                response = FinanceBusiness.ConvertQuotation(ad, quotationToConfirm);
                return Ok(response);
            }

        }

        //--------------DELETE Method--------------
        [HttpPut]
        [Authorize]
        [Route("customer/delete")]
        public IHttpActionResult DeleteCustomerList(List<CustomerToRemove> customerToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.DeleteCustomerList(ad, userId, customerToRemove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("quotation/item/delete")]
        public IHttpActionResult DeleteQuotationItemList(List<ItemToRemove> itemToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.DeleteQuotationItemList(ad, userId, itemToRemove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("quotation/delete")]
        public IHttpActionResult DeleteQuotationList(List<QuotationToRemove> quotationToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.DeleteQuotationList(ad, userId, quotationToRemove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("invoice/delete")]
        public IHttpActionResult DeleteInvoiceList(List<InvoiceToRemove> invoiceToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.DeleteInvoiceList(ad, userId, invoiceToRemove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("invoice/item/delete")]
        public IHttpActionResult DeleteInvoiceItemList(List<ItemToRemove> itemToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.DeleteInvoiceItemList(ad, userId, itemToRemove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("invoice/receipt/delete")]
        public IHttpActionResult DeleteReceiptList(List<ReceiptToRemove> receiptToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = FinanceBusiness.DeleteReceiptList(ad, userId, receiptToRemove);
                return Ok(response);
            }

        }
    }
}
