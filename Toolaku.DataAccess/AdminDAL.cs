using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.Admin;
using Toolaku.Models.Pagingnation;
using System.Net.Mail;

namespace Toolaku.DataAccess
{
    public class AdminDAL
    {
        //--------------GET Method--------------

        
        public static (List<TenantList>, PageInfo) GetTenantManagementList(Adapter ad, string searchKey, Pager pager = null)
        {
            var response = new List<TenantList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Admin_GetTenantManagementList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                   command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        int TenantId = reader.GetOrdinal("TenantId");
                        int RefEditionId = reader.GetOrdinal("RefEditionId");
                        int TenantName = reader.GetOrdinal("TenantName");
                        int BusinessRegistrationNo = reader.GetOrdinal("BusinessRegistrationNo");
                        int RefEditionName = reader.GetOrdinal("RefEditionName");
                        

                        while (reader.Read())
                        {
                            var result = new TenantList
                            {
                                TenantId = Convert.ToInt32(reader.GetValue(TenantId)),
                                RefEditionId = Convert.ToInt32(reader.GetValue(RefEditionId)),
                                TenantName = reader.GetString(TenantName),
                                BusinessRegistrationNo = reader.GetString(BusinessRegistrationNo),
                                RefEditionName = reader.GetString(RefEditionName),
                            };
                            response.Add(result);
                        }

                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }




        public static NotificationCount GetNotificationCount(Adapter ad, int userId)
        {
            var response = new NotificationCount();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Admin_GetNotificationCount", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

                   
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            response.Count = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }




        public static List<NotificationList> GetNotificationList(Adapter ad, int userId)
        {
            var response = new List<NotificationList>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Admin_GetNotificationList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int NotificationCount = reader.GetOrdinal("NotificationCount");
                        int EventName = reader.GetOrdinal("EventName");
                        int MenuPath = reader.GetOrdinal("MenuPath");
                        int ScreenPath = reader.GetOrdinal("ScreenPath");
                        int TimeAgo = reader.GetOrdinal("TimeAgo");
                        int listIds = reader.GetOrdinal("listIds");
                        int key = reader.GetOrdinal("key");
                        int useKey = reader.GetOrdinal("useKey");

                        while (reader.Read())
                        {
                            var result = new NotificationList
                            {
                                NotificationCount = Convert.ToInt32(reader.GetValue(NotificationCount)),
                                EventName = reader.GetString(EventName),
                                MenuPath = reader.GetString(MenuPath),
                                ScreenPath = reader.GetString(ScreenPath),
                                TimeAgo = reader.GetString(TimeAgo),
                                listIds = reader.GetString(listIds),
                                key = reader.GetString(key),
                                useKey = Convert.ToInt32(reader.GetValue(useKey)),
                            };
                            response.Add(result);
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }



        //--------------PUT Method--------------

        public static BasicApiResponse PushEmailSingle(string emailTo, string subject, string body)
        {
            var response = new BasicApiResponse();
            response.ResponseMessage = "Password recovery is success, Please check your email - "+ emailTo;
            response.ReturnCode = 0;
            try
            {/*
                string name = "name";
                string password = "password";
                string email_id = "email";

                System.Net.Mail.MailMessage mail = new MailMessage();
                mail.From = new MailAddress("razman.zainal@gmail.com");
                mail.To.Add("razman.zainal@gmail.com");

                mail.Subject = "Password Recovery ";
                mail.Body = "Name : " + name +
                            "<br />Password : " + password +
                            "<br />Email : " + email_id;
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                client.Timeout = 2000000;
                client.Credentials = new System.Net.NetworkCredential("razman.zainal@gmail.com", "ra976631");
                client.Send(mail);
                */
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("toolaku2020@gmail.com");
                    //mail.To.Add("razman.zainal@gmail.com");
                    mail.To.Add(emailTo);
                    //mail.Subject = "Hello World";
                    mail.Subject = subject;
                    //mail.Body = "<h1>Hello</h1>";
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("toolaku2020@gmail.com", "udps2020");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                response.ResponseMessage = "Sending email failed";
                response.ReturnCode = 1;
                throw ex;
            }
            return response;
        }



        public static BasicApiResponse UpdateNotificationClose(Adapter ad, NotificationUpdate request)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Admin_UpdateNotificationClose", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.ListNotificationId, ParameterName = "@ListNotificationId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
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
                using (SqlCommand command = new SqlCommand("sp_Admin_InsertNotificationByTenant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.TenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.RefModuleId, ParameterName = "@RefModuleId " });
                    command.Parameters.Add(new SqlParameter() { Value = request.CreatorUserId, ParameterName = "@CreatorUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EventName, ParameterName = "@EventName" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MenuPath, ParameterName = "@MenuPath" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ScreenPath, ParameterName = "@ScreenPath" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        //--------------DELETE Method--------------


    }

}
