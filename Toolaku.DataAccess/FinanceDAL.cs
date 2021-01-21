using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.Finance;
using Toolaku.Models.Pagingnation;

namespace Toolaku.DataAccess
{
    public class FinanceDAL
    {
        //--------------POST Method--------------
        public static TenantCustomerResponse InsertTenantCustomer(Adapter ad, int tenantId, TenantCustomer tenantCustomerRequest)
        {
            var response = new TenantCustomerResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_InsertTenantCustomer", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerRequest.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerRequest.Email, ParameterName = "@Email" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerRequest.Phone, ParameterName = "@Phone" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerRequest.PIC, ParameterName = "@PIC" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerRequest.Address1, ParameterName = "@Address1" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerRequest.Address2, ParameterName = "@Address2" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerRequest.City, ParameterName = "@City" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerRequest.Poscode, ParameterName = "@Poscode" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerRequest.CountryId, ParameterName = "@CountryId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerRequest.StateId, ParameterName = "@StateId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
                            response.CustomerId = Convert.ToInt32(reader.GetValue(2));
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

        public static QuotationInfoResponse InsertQuotationInfo(Adapter ad, int tenantId, QuotationInfoRequest quotationInfoRequest)
        {
            var response = new QuotationInfoResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_InsertQuotationInfo", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoRequest.CustomerId, ParameterName = "@CustomerId" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoRequest.QuotationTitle, ParameterName = "@QuotationTitle" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoRequest.QuotationNo, ParameterName = "@QuotationNo" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoRequest.PONo, ParameterName = "@PONo" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoRequest.QuotationDate, ParameterName = "@QuotationDate" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoRequest.ExpiryDate, ParameterName = "@ExpiryDate" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoRequest.Notes, ParameterName = "@Notes" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
                            response.QuotationId = Convert.ToInt32(reader.GetValue(2));
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

        public static BasicApiResponse InsertQuotationItem(Adapter ad, QuotationItemRequest quotationItemRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_InsertQuotationItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemRequest.QuotationId, ParameterName = "@QuotationId" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemRequest.ProductId, ParameterName = "@ProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemRequest.ServiceId, ParameterName = "@ServiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemRequest.ItemName, ParameterName = "@ItemName" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemRequest.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemRequest.Quantity, ParameterName = "@Quantity" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemRequest.Price, ParameterName = "@Price" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static InvoiceInfoResponse InsertInvoiceInfo(Adapter ad, int tenantId, InvoiceInfoRequest invoiceInfoRequest)
        {
            var response = new InvoiceInfoResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_InsertInvoiceInfo", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoRequest.CustomerId, ParameterName = "@CustomerId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoRequest.InvoiceTitle, ParameterName = "@InvoiceTitle" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoRequest.InvoiceNo, ParameterName = "@InvoiceNo" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoRequest.PONo, ParameterName = "@PONo" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoRequest.InvoiceDate, ParameterName = "@InvoiceDate" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoRequest.DueDate, ParameterName = "@DueDate" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
                            response.InvoiceId = Convert.ToInt32(reader.GetValue(2));
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

        public static BasicApiResponse InsertInvoiceItem(Adapter ad, InvoiceItemRequest invoiceItemRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_InsertInvoiceItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemRequest.InvoiceId, ParameterName = "@InvoiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemRequest.ProductId, ParameterName = "@ProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemRequest.ServiceId, ParameterName = "@ServiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemRequest.ItemName, ParameterName = "@ItemName" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemRequest.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemRequest.Quantity, ParameterName = "@Quantity" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemRequest.Price, ParameterName = "@Price" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static BasicApiResponse InsertInvoicePayment(Adapter ad, InvoiceReceipt invoiceReceipt)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_InsertInvoicePayment", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = invoiceReceipt.InvoiceId, ParameterName = "@InvoiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceReceipt.ReceiptDate, ParameterName = "@ReceiptDate" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceReceipt.ReceiptNo, ParameterName = "@ReceiptNo" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceReceipt.Amount, ParameterName = "@Amount" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceReceipt.PaymentMethodId, ParameterName = "@PaymentMethodId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceReceipt.Notes, ParameterName = "@Notes" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        //--------------GET Method--------------
        public static (List<TenantCustomerList>, PageInfo) GetCustomerList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantCustomerList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetCustomerList", ad.SQLConn, ad.SQLTran))
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
                            var result = new TenantCustomerList();
                            result.CustomerId = Convert.ToInt32(reader.GetValue(0));
                            result.Name = reader.GetString(1);
                            result.Email = reader.GetString(2);
                            result.Phone = reader.GetString(3);
                            result.PIC = reader.GetString(4);

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

        public static TenantCustomerDetail GetCustomer(Adapter ad, int customerId)
        {
            var response = new TenantCustomerDetail();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetCustomer", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = customerId, ParameterName = "@CustomerId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Name = reader.GetString(0);
                            response.Email = reader.GetString(1);
                            response.Phone = reader.GetString(2);
                            response.PIC = reader.GetString(3);
                            response.Address1 = reader.GetString(4);
                            response.Address2 = reader.GetString(5);
                            response.City = reader.GetString(6);
                            response.Poscode = reader.GetString(7);
                            response.CountryId = Convert.ToInt32(reader.GetValue(8));
                            response.StateId = Convert.ToInt32(reader.GetValue(9));
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

        public static (List<QuotationList>, PageInfo) GetQuotationList(Adapter ad, int tenantId, int userId, string searchKey, Pager pager = null)
        {
            var response = new List<QuotationList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetQuotationList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
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
                            var result = new QuotationList();
                            result.QuotationId = Convert.ToInt32(reader.GetValue(0));
                            result.QuotationNo = reader.GetString(1);
                            result.QuotationDate = Convert.ToString(reader.GetValue(2));
                            result.CustomerName = reader.GetString(3);
                            result.QuotationTotal = Convert.ToDouble(reader.GetValue(4));
                            result.Status = reader.GetString(5);
                            result.QuotationStatusId = Convert.ToInt32(reader.GetValue(6));
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

        public static QuotationInfoView GetQuotationInfo(Adapter ad, int quotationId)
        {
            var response = new QuotationInfoView();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetQuotationInfo", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = quotationId, ParameterName = "@QuotationId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.StatusId = Convert.ToInt32(reader.GetValue(0));
                            response.StatusName = reader.GetString(1);
                            response.CustomerId = Convert.ToInt32(reader.GetValue(2));
                            response.CustomerName = reader.GetString(3);
                            response.QuotationTitle = reader.GetString(4);
                            response.QuotationNo = reader.GetString(5);
                            response.PONo = reader.GetString(6);
                            response.QuotationDate = Convert.ToString(reader.GetValue(7));
                            response.ExpiryDate = Convert.ToString(reader.GetValue(8));
                            response.Notes = reader.GetString(9);
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

        public static List<QuotationItemListResponse> GetQuotationItemList(Adapter ad, int quotationId)
        {
            var response = new List<QuotationItemListResponse>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetQuotationItemList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = quotationId, ParameterName = "@QuotationId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new QuotationItemListResponse();
                            result.ItemId = Convert.ToInt32(reader.GetValue(0));
                            result.ItemName = reader.GetString(1);
                            result.Quantity = Convert.ToInt32(reader.GetValue(2));
                            result.Price = Convert.ToDouble(reader.GetValue(3));
                            result.Amount = Convert.ToDouble(reader.GetValue(4));

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

        public static QuotationItemResponse GetQuotationItem(Adapter ad, int itemId)
        {
            var response = new QuotationItemResponse();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetQuotationItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = itemId, ParameterName = "@ItemId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ProductId = Convert.ToInt32(reader.GetValue(0));
                            response.ServiceId = Convert.ToInt32(reader.GetValue(1));
                            response.ItemName = reader.GetString(2);
                            response.Description = reader.GetString(3);
                            response.Quantity = Convert.ToInt32(reader.GetValue(4));
                            response.Price = Convert.ToDouble(reader.GetValue(5));
                            response.Total = Convert.ToDouble(reader.GetValue(6));
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

        public static (List<InvoiceList>, PageInfo) GetInvoiceList(Adapter ad, int tenantId, int userId, string searchKey, Pager pager = null)
        {
            var response = new List<InvoiceList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetInvoiceList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
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
                            var result = new InvoiceList();
                            result.InvoiceId = Convert.ToInt32(reader.GetValue(0));
                            result.InvoiceNo = reader.GetString(1);
                            result.InvoiceDate = Convert.ToString(reader.GetValue(2));
                            result.CustomerName = reader.GetString(3);
                            result.InvoiceTotal = Convert.ToDouble(reader.GetValue(4));
                            result.AmountDue = Convert.ToDouble(reader.GetValue(5));
                            result.Status = reader.GetString(6);

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

        public static InvoiceInfoView GetInvoiceInfo(Adapter ad, int invoiceId)
        {
            var response = new InvoiceInfoView();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetInvoiceInfo", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceId, ParameterName = "@InvoiceId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.StatusId = Convert.ToInt32(reader.GetValue(0));
                            response.StatusName = reader.GetString(1);
                            response.CustomerName = reader.GetString(2);
                            response.InvoiceTitle = reader.GetString(3);
                            response.InvoiceNo = reader.GetString(4);
                            response.PONo = reader.GetString(5);
                            response.InvoiceDate = Convert.ToString(reader.GetValue(6));
                            response.DueDate = Convert.ToString(reader.GetValue(7));
                            response.Reasons = reader.GetString(8);
                            response.CustomerId = Convert.ToInt32(reader.GetValue(9));
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

        public static List<InvoiceItemListResponse> GetInvoiceItemList(Adapter ad, int invoiceId)
        {
            var response = new List<InvoiceItemListResponse>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetInvoiceItemList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceId, ParameterName = "@InvoiceId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new InvoiceItemListResponse();
                            result.ItemId = Convert.ToInt32(reader.GetValue(0));
                            result.ItemName = reader.GetString(1);
                            result.Quantity = Convert.ToInt32(reader.GetValue(2));
                            result.Price = Convert.ToDouble(reader.GetValue(3));
                            result.Amount = Convert.ToDouble(reader.GetValue(4));

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

        public static InvoiceItemResponse GetInvoiceItem(Adapter ad, int itemId)
        {
            var response = new InvoiceItemResponse();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetInvoiceItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = itemId, ParameterName = "@ItemId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ProductId = Convert.ToInt32(reader.GetValue(0));
                            response.ServiceId = Convert.ToInt32(reader.GetValue(1));
                            response.ItemName = reader.GetString(2);
                            response.Description = reader.GetString(3);
                            response.Quantity = Convert.ToInt32(reader.GetValue(4));
                            response.Price = Convert.ToDouble(reader.GetValue(5));
                            response.Total = Convert.ToDouble(reader.GetValue(6));
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

        public static List<ProductList> GetProductList(Adapter ad, int tenantId)
        {
            var response = new List<ProductList>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Product_GetProductList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProductList();
                            result.ProductId = Convert.ToInt32(reader.GetValue(0));
                            result.ProductName = reader.GetString(2);
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

        public static List<ServicesList> GetServiceList(Adapter ad, int tenantId)
        {
            var response = new List<ServicesList>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Service_GetServiceList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ServicesList();
                            result.ServiceId = Convert.ToInt32(reader.GetValue(0));
                            result.ServiceName = reader.GetString(2);

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

        public static InvoicePaymentDue GetPaymentDue(Adapter ad, int invoiceId)
        {
            var response = new InvoicePaymentDue();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Service_GetPaymentDue", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceId, ParameterName = "@InvoiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.PaymentDue = Convert.ToDouble(reader.GetValue(0));
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

        public static List<ReceipListResponse> GetReceiptList(Adapter ad, int invoiceId)
        {
            var response = new List<ReceipListResponse>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetReceiptList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceId, ParameterName = "@InvoiceId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ReceipListResponse();
                            result.ReceiptId = Convert.ToInt32(reader.GetValue(0));
                            result.ReceiptDate = Convert.ToString(reader.GetValue(1));
                            result.PaymentMethod = reader.GetString(2);
                            result.Amount = Convert.ToDouble(reader.GetValue(3));

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

        public static InvoicePreview GetInvoicePreview(Adapter ad, int invoiceId)
        {
            var response = new InvoicePreview();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetInvoicePreview", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceId, ParameterName = "@InvoiceId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.TenantLogo = reader.GetString(0);
                            response.TenantName = reader.GetString(1);
                            response.TenantROCNo = reader.GetString(2);
                            response.CustomerName = reader.GetString(3);
                            response.CustomerAddress = reader.GetString(4);
                            response.InvoiceNo = reader.GetString(5);
                            response.InvoiceDate = Convert.ToString(reader.GetValue(6));
                            response.PaymentDue = Convert.ToString(reader.GetValue(7));
                            response.AmountDue = Convert.ToDouble(reader.GetValue(8));
                            response.Total = Convert.ToDouble(reader.GetValue(9));

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

        public static List<InvoiceItemPreview> GetInvoiceItemListPreview(Adapter ad, int invoiceId)
        {
            var response = new List<InvoiceItemPreview>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetInvoiceItemListPreview", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceId, ParameterName = "@InvoiceId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new InvoiceItemPreview();
                            result.ItemName = reader.GetString(0);
                            result.Quantity = Convert.ToInt32(reader.GetValue(1));
                            result.Price = Convert.ToDouble(reader.GetValue(2));
                            result.Amount = Convert.ToDouble(reader.GetValue(3));

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

        public static List<ReceiptItemPreview> GetReceiptListPreview(Adapter ad, int invoiceId)
        {
            var response = new List<ReceiptItemPreview>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetReceiptListPreview", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceId, ParameterName = "@InvoiceId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ReceiptItemPreview();
                            result.PaymentOn = Convert.ToString(reader.GetValue(0));
                            result.Amount = Convert.ToDouble(reader.GetValue(1));

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

        public static List<PaymentMethod> GetPaymentMethod(Adapter ad)
        {
            var response = new List<PaymentMethod>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetPaymentMethod", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new PaymentMethod();
                            result.PaymentMethodId = Convert.ToInt32(reader.GetValue(0));
                            result.MethodName = reader.GetString(1);

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

        public static ReceiptPreview GetReceiptPreview(Adapter ad, int receiptId)
        {
            var response = new ReceiptPreview();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetReceiptPreview", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = receiptId, ParameterName = "@ReceiptId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.TenantLogo = reader.GetString(0);
                            response.TenantName = reader.GetString(1);
                            response.TenantROCNo = reader.GetString(2);
                            response.ReceiptNo = reader.GetString(3);
                            response.CustomerName = reader.GetString(4);
                            response.ReceiptDate = Convert.ToString(reader.GetValue(5));
                            response.PaymentAmount = Convert.ToDouble(reader.GetValue(6));
                            response.PaymentMethod = reader.GetString(7);
                            response.Notes = reader.GetString(8);

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

        public static QuotationPreview GetQuotationPreview(Adapter ad, int quotationId)
        {
            var response = new QuotationPreview();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetQuotationPreview", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = quotationId, ParameterName = "@QuotationId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.TenantLogo = reader.GetString(0);
                            response.TenantName = reader.GetString(1);
                            response.TenantROCNo = reader.GetString(2);
                            response.CustomerName = reader.GetString(3);
                            response.CustomerAddress = reader.GetString(4);
                            response.QuotationNo = reader.GetString(5);
                            response.QuotationDate = Convert.ToString(reader.GetValue(6));
                            response.ExpiresOn = Convert.ToString(reader.GetValue(7));
                            response.GrandTotal = Convert.ToDouble(reader.GetValue(8));
                            response.Notes = reader.GetString(9);

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

        public static List<QuotationItemPreview> GetQuotationItemListPreview(Adapter ad, int quotationId)
        {
            var response = new List<QuotationItemPreview>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Finance_GetQuotationItemListPreview", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = quotationId, ParameterName = "@QuotationId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new QuotationItemPreview();
                            result.ItemName = reader.GetString(0);
                            result.Quantity = Convert.ToInt32(reader.GetValue(1));
                            result.Price = Convert.ToDouble(reader.GetValue(2));
                            result.Amount = Convert.ToDouble(reader.GetValue(3));

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
        public static BasicApiResponse UpdateTenantCustomer(Adapter ad, TenantCustomerUpdateRequest tenantCustomerUpdateRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_UpdateTenantCustomer", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerUpdateRequest.CustomerId, ParameterName = "@CustomerId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerUpdateRequest.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerUpdateRequest.Email, ParameterName = "@Email" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerUpdateRequest.Phone, ParameterName = "@Phone" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerUpdateRequest.PIC, ParameterName = "@PIC" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerUpdateRequest.Address1, ParameterName = "@Address1" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerUpdateRequest.Address2, ParameterName = "@Address2" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerUpdateRequest.City, ParameterName = "@City" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerUpdateRequest.Poscode, ParameterName = "@Poscode" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerUpdateRequest.CountryId, ParameterName = "@CountryId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCustomerUpdateRequest.StateId, ParameterName = "@StateId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static QuotationInfoResponse UpdateQuotationInfo(Adapter ad, QuotationInfoUpdateRequest quotationInfoUpdateRequest)
        {
            var response = new QuotationInfoResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_UpdateQuotationInfo", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoUpdateRequest.QuotationId, ParameterName = "@QuotationId" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoUpdateRequest.CustomerId, ParameterName = "@CustomerId" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoUpdateRequest.QuotationTitle, ParameterName = "@QuotationTitle" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoUpdateRequest.QuotationNo, ParameterName = "@QuotationNo" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoUpdateRequest.PONo, ParameterName = "@PONo" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoUpdateRequest.QuotationDate, ParameterName = "@QuotationDate" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoUpdateRequest.ExpiryDate, ParameterName = "@ExpiryDate" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationInfoUpdateRequest.Notes, ParameterName = "@Notes" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static QuotationInfoResponse UpdateQuotationItem(Adapter ad, QuotationItemUpdateRequest quotationItemUpdateRequest)
        {
            var response = new QuotationInfoResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_UpdateQuotationItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = quotationItemUpdateRequest.QuotationItemId, ParameterName = "@QuotationItemId" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemUpdateRequest.ProductId, ParameterName = "@ProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemUpdateRequest.ServiceId, ParameterName = "@ServiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemUpdateRequest.ItemName, ParameterName = "@ItemName" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemUpdateRequest.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemUpdateRequest.Quantity, ParameterName = "@Quantity" });
                    command.Parameters.Add(new SqlParameter() { Value = quotationItemUpdateRequest.Price, ParameterName = "@Price" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static BasicApiResponse UpdateInvoiceInfo(Adapter ad, InvoiceInfoUpdateRequest invoiceInfoUpdateRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_UpdateInvoiceInfo", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoUpdateRequest.InvoiceId, ParameterName = "@InvoiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoUpdateRequest.CustomerId, ParameterName = "@CustomerId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoUpdateRequest.InvoiceTitle, ParameterName = "@InvoiceTitle" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoUpdateRequest.InvoiceNo, ParameterName = "@InvoiceNo" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoUpdateRequest.PONo, ParameterName = "@PONo" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoUpdateRequest.InvoiceDate, ParameterName = "@InvoiceDate" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceInfoUpdateRequest.PaymentDue, ParameterName = "@PaymentDue" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static BasicApiResponse UpdateInvoiceItem(Adapter ad, InvoiceItemUpdateRequest invoiceItemUpdateRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_UpdateInvoiceItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemUpdateRequest.InvoiceItemId, ParameterName = "@InvoiceItemId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemUpdateRequest.ProductId, ParameterName = "@ProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemUpdateRequest.ServiceId, ParameterName = "@ServiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemUpdateRequest.ItemName, ParameterName = "@ItemName" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemUpdateRequest.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemUpdateRequest.Quantity, ParameterName = "@Quantity" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceItemUpdateRequest.Price, ParameterName = "@Price" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static BasicApiResponse ApproveInvoice(Adapter ad, InvoiceToApprove invoiceToApprove)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_ApproveInvoice", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceToApprove.InvoiceId, ParameterName = "@InvoiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceToApprove.Reason, ParameterName = "@Reason" });
                    command.Parameters.Add(new SqlParameter() { Value = invoiceToApprove.StatusId, ParameterName = "@StatusId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static BasicApiResponse ConfirmInvoice(Adapter ad, InvoiceToConfirm invoiceToConfirm)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_ConfirmInvoice", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceToConfirm.InvoiceId, ParameterName = "@InvoiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static BasicApiResponse SendQuotation(Adapter ad, QuotationToConfirm quotationToConfirm)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_SendQuotation", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = quotationToConfirm.QuotationId, ParameterName = "@QuotationId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static InvoiceIdAfterConvert ConvertQuotation(Adapter ad, QuotationToConfirm quotationToConfirm)
        {
            var response = new InvoiceIdAfterConvert();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_ConvertQuotation", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = quotationToConfirm.QuotationId, ParameterName = "@QuotationId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.InvoiceId =  Convert.ToInt32(reader.GetValue(2));
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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
        public static BasicApiResponse DeleteCustomerList(Adapter ad, int customerId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_DeleteCustomer", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = customerId, ParameterName = "@CustomerId" });

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

        public static BasicApiResponse DeleteQuotationItemList(Adapter ad, int itemId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_DeleteQuotationItemList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = itemId, ParameterName = "@QuotationItemId" });

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

        public static BasicApiResponse DeleteQuotationList(Adapter ad, int quotationId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_DeleteQuotationList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = quotationId, ParameterName = "@QuotationId" });

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

        public static BasicApiResponse DeleteInvoiceList(Adapter ad, int invoiceId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_DeleteInvoiceList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = invoiceId, ParameterName = "@InvoiceId" });

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

        public static BasicApiResponse DeleteInvoiceItemList(Adapter ad, int itemId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_DeleteInvoiceItemList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = itemId, ParameterName = "@InvoiceItemId" });

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

        public static BasicApiResponse DeleteReceiptList(Adapter ad, int receiptId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Finance_DeleteReceiptList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = receiptId, ParameterName = "@ReceiptId" });

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
    }
}
