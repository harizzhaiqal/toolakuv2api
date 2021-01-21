using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models;
using Toolaku.Models.DTO;
using Toolaku.Models.Sale;
using Toolaku.Models.Pagingnation;


namespace Toolaku.Business
{
    public class SaleBusiness
    {
        //--------------GET Method--------------

        /*
    public static TenantInquiryRfqLists GetSaleTenantInquiryRfqList(Adapter ad, int tenantId, string searchKey)
    {
        var response = new TenantInquiryRfqLists();

        try
        {
            var result = SaleDAL.GetSaleTenantInquiryRfqList(ad, tenantId, searchKey);

            if (result.Count != 0)
            {
                response.list = result;
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
    */

        public static TenantInquiryRfqLists GetSaleTenantInquiryRfqList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new TenantInquiryRfqLists();


            try
            {
                var result = SaleDAL.GetSaleTenantInquiryRfqList(ad, tenantId, searchKey, pager);

                if (result.Item1.Count != 0)
                {

                    response.list = result.Item1;
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
        /*
        public static TenantInquiries GetSaleTenantInquiryList(Adapter ad, int tenantId, string searchKey)
        {
            var response = new TenantInquiries();

            try
            {
                var result = SaleDAL.GetSaleTenantInquiryList(ad, tenantId, searchKey);

                if (result.Count != 0)
                {
                    response.list = result;
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
        */


        public static TenantInquiries GetSaleTenantInquiryList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new TenantInquiries();

            try
            {
                var result = SaleDAL.GetSaleTenantInquiryList(ad, tenantId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
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

        public static TenantInquiry GetSaleTenantInquiryDetails(Adapter ad, int tenantInquiryId)
        {
            var response = new TenantInquiry();
            try
            {
                response = SaleDAL.GetSaleTenantInquiryDetails(ad, tenantInquiryId);                
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }
        /*
        public static TenantRfqs GetSaleTenantRfqList(Adapter ad, int tenantId, string searchKey)
        {
            var response = new TenantRfqs();

            try
            {
                var result = SaleDAL.GetSaleTenantRfqList(ad, tenantId, searchKey);

                if (result.Count != 0)
                {
                    response.list = result;
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
        */

        public static TenantRfqs GetSaleTenantRfqList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new TenantRfqs();

            try
            {
                var result = SaleDAL.GetSaleTenantRfqList(ad, tenantId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
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

        public static TenantRfq GetSaleTenantRfqDetails(Adapter ad, int tenantRfqId)
        {
            var response = new TenantRfq();
            try
            {
                response = SaleDAL.GetSaleTenantRfqDetails(ad, tenantRfqId);
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static TenantInquiryHistories GetSaleTenantInquiryHistoryList(Adapter ad, int tenantInquiryId)
        {
            var response = new TenantInquiryHistories();

            try
            {
                var result = SaleDAL.GetSaleTenantInquiryHistoryList(ad, tenantInquiryId);

                if (result.Count != 0)
                {
                    response.list = result;
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

        public static TenantInquiryHistoryViewModal GetTenantInquiryHistoryViewModal(Adapter ad, Boolean UpdateflagRead, string fromPage, int tenantInquiryId)
        {
            var response = new TenantInquiryHistoryViewModal();

            try
            {
                var titleInfo = SaleDAL.GetSaleTenantInquiryDetails(ad, tenantInquiryId);
                response.titleInfo = titleInfo;

               
                if (UpdateflagRead == true && ((fromPage == "sale" && titleInfo.inquiryStatusSaleId == 2) || (fromPage == "quot" && titleInfo.inquiryStatusQuotId == 2)))
                {
                    SaleDAL.UpdateStatusInquiry(ad, tenantInquiryId, 4, 4);
                    var titleInfo2 = SaleDAL.GetSaleTenantInquiryDetails(ad, tenantInquiryId);
                    response.titleInfo = titleInfo2;
                }

                var historyList = SaleDAL.GetSaleTenantInquiryHistoryList(ad, tenantInquiryId);
                response.historyList = historyList;


            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantRfqHistories GetSaleTenantRfqHistoryList(Adapter ad, int tenantRfqId)
        {
            var response = new TenantRfqHistories();

            try
            {
                var result = SaleDAL.GetSaleTenantRfqHistoryList(ad, tenantRfqId);

                if (result.Count != 0)
                {
                    response.list = result;
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

        public static TenantRfqHistoryViewModal GetTenantRfqHistoryViewModal(Adapter ad, Boolean UpdateflagRead, string fromPage, int tenantRfqId)
        {
            var response = new TenantRfqHistoryViewModal();

            try
            {
                var titleInfo = SaleDAL.GetSaleTenantRfqDetails(ad, tenantRfqId);
                response.titleInfo = titleInfo;

                if (UpdateflagRead == true && ((fromPage == "sale" && titleInfo.rfqStatusSaleId == 2) || (fromPage == "quot" && titleInfo.rfqStatusQuotId == 2)))
                {
                    SaleDAL.UpdateStatusRfq(ad, tenantRfqId, 4, 4);
                    var titleInfo2 = SaleDAL.GetSaleTenantRfqDetails(ad, tenantRfqId);
                    response.titleInfo = titleInfo2;
                }

                var historyList = SaleDAL.GetSaleTenantRfqHistoryList(ad, tenantRfqId);
                response.historyList = historyList;

                //var rfqItem = SaleDAL.GetSaleTenantRfqItemList(ad, tenantRfqId);
                //response.rfqItem = rfqItem;

                var rfqItemVariant = SaleDAL.GetSaleTenantRfqItemVariantList(ad, tenantRfqId);
                response.rfqItemVariant = rfqItemVariant;


            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantRfqItems GetSaleTenantRfqItemList(Adapter ad, int tenantRfqId)
        {
            var response = new TenantRfqItems();

            try
            {
                var result = SaleDAL.GetSaleTenantRfqItemList(ad, tenantRfqId);

                if (result.Count != 0)
                {
                    response.list = result;
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


        public static TenantRfqItemVariants GetSaleTenantRfqItemVariantList(Adapter ad, int tenantRfqId)
        {
            var response = new TenantRfqItemVariants();

            try
            {
                var result = SaleDAL.GetSaleTenantRfqItemVariantList(ad, tenantRfqId);

                if (result.Count != 0)
                {
                    response.list = result;
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

        /*
        public static TenderRfqs GetSaleTenderRfqList(Adapter ad, string searchKey)
        {
            var response = new TenderRfqs();

            try
            {
                var result = SaleDAL.GetSaleTenderRfqList(ad, searchKey);

                if (result.Count != 0)
                {
                    response.list = result;
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
        */

        public static TenderRfqs GetSaleTenderRfqList(Adapter ad, string searchKey, Pager pager = null)
        {
            var response = new TenderRfqs();

            try
            {
                var result = SaleDAL.GetSaleTenderRfqList(ad, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
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

        public static TenderRfq GetSaleTenderRfqDetails(Adapter ad, int tenderRfqId)
        {
            var response = new TenderRfq();

            try
            {
                response = SaleDAL.GetSaleTenderRfqDetails(ad, tenderRfqId);

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }


        public static TenderRfqViewModal GetTenderRfqViewModal(Adapter ad, int tenderRfqId)
        {
            var response = new TenderRfqViewModal();

            try
            {
                var tenderRfqDetails = SaleDAL.GetSaleTenderRfqDetails(ad, tenderRfqId);
                response.tenderRfqDetails = tenderRfqDetails;

                var criteriaList = SaleDAL.GetSaleTenderRfqCriteriaList(ad, tenderRfqId);
                response.criteriaList = criteriaList;
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

        public static BasicApiResponse UpdateStatusInquiry(Adapter ad, int tenantInquiryId, int inquiryStatusSaleId, int inquiryStatusQuotId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = SaleDAL.UpdateStatusInquiry(ad, tenantInquiryId, inquiryStatusSaleId, inquiryStatusQuotId);

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

        public static BasicApiResponse UpdateStatusRfq(Adapter ad, int tenantRfqId, int rfqStatusSaleId, int rfqStatusQuotId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = SaleDAL.UpdateStatusRfq(ad, tenantRfqId, rfqStatusSaleId, rfqStatusQuotId);

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

        //--------------POST Method--------------

        public static PostApiResponse InsertSaleTenantInquiryHistory(Adapter ad, TenantInquiryHistoryNew tenantInquiryHistoryNew)
        {
            var response = new PostApiResponse();
            var tenantInquiry = new TenantInquiry();
            var tenantInquiryHistory = new TenantInquiryHistory();

            tenantInquiryHistory.tenantInquiryId = tenantInquiryHistoryNew.tenantInquiryId;
            tenantInquiryHistory.inquiryBody = tenantInquiryHistoryNew.inquiryBody;
            tenantInquiryHistory.flagSide = tenantInquiryHistoryNew.flagSide;

            try
            {
                var result = SaleDAL.InsertSaleTenantInquiryHistory(ad, tenantInquiryHistory);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;

                    SaleDAL.UpdateStatusInquiry(ad, tenantInquiryHistoryNew.tenantInquiryId, tenantInquiryHistoryNew.inquiryStatusSaleId, tenantInquiryHistoryNew.inquiryStatusQuotId);
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

        public static PostApiResponse InsertSaleTenantRfqHistory(Adapter ad, TenantRfqHistoryNew tenantRfqHistoryNew)
        {
            var response = new PostApiResponse();
            var tenantRfq = new TenantRfq();
            var tenantRfqHistory = new TenantRfqHistory();

            tenantRfqHistory.tenantRfqId = tenantRfqHistoryNew.tenantRfqId;
            tenantRfqHistory.rfqBody = tenantRfqHistoryNew.rfqBody;
            tenantRfqHistory.attachmentUrl = tenantRfqHistoryNew.attachmentUrl;
            tenantRfqHistory.flagSide = tenantRfqHistoryNew.flagSide;
            tenantRfqHistory.fileName = tenantRfqHistoryNew.fileName;            

            try
            {
                var result = SaleDAL.InsertSaleTenantRfqHistory(ad, tenantRfqHistory);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;

                    SaleDAL.UpdateStatusRfq(ad, tenantRfqHistoryNew.tenantRfqId, tenantRfqHistoryNew.rfqStatusSaleId, tenantRfqHistoryNew.rfqStatusQuotId);
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


    }
}
