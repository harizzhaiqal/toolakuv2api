using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models;
using Toolaku.Models.DTO;
using Toolaku.Models.Admin;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Business
{
    public class AdminBusiness
    {
        //--------------GET Method--------------

        

        public static NotificationCount GetNotificationCount(Adapter ad, int userId)
        {
            var response = new NotificationCount();
            try
            {
                response = AdminDAL.GetNotificationCount(ad, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static NotificationLists GetNotificationList(Adapter ad, int userId)
        {
            var response = new NotificationLists();
            try
            {
                var list = AdminDAL.GetNotificationList(ad, userId);
                response.list = list;
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static TenantListDT GetTenantManagementList(Adapter ad, string searchKey, Pager pager = null)
        {
            var response = new TenantListDT();
            try
            {
                var result = AdminDAL.GetTenantManagementList(ad,  searchKey, pager);
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
            }
            return response;
        }
        
        //--------------PUT Method--------------

        public static BasicApiResponse PushEmailRecoveryPassword(Adapter ad, string emailTo, string subject, string mailBody, string encryptedPassword)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = AccountDAL.ForgetPassword(ad, emailTo, encryptedPassword);
                if (result.ReturnCode == 0)
                {                  

                    var result2 = AdminDAL.PushEmailSingle(emailTo, subject, mailBody);

                    if (result2.ReturnCode == 0)
                    {
                        response.ReturnCode = 200;
                        response.ResponseMessage = result2.ResponseMessage;
                    }
                    else
                    {
                        response.ReturnCode = 401;
                        response.ResponseMessage = result2.ResponseMessage;
                    }
                    //response.ReturnCode = 200;
                    //response.ResponseMessage = result.ResponseMessage;
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
            }
            return response;
        }


        public static BasicApiResponse UpdateNotificationClose(Adapter ad, NotificationUpdate request)
        {
            var response = new BasicApiResponse();

            try
            {

                var result = AdminDAL.UpdateNotificationClose(ad, request);

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
        public static PostApiResponse InsertNotificationByTenant(Adapter ad, NotificationInsert request)
        {
            var response = new PostApiResponse();
            try
            {
                var result = AdminDAL.InsertNotificationByTenant(ad, request);
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
            }
            return response;
        }

        //--------------DELETE Method--------------


    }








}
