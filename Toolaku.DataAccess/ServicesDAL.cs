using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.Service;
using Toolaku.Models.Services;
using Toolaku.Models.Pagingnation;

namespace Toolaku.DataAccess
{
    public class ServicesDAL
    {
        //--------------GET Method--------------

        /*
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
                        result.serviceId = Convert.ToInt32(reader.GetValue(0));
                        if (reader.GetValue(1).ToString() != "")
                        {
                            result.imageURL = reader.GetString(1);
                        }
                        else
                        {
                            result.imageURL = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                        }
                        result.serviceName = reader.GetString(2);
                        result.serviceNo = reader.GetString(3);
                        if (reader.GetValue(4).ToString() != "")
                        {
                            result.category = reader.GetString(4);
                        }
                        else
                        {
                            result.category = "";
                        }
                        result.listing = Convert.ToBoolean(reader.GetValue(5));

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

        public static (List<ServicesList>, PageInfo) GetServiceList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<ServicesList>();
            var response2 = new PageInfo();
            
            try
            {

                using (SqlCommand command = new SqlCommand("sp_Service_GetServiceList", ad.SQLConn, ad.SQLTran))
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
                            var result = new ServicesList();
                            result.serviceId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.imageURL = reader.GetString(1);
                            }
                            else
                            {
                                result.imageURL = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            result.serviceName = reader.GetString(2);
                            result.serviceNo = reader.GetString(3);
                            if (reader.GetValue(4).ToString() != "")
                            {
                                result.category = reader.GetString(4);
                            }
                            else
                            {
                                result.category = "";
                            }
                            result.listing = Convert.ToBoolean(reader.GetValue(5));

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

        public static List<ServiceGeneral> GetServiceGeneralInfo(Adapter ad, int serviceId)
        {
            var response = new List<ServiceGeneral>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Service_GetBasicInfo ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ServiceGeneral();
                            result.serviceName = reader.GetString(0);
                            result.shortDescription = reader.GetString(1);
                            result.serviceNo = reader.GetString(2);
                            result.activeStatus = Convert.ToBoolean(reader.GetValue(3));

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

        public static List<ServiceImageList> GetServiceImage(Adapter ad, int serviceId)
        {
            var response = new List<ServiceImageList>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Service_GetServiceImage ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ServiceImageList();
                            result.serviceImageId = Convert.ToInt16(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.imageURL = reader.GetString(1);
                            }
                            else
                            {
                                result.imageURL = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            result.isDefault = Convert.ToBoolean(reader.GetValue(2));

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

        public static List<ServiceVariant> GetServiceVariantList(Adapter ad, int serviceId)
        {
            var response = new List<ServiceVariant>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Service_GetServiceVariantList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ServiceVariant();
                            result.serviceVariantId = Convert.ToInt32(reader.GetValue(0));
                            result.name = Convert.ToString(reader.GetValue(1));
                            result.description = Convert.ToString(reader.GetValue(2));
                            result.serviceId = Convert.ToInt32(reader.GetValue(3));
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

        public static ServiceVariant GetServiceVariantDetails(Adapter ad, int serviceVariantId)
        {
            var response = new ServiceVariant();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Service_GetServiceVariantDetails ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceVariantId, ParameterName = "@serviceVariantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.serviceVariantId = Convert.ToInt32(reader.GetValue(0));
                            response.name = Convert.ToString(reader.GetValue(1));
                            response.description = Convert.ToString(reader.GetValue(2));
                            response.serviceId = Convert.ToInt32(reader.GetValue(3));
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

        public static TenantServiceCategory GetServiceCategory(Adapter ad, int serviceId)
        {
            var response = new TenantServiceCategory();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Service_GetCategory ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetValue(0).ToString() != string.Empty)
                            {
                                response.level1CatId = reader.GetInt32(0);
                            }
                            else
                            {
                                response.level1CatId = 0;
                            }
                            if (reader.GetValue(1).ToString() != string.Empty)
                            {
                                response.level2CatId = reader.GetInt32(1);
                            }
                            else
                            {
                                response.level2CatId = 0;
                            }

                            if (reader.GetValue(2).ToString() != string.Empty)
                            {
                                response.level3CatId = reader.GetInt32(2);
                            }
                            else
                            {
                                response.level3CatId = 0;
                            }
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

        public static ServiceDescription GetServiceDescription(Adapter ad, int serviceId)
        {
            var response = new ServiceDescription();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Service_GetServiceDescription ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.serviceId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != string.Empty)
                            {
                                response.description = reader.GetString(1);
                            }
                            else
                            {
                                response.description = string.Empty;
                            }
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
        public static List<CoverageList> GetServiceCoverageList(Adapter ad, int serviceId)
        {
            var response = new List<CoverageList>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Service_GetCoverageList ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new CoverageList();

                            result.coverageId = Convert.ToInt32(reader.GetValue(0));
                            result.countryName = Convert.ToString(reader.GetValue(1));
                            result.stateName = Convert.ToString(reader.GetValue(2));
                            result.cityName = Convert.ToString(reader.GetValue(3));

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

        public static (List<CoverageList>, PageInfo)   GetServiceCoverageList(Adapter ad, int serviceId, string searchKey, Pager pager = null)
        {
            var response = new List<CoverageList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Service_GetCoverageList ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });
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
                            var result = new CoverageList();

                            result.coverageId = Convert.ToInt32(reader.GetValue(0));
                            result.countryName = Convert.ToString(reader.GetValue(1));
                            result.stateName = Convert.ToString(reader.GetValue(2));
                            result.cityName = Convert.ToString(reader.GetValue(3));

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
        public static BasicApiResponse DeleteServiceList(Adapter ad, int serviceId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_DeleteService ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

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

        public static BasicApiResponse EnlistService(Adapter ad, int serviceId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_EnlistService ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

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

        public static PostApiResponse UpdateServiceGeneral(Adapter ad, ServiceGeneralUpdate serviceGeneralUpdate)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_UpdateServiceBasic", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceGeneralUpdate.serviceId, ParameterName = "@ServiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceGeneralUpdate.serviceName, ParameterName = "@ServiceName" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceGeneralUpdate.shortDescription, ParameterName = "@ShortDescription" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceGeneralUpdate.serviceNo, ParameterName = "@ServiceNo" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceGeneralUpdate.activeStatus, ParameterName = "@ActiveStatus" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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

        public static BasicApiResponse UpdateServiceCategory(Adapter ad, TenantServiceCategoryUpdate tenantserviceCategoryUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_UpdateServiceCategory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantserviceCategoryUpdate.serviceId, ParameterName = "@ServiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantserviceCategoryUpdate.level1CatId, ParameterName = "@Level1CatId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantserviceCategoryUpdate.level2CatId, ParameterName = "@Level2CatId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantserviceCategoryUpdate.level3CatId, ParameterName = "@Level3CatId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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

        public static BasicApiResponse UpdateServiceDescription(Adapter ad, ServiceDescriptionUpdate serviceDescriptionUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_UpdateServiceDescription", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceDescriptionUpdate.serviceId, ParameterName = "@ServiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceDescriptionUpdate.description, ParameterName = "@Description" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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

        public static BasicApiResponse UpdateServiceVariant(Adapter ad, ServiceVariant serviceVariant)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_UpdateServiceVariant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceVariant.serviceVariantId, ParameterName = "@ServiceVariantId" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceVariant.name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceVariant.description, ParameterName = "@Description" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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

        public static BasicApiResponse DeleteServiceVariantList(Adapter ad, int serviceVariantId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_DeleteServiceVariant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceVariantId, ParameterName = "@ServiceVariantId" });

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

        public static BasicApiResponse DeleteCoverageList(Adapter ad, int coverageId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_DeleteServiceCoverage ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = coverageId, ParameterName = "@CoverageId" });

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
        public static PostApiResponse InsertServiceGeneral(Adapter ad, int tenantId, ServiceGeneralRequest serviceGeneralRequest)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_InsertServiceBasic", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceGeneralRequest.serviceName, ParameterName = "@ServiceName" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceGeneralRequest.shortDescription, ParameterName = "@ShortDescription" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceGeneralRequest.serviceNo, ParameterName = "@ServiceNo" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceGeneralRequest.activeStatus, ParameterName = "@ActiveStatus" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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

        public static PostApiResponse InsertServiceVariant(Adapter ad, int tenantServiceId, ServiceVariant serviceVariantRequest)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_InsertServiceVariant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantServiceId, ParameterName = "@ServiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceVariantRequest.name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = serviceVariantRequest.description, ParameterName = "@Description" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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

        public static BasicApiResponse InsertServiceImage(Adapter ad, int serviceId, string imageURL, bool isDefault)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_InsertServiceImage", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = imageURL, ParameterName = "@ImageURL" });
                    command.Parameters.Add(new SqlParameter() { Value = isDefault, ParameterName = "@IsDefault" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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

        public static PostApiResponse InsertServiceCoverage(Adapter ad, CoverageDetailInsert coverageDetail)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_InsertServiceCoverageDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = coverageDetail.serviceId, ParameterName = "@ServiceId" });
                    command.Parameters.Add(new SqlParameter() { Value = coverageDetail.countryId, ParameterName = "@CountryId" });
                    command.Parameters.Add(new SqlParameter() { Value = coverageDetail.stateId, ParameterName = "@StateId" });
                    command.Parameters.Add(new SqlParameter() { Value = coverageDetail.cityId, ParameterName = "@CityId" });
                    command.Parameters.Add(new SqlParameter() { Value = coverageDetail.city, ParameterName = "@city" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                            response.Id = reader.GetInt32(2);
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
        public static BasicApiResponse DeleteServiceImageAll(Adapter ad, int serviceId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_DeleteServiceImageAll", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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

        public static BasicApiResponse DeleteServiceImage(Adapter ad, int serviceImageId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_DeleteServiceImage", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceImageId, ParameterName = "@ServiceImageId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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


        public static BasicApiResponse DeleteServiceVariant(Adapter ad, int serviceVariantId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Service_DeleteServiceVariant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceVariantId, ParameterName = "@ServiceVariantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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
