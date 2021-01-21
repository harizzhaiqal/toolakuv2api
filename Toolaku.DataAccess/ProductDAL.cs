using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Toolaku.Library;
using Toolaku.Models;
using Toolaku.Models.DTO;
using Toolaku.Models.Product;
using Toolaku.Models.Pagingnation;

namespace Toolaku.DataAccess
{
    public class ProductDAL
    {
        //--------------GET Method--------------

        /*
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
                        result.productId = Convert.ToInt32(reader.GetValue(0));
                        if (reader.GetValue(1).ToString() != "")
                        {
                            result.imageURL = reader.GetString(1);
                        }
                        else
                        {
                            result.imageURL = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                        }
                        result.productName = reader.GetString(2);
                        result.skuNo = reader.GetString(3);
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

        public static (List<ProductList>, PageInfo)  GetProductList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<ProductList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Product_GetProductList", ad.SQLConn, ad.SQLTran))
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
                            var result = new ProductList();
                            result.productId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.imageURL = reader.GetString(1);
                            }
                            else
                            {
                                result.imageURL = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            result.productName = reader.GetString(2);
                            result.skuNo = reader.GetString(3);
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

        public static List<ProductGeneral> GetProductGeneralInfo(Adapter ad, int productId)
        {
            var response = new List<ProductGeneral>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Product_GetBasicInfo ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProductGeneral();
                            result.productName = reader.GetString(0);
                            result.shortDescription = reader.GetString(1);
                            result.skuNo = reader.GetString(2);
                            result.brand = reader.GetString(3);
                            result.modelNo = reader.GetString(4);
                            result.conditionId = Convert.ToInt16(reader.GetValue(5));
                            result.productMaterialId = Convert.ToInt16(reader.GetValue(6));
                            result.countryOriginId = Convert.ToInt16(reader.GetValue(7));
                            result.activeStatus = Convert.ToBoolean(reader.GetValue(8));

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

        public static List<ProductVariant> GetProductVariantList(Adapter ad, int productId)
        {
            var response = new List<ProductVariant>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Product_GetProductVariantList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProductVariant();
                            result.productVariantId = Convert.ToInt32(reader.GetValue(0));
                            result.name = Convert.ToString(reader.GetValue(1));
                            result.description = Convert.ToString(reader.GetValue(2));
                            result.productId = Convert.ToInt32(reader.GetValue(3));
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

        public static ProductVariant GetProductVariantDetails(Adapter ad, int productVariantId)
        {
            var response = new ProductVariant();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Product_GetProductVariantDetails ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productVariantId, ParameterName = "@productVariantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.productVariantId = Convert.ToInt32(reader.GetValue(0));
                            response.name = Convert.ToString(reader.GetValue(1));
                            response.description = Convert.ToString(reader.GetValue(2));
                            response.productId = Convert.ToInt32(reader.GetValue(3));
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

        public static List<ProductImageList> GetProductImage(Adapter ad, int productId)
        {
            var response = new List<ProductImageList>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetProductImage ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProductImageList();
                            result.productImageId = Convert.ToInt16(reader.GetValue(0));
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

        public static TenantProductCategory GetProductCategory(Adapter ad, int productId)
        {
            var response = new TenantProductCategory();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Product_GetCategory ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

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

        public static ProductDescription GetProductDescription(Adapter ad, int productId)
        {
            var response = new ProductDescription();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Product_GetProductDescription ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.productId = Convert.ToInt32(reader.GetValue(0));
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
         public static (List<ProductList>, PageInfo)  GetProductList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<ProductList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Product_GetProductList", ad.SQLConn, ad.SQLTran))
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
                            var result = new ProductList();
                            result.productId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.imageURL = reader.GetString(1);
                            }
                            else
                            {
                                result.imageURL = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            result.productName = reader.GetString(2);
                            result.skuNo = reader.GetString(3);
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
        */


        public static (List<Inventory>, PageInfo)  GetProductInventoryList(Adapter ad, int productId, string searchKey, Pager pager = null)
        {
            var response = new List<Inventory>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Product_GetProductInventoryList ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });
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
                            var result = new Inventory();
                            result.inventoryId = Convert.ToInt32(reader.GetValue(0));
                            result.availableStock = Convert.ToInt32(reader.GetValue(1));
                            result.moq = Convert.ToInt32(reader.GetValue(2));
                            result.uom = Convert.ToString(reader.GetValue(3));
                            result.priceUnit = Convert.ToDecimal(reader.GetValue(4));
                            result.stockLocation = (reader.GetValue(5) == DBNull.Value) ? "" : Convert.ToString(reader.GetValue(5));

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

