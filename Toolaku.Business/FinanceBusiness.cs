using System;
using System.Collections.Generic;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.Finance;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Business
{
    public class FinanceBusiness
    {
        //--------------POST Method--------------
        public static TenantCustomerResponse InsertTenantCustomer(Adapter ad, int tenantId, TenantCustomer tenantCustomerRequest)
        {
            var response = new TenantCustomerResponse();

            try
            {
                var result = FinanceDAL.InsertTenantCustomer(ad, tenantId, tenantCustomerRequest);

                if (result.ReturnCode == 0)
                {
                    response.CustomerId = result.CustomerId;
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static QuotationInfoResponse InsertQuotationInfo(Adapter ad, int tenantId, QuotationInfoRequest quotationInfoRequest)
        {
            var response = new QuotationInfoResponse();

            try
            {
                var result = FinanceDAL.InsertQuotationInfo(ad, tenantId, quotationInfoRequest);

                if (result.ReturnCode == 0)
                {
                    response.QuotationId = result.QuotationId;
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse InsertQuotationItem(Adapter ad, QuotationItemRequest quotationItemRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = FinanceDAL.InsertQuotationItem(ad, quotationItemRequest);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static InvoiceInfoResponse InsertInvoiceInfo(Adapter ad, int tenantId, InvoiceInfoRequest invoiceInfoRequest)
        {
            var response = new InvoiceInfoResponse();

            try
            {
                var result = FinanceDAL.InsertInvoiceInfo(ad, tenantId, invoiceInfoRequest);

                if (result.ReturnCode == 0)
                {
                    response.InvoiceId = result.InvoiceId;
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse InsertInvoiceItem(Adapter ad, InvoiceItemRequest invoiceItemRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = FinanceDAL.InsertInvoiceItem(ad, invoiceItemRequest);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse InsertInvoicePayment(Adapter ad, InvoiceReceipt invoiceReceipt)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = FinanceDAL.InsertInvoicePayment(ad, invoiceReceipt);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        //--------------GET Method--------------
        public static TenantCustomerLists GetCustomerList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new TenantCustomerLists();

            try
            {
                var result = FinanceDAL.GetCustomerList(ad, tenantId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.result = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantCustomerDetail GetCustomer(Adapter ad, int customerId)
        {
            var response = new TenantCustomerDetail();

            try
            {
                response = FinanceDAL.GetCustomer(ad, customerId);

                if (response.Name != "")
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static QuotationLists GetQuotationList(Adapter ad, int tenantId, int userId, string searchKey, Pager pager = null)
        {
            var response = new QuotationLists();

            try
            {
                var result = FinanceDAL.GetQuotationList(ad, tenantId, userId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.result = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static QuotationInfoView GetQuotationInfo(Adapter ad, int quotationId)
        {
            var response = new QuotationInfoView();

            try
            {
                response = FinanceDAL.GetQuotationInfo(ad, quotationId);

                if (response.StatusId != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static QuotationItemListResponses GetQuotationItemList(Adapter ad, int quotationId)
        {
            var response = new QuotationItemListResponses();

            try
            {
                var result = FinanceDAL.GetQuotationItemList(ad, quotationId);

                if (result.Count != 0)
                {
                    response.result = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static QuotationItemResponse GetQuotationItem(Adapter ad, int itemId)
        {
            var response = new QuotationItemResponse();

            try
            {
                var result = FinanceDAL.GetQuotationItem(ad, itemId);

                if (result.ItemName != "")
                {
                    response = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static InvoiceLists GetInvoiceList(Adapter ad, int tenantId, int userId, string searchKey, Pager pager = null)
        {
            var response = new InvoiceLists();

            try
            {
                var result = FinanceDAL.GetInvoiceList(ad, tenantId, userId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.result = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static InvoiceInfoView GetInvoiceInfo(Adapter ad, int invoiceId)
        {
            var response = new InvoiceInfoView();

            try
            {
                response = FinanceDAL.GetInvoiceInfo(ad, invoiceId);

                if (response.StatusId != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static InvoiceItemListResponses GetInvoiceItemList(Adapter ad, int invoiceId)
        {
            var response = new InvoiceItemListResponses();

            try
            {
                var result = FinanceDAL.GetInvoiceItemList(ad, invoiceId);

                if (result.Count != 0)
                {
                    response.result = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static InvoiceItemResponse GetInvoiceItem(Adapter ad, int itemId)
        {
            var response = new InvoiceItemResponse();

            try
            {
                var result = FinanceDAL.GetInvoiceItem(ad, itemId);

                if (result.ItemName != "")
                {
                    response = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ProductLists GetProductList(Adapter ad, int tenantId)
        {
            var response = new ProductLists();

            try
            {
                var result = FinanceDAL.GetProductList(ad, tenantId);

                if (result.Count != 0)
                {
                    response.result = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ServicesLists GetServiceList(Adapter ad, int tenantId)
        {
            var response = new ServicesLists();

            try
            {
                var result = FinanceDAL.GetServiceList(ad, tenantId);

                if (result.Count != 0)
                {
                    response.result = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static InvoicePaymentDue GetPaymentDue(Adapter ad, int invoiceId)
        {
            var response = new InvoicePaymentDue();

            try
            {
                response = FinanceDAL.GetPaymentDue(ad, invoiceId);

                if (response.PaymentDue < 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ReceipListResponses GetReceiptList(Adapter ad, int invoiceId)
        {
            var response = new ReceipListResponses();

            try
            {
                var result = FinanceDAL.GetReceiptList(ad, invoiceId);

                if (result.Count != 0)
                {
                    response.result = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static InvoicePreview GetInvoicePreview(Adapter ad, int invoiceId)
        {
            var response = new InvoicePreview();
            var result1 = new List<InvoiceItemPreview>();
            var result2 = new List<ReceiptItemPreview>();

            try
            {
                //GetCustomer Invoice Info
                response = FinanceDAL.GetInvoicePreview(ad, invoiceId);
                if (response.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }

                //Get Invoice Item
                result1 = FinanceDAL.GetInvoiceItemListPreview(ad, invoiceId);
                if (result1.Count != 0)
                {
                    response.item = result1;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }

                //Get Payment
                result2 = FinanceDAL.GetReceiptListPreview(ad, invoiceId);
                if (result2.Count != 0)
                {
                    response.payment = result2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }


            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static PaymentMethods GetPaymentMethod(Adapter ad)
        {
            var response = new PaymentMethods();

            try
            {
                var result = FinanceDAL.GetPaymentMethod(ad);

                if (result.Count > 0)
                {
                    response.methodList = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ReceiptPreview GetReceiptPreview(Adapter ad, int receiptId)
        {
            var response = new ReceiptPreview();

            try
            {
                response = FinanceDAL.GetReceiptPreview(ad, receiptId);

                if (response.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static QuotationPreview GetQuotationPreview(Adapter ad, int quotationId)
        {
            var response = new QuotationPreview();
            var result = new List<QuotationItemPreview>();

            try
            {
                //GetCustomer Invoice Info
                response = FinanceDAL.GetQuotationPreview(ad, quotationId);
                if (response.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }

                //Get Invoice Item
                result = FinanceDAL.GetQuotationItemListPreview(ad, quotationId);
                if (result.Count != 0)
                {
                    response.item = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        //--------------PUT Method--------------

        public static BasicApiResponse UpdateTenantCustomer(Adapter ad, TenantCustomerUpdateRequest tenantCustomerUpdateRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = FinanceDAL.UpdateTenantCustomer(ad, tenantCustomerUpdateRequest);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateQuotationInfo(Adapter ad, QuotationInfoUpdateRequest quotationInfoUpdateRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = FinanceDAL.UpdateQuotationInfo(ad, quotationInfoUpdateRequest);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateQuotationItem(Adapter ad, QuotationItemUpdateRequest quotationItemUpdateRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = FinanceDAL.UpdateQuotationItem(ad, quotationItemUpdateRequest);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateInvoiceInfo(Adapter ad, InvoiceInfoUpdateRequest invoiceInfoUpdateRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = FinanceDAL.UpdateInvoiceInfo(ad, invoiceInfoUpdateRequest);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateInvoiceItem(Adapter ad, InvoiceItemUpdateRequest invoiceItemUpdateRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = FinanceDAL.UpdateInvoiceItem(ad, invoiceItemUpdateRequest);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse ApproveInvoice(Adapter ad, InvoiceToApprove invoiceToApprove)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = FinanceDAL.ApproveInvoice(ad, invoiceToApprove);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse ConfirmInvoice(Adapter ad, InvoiceToConfirm invoiceToConfirm)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = FinanceDAL.ConfirmInvoice(ad, invoiceToConfirm);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse SendQuotation(Adapter ad, QuotationToConfirm quotationToConfirm)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = FinanceDAL.SendQuotation(ad, quotationToConfirm);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static InvoiceIdAfterConvert ConvertQuotation(Adapter ad, QuotationToConfirm quotationToConfirm)
        {
            var response = new InvoiceIdAfterConvert();

            try
            {
                var result = FinanceDAL.ConvertQuotation(ad, quotationToConfirm);

                if (result.ReturnCode == 0)
                {
                    response.InvoiceId = result.InvoiceId;
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        //--------------DELETE Method--------------
        public static BasicApiResponse DeleteCustomerList(Adapter ad, string userId, List<CustomerToRemove> customerToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in customerToRemove)
                {
                    var result = FinanceDAL.DeleteCustomerList(ad, Convert.ToInt32(id.CustomerId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Customer are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Customer Delete Operation Fail";
                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteQuotationItemList(Adapter ad, string userId, List<ItemToRemove> itemToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in itemToRemove)
                {
                    var result = FinanceDAL.DeleteQuotationItemList(ad, Convert.ToInt32(id.ItemId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Items are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Items Delete Operation Fail";
                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteQuotationList(Adapter ad, string userId, List<QuotationToRemove> quotationToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in quotationToRemove)
                {
                    var result = FinanceDAL.DeleteQuotationList(ad, Convert.ToInt32(id.QuotationId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                        if (responseMsg == string.Empty)
                        {
                            responseMsg = "Sorry. Can't Delete quotation no " + result.ResponseMessage;
                        }
                        else
                        {
                            responseMsg = responseMsg + ", " + result.ResponseMessage;
                        }
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Items are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = responseMsg + ". User can onnly delete Draft status quotations.";
                    //response.ResponseMessage = "Items Delete Operation Fail";
                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteInvoiceList(Adapter ad, string userId, List<InvoiceToRemove> invoiceToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in invoiceToRemove)
                {
                    var result = FinanceDAL.DeleteInvoiceList(ad, Convert.ToInt32(id.InvoiceId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                        if (responseMsg == string.Empty)
                        {
                            responseMsg = "Sorry. Can't Delete invoice no " + result.ResponseMessage;
                        }
                        else
                        {
                            responseMsg = responseMsg + ", " + result.ResponseMessage;
                        }
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Items are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = responseMsg + ". User can only delete Draft status invoice.";
                    //response.ResponseMessage = "Items Delete Operation Fail";
                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteInvoiceItemList(Adapter ad, string userId, List<ItemToRemove> itemToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in itemToRemove)
                {
                    var result = FinanceDAL.DeleteInvoiceItemList(ad, Convert.ToInt32(id.ItemId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Items are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Items Delete Operation Fail";
                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteReceiptList(Adapter ad, string userId, List<ReceiptToRemove> receiptToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in receiptToRemove)
                {
                    var result = FinanceDAL.DeleteReceiptList(ad, Convert.ToInt32(id.ReceiptId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Items are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Items Delete Operation Fail";
                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }
    }
}
