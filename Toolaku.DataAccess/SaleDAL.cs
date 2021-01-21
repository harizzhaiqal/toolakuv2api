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
    public class SaleDAL
    {
        //--------------GET Method--------------


        /*
        public static List<TenantInquiryRfqList> GetSaleTenantInquiryRfqList(Adapter ad, int tenantId, string searchKey)
        {
            var response = new List<TenantInquiryRfqList>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantInquiryRfqList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantInquiryRfqList
                            {
                                Id = Convert.ToInt32(reader.GetValue(0)),
                                refNo = reader.GetString(1),
                                type = reader.GetString(2),
                                statusSaleName = reader.GetString(3),
                                fromTenantName = reader.GetString(4),
                                statusId = Convert.ToInt32(reader.GetValue(5)),
                                CreationDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(6)).ToString("dd MMM yyyy")),
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

        public static (List<TenantInquiryRfqList>, PageInfo) GetSaleTenantInquiryRfqList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantInquiryRfqList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantInquiryRfqList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
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
                                statusSaleName = reader.GetString(3),
                                fromTenantName = reader.GetString(4),
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

        /*
        public static List<TenantInquiry> GetSaleTenantInquiryList(Adapter ad, int tenantId, string searchKey)
        {
            var response = new List<TenantInquiry>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantInquiryList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantInquiry
                            {
                                tenantInquiryId = Convert.ToInt32(reader.GetValue(0)),
                                ticketNo = reader.GetString(1),
                                inquiryStatusSaleName = reader.GetString(2),
                                fromTenantName = reader.GetString(3),
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

        public static (List<TenantInquiry>, PageInfo) GetSaleTenantInquiryList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantInquiry>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantInquiryList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
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
                                inquiryStatusSaleName = reader.GetString(2),
                                fromTenantName = reader.GetString(3),
                                title = reader.GetString(4),
                                inquiryStatusSaleId = Convert.ToInt32(reader.GetValue(6)),
                                CreationDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(5)).ToString("dd MMM yyyy")),
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


        public static TenantInquiry GetSaleTenantInquiryDetails(Adapter ad, int tenantInquiryId)
        {
            var response = new TenantInquiry();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantInquiryDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    //test commit

                    command.Parameters.Add(new SqlParameter() { Value = tenantInquiryId, ParameterName = "@TenantInquiryId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.tenantInquiryId = Convert.ToInt32(reader.GetValue(0));
                            response.ticketNo = reader.GetString(1);
                            response.inquiryStatusSaleName = reader.GetString(2);
                            response.fromTenantName = reader.GetString(3);
                            response.title = reader.GetString(4);
                            response.inquiryStatusQuotName = reader.GetString(5);
                            response.toTenantName = reader.GetString(6);
                            response.inquiryStatusSaleId = Convert.ToInt32(reader.GetValue(7));
                            response.inquiryStatusQuotId = Convert.ToInt32(reader.GetValue(8));
                            response.fromUserId = Convert.ToInt32(reader.GetValue(9));
                            response.toTenantId = Convert.ToInt32(reader.GetValue(10));
                            response.CreationDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(11)).ToString("dd MMM yyyy"));
                            response.tenantProductId = Convert.ToInt32(reader.GetValue(12));
                            response.productName = reader.GetString(13);
                            response.ToTenantlogoUrl = (reader.GetString(14) != "" ? reader.GetString(14) : "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg");
                            response.FromTenantlogoUrl = (reader.GetString(15) != "" ? reader.GetString(15) : "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg");

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

        /*
        public static List<TenantRfq> GetSaleTenantRfqList(Adapter ad, int tenantId, string searchKey)
        {
            var response = new List<TenantRfq>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantRfqList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantRfq
                            {
                                tenantRfqId = Convert.ToInt32(reader.GetValue(0)),
                                rfqNo = reader.GetString(1),
                                rfqStatusSaleName = reader.GetString(2),
                                fromTenantName = reader.GetString(3),
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

        public static (List<TenantRfq>, PageInfo) GetSaleTenantRfqList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantRfq>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantRfqList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
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
                                rfqStatusSaleName = reader.GetString(2),
                                fromTenantName = reader.GetString(3),
                                title = reader.GetString(4),
                                CreationDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(5)).ToString("dd MMM yyyy")),
                                rfqStatusSaleId = Convert.ToInt32(reader.GetValue(6)),
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

        public static TenantRfq GetSaleTenantRfqDetails(Adapter ad, int tenantRfqId)
        {
            var response = new TenantRfq();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantRfqDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantRfqId, ParameterName = "@TenantRfqId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.tenantRfqId = Convert.ToInt32(reader.GetValue(0));
                            response.rfqNo = reader.GetString(1);
                            response.rfqStatusSaleName = reader.GetString(2);
                            response.fromTenantName = reader.GetString(3);
                            response.title = reader.GetString(4);
                            response.rfqStatusQuotName = reader.GetString(5);
                            response.toTenantName = reader.GetString(6);
                            response.rfqStatusSaleId = Convert.ToInt32(reader.GetValue(7));
                            response.rfqStatusQuotId = Convert.ToInt32(reader.GetValue(8));
                            response.fromUserId = Convert.ToInt32(reader.GetValue(9));
                            response.toTenantId = Convert.ToInt32(reader.GetValue(10));
                            response.CreationDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(11)).ToString("dd MMM yyyy"));
                            response.ToTenantlogoUrl = (reader.GetString(12) != "" ? reader.GetString(12) : "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg");
                            response.FromTenantlogoUrl = (reader.GetString(13) != "" ? reader.GetString(13) : "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg");

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

        public static List<TenantInquiryHistory> GetSaleTenantInquiryHistoryList(Adapter ad, int tenantInquiryId)
        {
            var response = new List<TenantInquiryHistory>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantInquiryHistoryList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantInquiryId, ParameterName = "@TenantInquiryId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantInquiryHistory
                            {
                                tenantInquiryHistoryId = Convert.ToInt32(reader.GetValue(0)),
                                inquiryBody = reader.GetString(1),
                                tenantInquiryId = Convert.ToInt32(reader.GetValue(2)),
                                flagSide = reader.GetString(3),
                                CreationDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(4)).ToString("dd MMM yyyy HH:mm")),
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

        public static List<TenantRfqHistory> GetSaleTenantRfqHistoryList(Adapter ad, int tenantRfqId)
        {
            var response = new List<TenantRfqHistory>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantRfqHistoryList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantRfqId, ParameterName = "@TenantRfqId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantRfqHistory
                            {
                                tenantRfqHistoryId = Convert.ToInt32(reader.GetValue(0)),
                                rfqBody = reader.GetString(1),
                                attachmentUrl = reader.GetString(2),
                                tenantRfqId = Convert.ToInt32(reader.GetValue(3)),
                                flagSide = reader.GetString(4),
                                CreationDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(5)).ToString("dd MMM yyyy HH:mm")),
                                fileName = reader.GetString(6),
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


        public static List<TenantRfqItem> GetSaleTenantRfqItemList(Adapter ad, int tenantRfqId)
        {
            var response = new List<TenantRfqItem>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantRfqItemList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantRfqId, ParameterName = "@TenantRfqId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantRfqItem
                            {
                                tenantRfqItemId = Convert.ToInt32(reader.GetValue(0)),
                                tenantRfqId = Convert.ToInt32(reader.GetValue(1)),                                
                                productServiceId = Convert.ToInt32(reader.GetValue(2)),
                                productServiceName = reader.GetString(3),
                                categoryTypeId = reader.GetInt32(4),
                                categoryTypeName = reader.GetString(5),
                                quantity = reader.GetInt32(6),
                                uomId = reader.GetInt32(7),
                                uomName = reader.GetString(8),
                                quantityUnit = reader.GetString(9),
                                productServiceNo = reader.GetString(10),
                                
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


        public static List<TenantRfqItemVariant> GetSaleTenantRfqItemVariantList(Adapter ad, int tenantRfqId)
        {
            var response = new List<TenantRfqItemVariant>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenantRfqItemVariantList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantRfqId, ParameterName = "@TenantRfqId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantRfqItemVariant
                            {
                                tenantRfqItemVariantId = Convert.ToInt32(reader.GetValue(0)),
                                tenantRfqId = Convert.ToInt32(reader.GetValue(1)),
                                productServiceVariantId = Convert.ToInt32(reader.GetValue(2)),
                                productServiceVariantName = reader.GetString(3),
                                categoryTypeId = reader.GetInt32(4),
                                categoryTypeName = reader.GetString(5),
                                quantity = reader.GetInt32(6),
                                uomId = reader.GetInt32(7),
                                uomName = reader.GetString(8),
                                quantityUnit = reader.GetString(9),
                                productServiceVariantNo = reader.GetString(10),
                                productServiceName = reader.GetString(11),

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


        /*
        public static List<TenderRfq> GetSaleTenderRfqList(Adapter ad, string searchKey)
        {
            var response = new List<TenderRfq>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenderRfqList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenderRfq
                            {
                                tenderRfqId = Convert.ToInt32(reader.GetValue(0)),
                                offerTypeId = reader.GetInt32(1),
                                offerTypeName = reader.GetString(2),
                                publishDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
                                closingDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(4)).ToString("dd MMM yyyy")),
                                agencyId = reader.GetInt32(5),
                                agencyName = reader.GetString(6),
                                idNo = reader.GetString(7),
                                title = reader.GetString(8),
                                briefingTypeId = reader.GetInt32(9),
                                briefingTypeName = reader.GetString(10),
                                briefingDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(11)).ToString("dd MMM yyyy hh:mm tt")),
                                briefingVenue = reader.GetString(12),
                                documentFee = reader.GetDecimal(13),
                                docAttachmentURL = reader.GetString(14),
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

        public static (List<TenderRfq>, PageInfo) GetSaleTenderRfqList(Adapter ad, string searchKey, Pager pager = null)
        {
            var response = new List<TenderRfq>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenderRfqList", ad.SQLConn, ad.SQLTran))
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
                        while (reader.Read())
                        {
                            var result = new TenderRfq
                            {
                                tenderRfqId = Convert.ToInt32(reader.GetValue(0)),
                                offerTypeId = reader.GetInt32(1),
                                offerTypeName = reader.GetString(2),
                                publishDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
                                closingDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(4)).ToString("dd MMM yyyy")),
                                agencyId = reader.GetInt32(5),
                                agencyName = reader.GetString(6),
                                idNo = reader.GetString(7),
                                title = reader.GetString(8),
                                briefingTypeId = reader.GetInt32(9),
                                briefingTypeName = reader.GetString(10),
                                briefingDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(11)).ToString("dd MMM yyyy hh:mm tt")),
                                briefingVenue = reader.GetString(12),
                                documentFee = reader.GetDecimal(13),
                                docAttachmentURL = reader.GetString(14)
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

        public static List<TenderRfqCriteria> GetSaleTenderRfqCriteriaList(Adapter ad, int tenderRfqId)
        {
            var response = new List<TenderRfqCriteria>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenderRfqCriteriaList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = tenderRfqId, ParameterName = "@TenderRfqId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenderRfqCriteria
                            {
                                tenderRfqCriteriaId = Convert.ToInt32(reader.GetValue(0)),
                                tenderRfqId = Convert.ToInt32(reader.GetValue(1)),
                                agengyGradeId = Convert.ToInt32(reader.GetValue(2)),
                                agengyCodeId = Convert.ToInt32(reader.GetValue(3)),
                                agengyCodeCode = reader.GetString(4),
                                agengyCodeName = reader.GetString(5),
                                agengyGradeCode = reader.GetString(6),
                                agengyGradeDescription = reader.GetString(7),
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


        public static TenderRfq GetSaleTenderRfqDetails(Adapter ad, int tenderRfqId)
        {
            var response = new TenderRfq();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_GetTenderRfqDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenderRfqId, ParameterName = "@TenderRfqId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.tenderRfqId = Convert.ToInt32(reader.GetValue(0));
                            response.offerTypeId = reader.GetInt32(1);
                            response.offerTypeName = reader.GetString(2);
                            response.publishDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy"));
                            response.closingDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(4)).ToString("dd MMM yyyy"));
                            response.agencyId = reader.GetInt32(5);
                            response.agencyName = reader.GetString(6);
                            response.idNo = reader.GetString(7);
                            response.title = reader.GetString(8);
                            response.briefingTypeId = reader.GetInt32(9);
                            response.briefingTypeName = reader.GetString(10);
                            response.briefingDateTime = Convert.ToString(Convert.ToDateTime(reader.GetValue(11)).ToString("dd MMM yyyy hh:mm tt"));
                            response.briefingVenue = reader.GetString(12);
                            response.documentFee = reader.GetDecimal(13);
                            response.docAttachmentURL = reader.GetString(14);
                            response.criteria = reader.GetString(15);

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

        public static BasicApiResponse UpdateStatusInquiry(Adapter ad, int tenantInquiryId, int inquiryStatusSaleId, int inquiryStatusQuotId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_UpdateStatusTenantInquiry", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantInquiryId, ParameterName = "@TenantInquiryId" });
                    command.Parameters.Add(new SqlParameter() { Value = inquiryStatusSaleId, ParameterName = "@InquiryStatusSaleId" });
                    command.Parameters.Add(new SqlParameter() { Value = inquiryStatusQuotId, ParameterName = "@InquiryStatusQuotId" });                   

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

        public static BasicApiResponse UpdateStatusRfq(Adapter ad, int tenantRfqId, int rfqStatusSaleId, int rfqStatusQuotId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_UpdateStatusTenantRfq", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantRfqId, ParameterName = "@TenantRfqId" });
                    command.Parameters.Add(new SqlParameter() { Value = rfqStatusSaleId, ParameterName = "@RfqStatusSaleId" });
                    command.Parameters.Add(new SqlParameter() { Value = rfqStatusQuotId, ParameterName = "@RfqStatusQuotId" });

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

        public static PostApiResponse InsertSaleTenantInquiryHistory(Adapter ad, TenantInquiryHistory request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_InsertTenantInquiryHistory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.tenantInquiryId, ParameterName = "@TenantInquiryId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.inquiryBody, ParameterName = "@InquiryBody" });
                    command.Parameters.Add(new SqlParameter() { Value = request.flagSide, ParameterName = "@FlagSide" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {                            
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
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

        public static PostApiResponse InsertSaleTenantRfqHistory(Adapter ad, TenantRfqHistory request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Sale_InsertTenantRfqHistory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.tenantRfqId, ParameterName = "@TenantRfqId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.rfqBody, ParameterName = "@RfqBody" });
                    command.Parameters.Add(new SqlParameter() { Value = request.attachmentUrl, ParameterName = "@AttachmentUrl" });
                    command.Parameters.Add(new SqlParameter() { Value = request.flagSide, ParameterName = "@FlagSide" });
                    command.Parameters.Add(new SqlParameter() { Value = request.fileName, ParameterName = "@FileName" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
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

    }
}
