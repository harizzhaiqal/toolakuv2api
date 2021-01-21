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
    public class QuotBusiness
    {
        //--------------GET Method--------------
        public static TenantInquiryRfqLists GetQuotTenantInquiryRfqList(Adapter ad, int fromUserId, string searchKey, Pager pager = null)
        {
            var response = new TenantInquiryRfqLists();


            try
            {
                var result = QuotDAL.GetQuotTenantInquiryRfqList(ad, fromUserId, searchKey, pager);

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
        
        public static TenantInquiries GetQuotTenantInquiryList(Adapter ad, int fromUserId, string searchKey, Pager pager = null)
        {
            var response = new TenantInquiries();

            try
            {
                var result = QuotDAL.GetQuotTenantInquiryList(ad, fromUserId, searchKey, pager);

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
        public static TenantRfqs GetQuotTenantRfqList(Adapter ad, int fromUserId, string searchKey)
        {
            var response = new TenantRfqs();

            try
            {
                var result = QuotDAL.GetQuotTenantRfqList(ad, fromUserId, searchKey);

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


        public static TenantRfqs GetQuotTenantRfqList(Adapter ad, int fromUserId, string searchKey, Pager pager = null)
        {
            var response = new TenantRfqs();

            try
            {
                var result = QuotDAL.GetQuotTenantRfqList(ad, fromUserId, searchKey, pager);

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


        //--------------PUT Method--------------

        //--------------POST Method--------------

        //--------------DELETE Method--------------


    }
}