        public static ProductInventory GetProductInventoryDetail(Adapter ad, int inventorytId)
        {
            var response = new ProductInventory();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Product_GetProductInventoryDetail ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = inventorytId, ParameterName = "@InventoryId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.availableStock = Convert.ToInt32(reader.GetValue(0));
                            response.moq = Convert.ToInt32(reader.GetValue(1));
                            response.uomId = Convert.ToInt32(reader.GetValue(2));
                            response.priceUnit = Convert.ToDecimal(reader.GetValue(3));
                            response.countryId = Convert.ToInt32(reader.GetValue(4));
                            response.stateId = Convert.ToInt32(reader.GetValue(5));
                            response.cityId = Convert.ToInt32(reader.GetValue(6));
                            response.city = Convert.ToString(reader.GetValue(7));
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
        public static BasicApiResponse DeleteProductList(Adapter ad, int productId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_DeleteProduct ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

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

        public static BasicApiResponse EnlistProduct(Adapter ad, int productId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_EnlistProduct ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

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

        public static PostApiResponse UpdateProductGeneral(Adapter ad, ProductGeneralUpdate productGeneralUpdate)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_UpdateProductBasic", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productGeneralUpdate.productId, ParameterName = "@ProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralUpdate.productName, ParameterName = "@ProductName" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralUpdate.shortDescription, ParameterName = "@ShortDescription" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralUpdate.skuNo, ParameterName = "@SKUNo" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralUpdate.brand, ParameterName = "@Brand" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralUpdate.modelNo, ParameterName = "@ModelNo" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralUpdate.conditionId, ParameterName = "@ConditionId" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralUpdate.productMaterialId, ParameterName = "@ProductMaterialId" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralUpdate.countryOriginId, ParameterName = "@CountryOriginId" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralUpdate.activeStatus, ParameterName = "@ActiveStatus" });

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

        public static BasicApiResponse UpdateProductCategory(Adapter ad, TenantProductCategoryUpdate tenantProductCategoryUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_UpdateProductCategory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantProductCategoryUpdate.productId, ParameterName = "@ProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantProductCategoryUpdate.level1CatId, ParameterName = "@Level1CatId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantProductCategoryUpdate.level2CatId, ParameterName = "@Level2CatId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantProductCategoryUpdate.level3CatId, ParameterName = "@Level3CatId" });

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

        public static BasicApiResponse UpdateProductDescription(Adapter ad, ProductDescriptionUpdate productDescriptionUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_UpdateProductDescription", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productDescriptionUpdate.productId, ParameterName = "@ProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = productDescriptionUpdate.description, ParameterName = "@Description" });

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


        public static BasicApiResponse UpdateProductVariant(Adapter ad, ProductVariant productVariant)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_UpdateProductVariant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productVariant.productVariantId, ParameterName = "@ProductVariantId" });
                    command.Parameters.Add(new SqlParameter() { Value = productVariant.name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = productVariant.description, ParameterName = "@Description" });

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

        public static BasicApiResponse DeleteProductVariantList(Adapter ad, int productVariantId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_DeleteProductVariant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productVariantId, ParameterName = "@ProductVariantId" });

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


        public static BasicApiResponse UpdateProductInventory(Adapter ad, ProductInventoryUp productInventoryUp)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_UpdateProductInventoryDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productInventoryUp.inventoryId, ParameterName = "@InventoryId" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryUp.availableStock, ParameterName = "@AvailableStock" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryUp.moq, ParameterName = "@Moq" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryUp.uomId, ParameterName = "@UomId" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryUp.priceUnit, ParameterName = "@PriceUnit" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryUp.countryId, ParameterName = "@CountryId" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryUp.stateId, ParameterName = "@StateId" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryUp.cityId, ParameterName = "@CityId" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryUp.city, ParameterName = "@City" });

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


        //--------------POST Method--------------
        public static PostApiResponse InsertProductGeneral(Adapter ad, int tenantId, ProductGeneralRequest productGeneralRequest)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_InsertProductBasic", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralRequest.productName, ParameterName = "@ProductName" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralRequest.shortDescription, ParameterName = "@ShortDescription" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralRequest.skuNo, ParameterName = "@SKUNo" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralRequest.brand, ParameterName = "@Brand" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralRequest.modelNo, ParameterName = "@ModelNo" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralRequest.conditionId, ParameterName = "@ConditionId" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralRequest.productMaterialId, ParameterName = "@ProductMaterialId" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralRequest.countryOriginId, ParameterName = "@CountryOriginId" });
                    command.Parameters.Add(new SqlParameter() { Value = productGeneralRequest.activeStatus, ParameterName = "@ActiveStatus" });

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



        public static PostApiResponse InsertProductVariant(Adapter ad, int tenantProductId, ProductVariant productVariantRequest)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_InsertProductVariant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantProductId, ParameterName = "@ProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = productVariantRequest.name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = productVariantRequest.description, ParameterName = "@Description" });

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



        public static BasicApiResponse InsertProductImage(Adapter ad, int productId, string imageURL, bool isDefault)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_InsertProductImage", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });
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

        public static BasicApiResponse InsertProductInventory(Adapter ad, ProductInventoryIn productInventoryIn)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_InsertProductInventoryDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productInventoryIn.productId, ParameterName = "@ProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryIn.availableStock, ParameterName = "@AvailableStock" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryIn.moq, ParameterName = "@Moq" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryIn.uomId, ParameterName = "@UomId" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryIn.priceUnit, ParameterName = "@PriceUnit" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryIn.countryId, ParameterName = "@CountryId" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryIn.stateId, ParameterName = "@StateId" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryIn.cityId, ParameterName = "@CityId" });
                    command.Parameters.Add(new SqlParameter() { Value = productInventoryIn.city, ParameterName = "@City" });

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



        //--------------DELETE Method--------------
        public static BasicApiResponse DeleteProductImage(Adapter ad, int productImageId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_DeleteProductImage", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productImageId, ParameterName = "@ProductImageId" });

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

        public static BasicApiResponse DeleteProductImageAll(Adapter ad, int productId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_DeleteProductImageAll", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

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

        public static BasicApiResponse DeleteInventoryList(Adapter ad, int inventoryId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_DeleteProductInventory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = inventoryId, ParameterName = "@InventoryId" });

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

        public static BasicApiResponse DeleteProductVariant(Adapter ad, int productVariantId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Product_DeleteProductVariant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productVariantId, ParameterName = "@ProductVariantId" });

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
