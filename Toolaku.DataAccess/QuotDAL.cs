using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.Sale;
using Toolaku.Models.Pagingnation;

namespace Toolaku.DataAccess
{
    public class QuotDAL
    {
        //--------------GET Method--------------

        public static (List<TenantInquiryRfqList>, PageInfo) GetQuotTenantInquiryRfqList(Adapter ad, int fromUserId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantInquiryRfqList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Quot_GetTenantInquiryRfqList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = fromUserId, ParameterName = "@FromUserId" });
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
                        while (reader.Read())
                        {
                            var result = new TenantInquiryRfqList
                            {
                                Id = Convert.ToInt32(reader.GetValue(0)),
                                refNo = reader.GetString(1),
                                type = reader.GetString(2),
                                statusQuotName = reader.GetString(3),
                                toTenantName = reader.GetString(4),
                                statusId = Convert.ToInt32(reader.GetValue(5)),
                                CreationDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(6)).ToString("dd MMM yyyy")),
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


        public static (List<TenantInquiry>, PageInfo)   GetQuotTenantInquiryList(Adapter ad, int fromUserId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantInquiry>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Quot_GetTenantInquiryList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = fromUserId, ParameterName = "@FromUserId" });
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
                        while (reader.Read())
                        {
                            var result = new TenantInquiry
                            {
                                tenantInquiryId = Convert.ToInt32(reader.GetValue(0)),
                                ticketNo = reader.GetString(1),
                                inquiryStatusQuotName = reader.GetString(2),
                                toTenantName = reader.GetString(3),
                                title = reader.GetString(4),
                                CreationDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(5)).ToString("dd MMM yyyy")),
                                inquiryStatusQuotId = Convert.ToInt32(reader.GetValue(6)),
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


        /*
        public static List<TenantRfq> GetQuotTenantRfqList(Adapter ad, int fromUserId, string searchKey)
        {
            var response = new List<TenantRfq>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Quot_GetTenantRfqList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = fromUserId, ParameterName = "@FromUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantRfq
                            {
                                tenantRfqId = Convert.ToInt32(reader.GetValue(0)),
                                rfqNo = reader.GetString(1),
                                rfqStatusQuotName = reader.GetString(2),
                                toTenantName = reader.GetString(3),
                                title = reader.GetString(4),
                                CreationDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(5)).ToString("dd MMM yyyy")),
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
        */

        public static (List<TenantRfq>, PageInfo) GetQuotTenantRfqList(Adapter ad, int fromUserId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantRfq>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Quot_GetTenantRfqList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = fromUserId, ParameterName = "@FromUserId" });
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
                        while (reader.Read())
                        {
                            var result = new TenantRfq
                            {
                                tenantRfqId = Convert.ToInt32(reader.GetValue(0)),
                                rfqNo = reader.GetString(1),
                                rfqStatusQuotName = reader.GetString(2),
                                toTenantName = reader.GetString(3),
                                title = reader.GetString(4),
                                CreationDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(5)).ToString("dd MMM yyyy")),
                                rfqStatusQuotId = Convert.ToInt32(reader.GetValue(6)),
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


        //--------------PUT Method--------------


        //--------------POST Method--------------


    }
}
