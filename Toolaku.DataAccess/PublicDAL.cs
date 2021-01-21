using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using Toolaku.Library;
using Toolaku.Models.Public;
using Toolaku.Models.DTO;
using Toolaku.Models.Sale;
using Toolaku.Models.Pagingnation;

namespace Toolaku.DataAccess
{
    public class PublicDAL
    {
        public static List<CategoryTop10> GetCategoryTop10(Adapter ad)
        {
            var categoryTop10s = new List<CategoryTop10>();
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetCategoryTop10", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoryTop10 = new CategoryTop10();

                            if (reader.GetValue(0).ToString() != "")
                            {
                                categoryTop10.IconURL = reader.GetString(0);
                            }
                            else
                            {
                                categoryTop10.IconURL = string.Empty;
                            }
                            categoryTop10.CategoryId = reader.GetInt32(1);
                            categoryTop10.CategoryName = (reader.GetString(2)).ToUpper();
                            categoryTop10.CategoryType = textInfo.ToTitleCase(reader.GetString(3));
                            categoryTop10.ShortDescription = reader.GetString(4);
                            

                            categoryTop10s.Add(categoryTop10);
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
            return categoryTop10s;
        }

        public static List<CategoryHierarchy> GetAllGategory(Adapter ad)
        {
            var categoryHierarchys = new List<CategoryHierarchy>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetAllCategory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoryHierarchy = new CategoryHierarchy
                            {
                                TypeName = reader.GetString(0),
                                CategoryId = reader.GetInt32(1),
                                CategoryName = (reader.GetString(2)).ToUpper(),
                                ShortDescription = reader.GetString(3)
                            };

                            categoryHierarchys.Add(categoryHierarchy);
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
            return categoryHierarchys;
        }

        public static List<RecommendedItem> GetRecommendedProduct(Adapter ad)
        {
            var recommendedItems = new List<RecommendedItem>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetRecommendedProduct", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var recommendedItem = new RecommendedItem();

                            recommendedItem.ProductId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                recommendedItem.DefaultImage = reader.GetString(1);
                            }
                            else
                            {
                                recommendedItem.DefaultImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            if (reader.GetValue(2).ToString() != "")
                            {
                                recommendedItem.AdditionalImage = reader.GetString(2);
                            }
                            else
                            {
                                recommendedItem.AdditionalImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            recommendedItem.ProductName = reader.GetString(3);
                            recommendedItem.ShortDescription = reader.GetString(4);
                            recommendedItem.TenantId = Convert.ToInt32(reader.GetValue(5));
                            recommendedItem.TenantName = reader.GetString(6);

                            recommendedItems.Add(recommendedItem);
                        }
                        reader.Close();
                    }

                }

                //Add Temporary Data
                var itemBalance = 12 - recommendedItems.Count;

                for (int i = 0; i < itemBalance; i++)
                {
                    var tempItem = new RecommendedItem();

                    tempItem.ProductId = 0;
                    tempItem.DefaultImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                    tempItem.AdditionalImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                    tempItem.ProductName = "Coming Soon";
                    tempItem.ShortDescription = "An exciting product will be here soon";
                    tempItem.TenantId = 0;
                    tempItem.TenantName = "";

                    recommendedItems.Add(tempItem);
                }



            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return recommendedItems;
        }

        public static List<RecommendedItem> GetRecommendedService(Adapter ad)
        {
            var recommendedItems = new List<RecommendedItem>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetRecommendedService", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var recommendedItem = new RecommendedItem();

                            recommendedItem.ProductId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                recommendedItem.DefaultImage = reader.GetString(1);
                            }
                            else
                            {
                                recommendedItem.DefaultImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            if (reader.GetValue(2).ToString() != "")
                            {
                                recommendedItem.AdditionalImage = reader.GetString(2);
                            }
                            else
                            {
                                recommendedItem.AdditionalImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            recommendedItem.ProductName = reader.GetString(3);
                            recommendedItem.ShortDescription = reader.GetString(4);
                            recommendedItem.TenantId = Convert.ToInt32(reader.GetValue(5));
                            recommendedItem.TenantName = reader.GetString(6);

                            recommendedItems.Add(recommendedItem);
                        }
                        reader.Close();
                    }

                }

                var itemBalance = 12 - recommendedItems.Count;

                for (int i = 0; i < itemBalance; i++)
                {
                    var tempItem = new RecommendedItem();

                    tempItem.ProductId = 0;
                    tempItem.DefaultImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                    tempItem.AdditionalImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                    tempItem.ProductName = "Coming Soon";
                    tempItem.ShortDescription = "Coming soon!!";
                    tempItem.TenantId = 0;
                    tempItem.TenantName = "";

                    recommendedItems.Add(tempItem);
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return recommendedItems;
        }

        public static List<RFQTenderSummary> GetRfqSummary(Adapter ad)
        {
            var rfqSummaryList = new List<RFQTenderSummary>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetRfqSummary", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var rfqSummary = new RFQTenderSummary();

                            rfqSummary.Id = Convert.ToInt32(reader.GetValue(0));
                            rfqSummary.OfferType = reader.GetString(1);
                            rfqSummary.Agency = reader.GetString(2);
                            rfqSummary.Title = reader.GetString(3);
                            rfqSummary.ClosingDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(4)).ToString("dd MMM yyyy"));
                            rfqSummaryList.Add(rfqSummary);

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
            return rfqSummaryList;
        }

        public static List<RFQTenderSummary> GetTenderSummary(Adapter ad)
        {
            var tenderSummaryList = new List<RFQTenderSummary>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetTenderSummary", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tenderSummary = new RFQTenderSummary();

                            tenderSummary.Id = Convert.ToInt32(reader.GetValue(0));
                            tenderSummary.OfferType = reader.GetString(1);
                            tenderSummary.Agency = reader.GetString(2);
                            tenderSummary.Title = reader.GetString(3);
                            tenderSummary.ClosingDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(4)).ToString("dd MMM yyyy"));
                            tenderSummaryList.Add(tenderSummary);
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
            return tenderSummaryList;
        }
        /*
        public static List<SearchItem> GetSearchItem(Adapter ad, string searchKeyword, string itemType)
        {
            var searchItems = new List<SearchItem>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetSearchItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = searchKeyword, ParameterName = "@Keyword" });
                    command.Parameters.Add(new SqlParameter() { Value = itemType.ToUpper(), ParameterName = "@ItemType" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var searchItem = new SearchItem();

                            searchItem.Id = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                searchItem.ItemImage = reader.GetString(1);
                            }
                            else
                            {
                                searchItem.ItemImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            searchItem.Name = reader.GetString(2);
                            searchItem.Category = reader.GetString(3);
                            searchItem.ShortDescription = (reader.GetString(4)).ToUpper();
                            searchItem.CompanyId = Convert.ToInt32(reader.GetValue(5));
                            searchItem.CompanyName = reader.GetString(6);
                            searchItem.Location = reader.GetString(7);

                            searchItems.Add(searchItem);
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
            return searchItems;
        }
        */

        public static (List<SearchItem>, PageInfo) GetSearchItem(Adapter ad, string searchKeyword, string itemType, Pager pager = null)
        {
            var searchItems = new List<SearchItem>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetSearchItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = searchKeyword, ParameterName = "@Keyword" });
                    command.Parameters.Add(new SqlParameter() { Value = itemType.ToUpper(), ParameterName = "@ItemType" });

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
                            var searchItem = new SearchItem();

                            searchItem.Id = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                searchItem.ItemImage = reader.GetString(1);
                            }
                            else
                            {
                                searchItem.ItemImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            searchItem.Name = reader.GetString(2);
                            searchItem.Category = reader.GetString(3);
                            searchItem.ShortDescription = (reader.GetString(4)).ToUpper();
                            searchItem.CompanyId = Convert.ToInt32(reader.GetValue(5));
                            searchItem.CompanyName = reader.GetString(6);
                            searchItem.Location = reader.GetString(7);
                            if (reader.GetValue(8).ToString() != "")
                            {
                                searchItem.ItemImageAlt = reader.GetString(8);
                            }
                            else
                            {
                                searchItem.ItemImageAlt = "";
                            }

                            searchItems.Add(searchItem);
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
           return (searchItems, response2);
        }


        public static List<ProductCategory> GetProductCategory(Adapter ad, int categoryId)
        {
            var productCategories = new List<ProductCategory>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetProductCategory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = categoryId, ParameterName = "@CategoryId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productCategory = new ProductCategory();
                            productCategory.ParentCategoryName = Convert.ToString(reader.GetValue(0));
                            productCategory.ParentCategoryId = Convert.ToInt32(reader.GetValue(1));
                            productCategory.CategoryId = Convert.ToInt32(reader.GetValue(2));
                            productCategory.CategoryName = Convert.ToString(reader.GetValue(3));

                            productCategories.Add(productCategory);
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
            return productCategories;
        }

        public static List<ProductByCategory> GetProductListByCategory(Adapter ad, int categoryId)
        {
            var productByCategories = new List<ProductByCategory>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetProductListByCategory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = categoryId, ParameterName = "@CategoryId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productByCategory = new ProductByCategory();

                            productByCategory.Id = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                productByCategory.ItemImage = reader.GetString(1);
                            }
                            else
                            {
                                productByCategory.ItemImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            if (reader.GetValue(2).ToString() != "")
                            {
                                productByCategory.ItemImage2 = reader.GetString(2);
                            }
                            else
                            {
                                productByCategory.ItemImage2 = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            productByCategory.Name = reader.GetString(3);
                            productByCategory.Category = reader.GetString(4);
                            productByCategory.ShortDescription = (reader.GetString(5)).ToUpper();
                            productByCategory.CompanyId = Convert.ToInt32(reader.GetValue(6));
                            productByCategory.CompanyName = reader.GetString(7);
                            productByCategory.Location = reader.GetString(8);

                            productByCategories.Add(productByCategory);
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
            return productByCategories;
        }

        public static List<ServiceCategory> GetServiceCategory(Adapter ad, int categoryId)
        {
            var serviceCategories = new List<ServiceCategory>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetServiceCategory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = categoryId, ParameterName = "@CategoryId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var serviceCategory = new ServiceCategory();
                            serviceCategory.ParentCategoryName = Convert.ToString(reader.GetValue(0));
                            serviceCategory.ParentCategoryId = Convert.ToInt32(reader.GetValue(1));
                            serviceCategory.CategoryId = Convert.ToInt32(reader.GetValue(2));
                            serviceCategory.CategoryName = Convert.ToString(reader.GetValue(3));

                            serviceCategories.Add(serviceCategory);
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
            return serviceCategories;
        }

        public static List<ServiceByCategory> GetServiceListByCategory(Adapter ad, int categoryId)
        {
            var serviceByCategories = new List<ServiceByCategory>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetServiceListByCategory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = categoryId, ParameterName = "@CategoryId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var serviceByCategory = new ServiceByCategory();

                            serviceByCategory.Id = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                serviceByCategory.ItemImage = reader.GetString(1);
                            }
                            else
                            {
                                serviceByCategory.ItemImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            if (reader.GetValue(2).ToString() != "")
                            {
                                serviceByCategory.ItemImage2 = reader.GetString(2);
                            }
                            else
                            {
                                serviceByCategory.ItemImage2 = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            serviceByCategory.Name = reader.GetString(3);
                            serviceByCategory.Category = reader.GetString(4);
                            serviceByCategory.ShortDescription = (reader.GetString(5)).ToUpper();
                            serviceByCategory.CompanyId = Convert.ToInt32(reader.GetValue(6));
                            serviceByCategory.CompanyName = reader.GetString(7);
                            serviceByCategory.Location = reader.GetString(8);

                            serviceByCategories.Add(serviceByCategory);
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
            return serviceByCategories;
        }

        public static List<ProductImage> GetProductImage(Adapter ad, int productId)
        {
            var productImages = new List<ProductImage>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_ProductDetailImage", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productImage = new ProductImage();
                            productImage.ImageId = Convert.ToInt32(reader.GetValue(0)); 
                            productImage.ImageURL = Convert.ToString(reader.GetValue(1));
                            productImage.IsDefault = reader.GetBoolean(2);
                            productImages.Add(productImage);
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
            return productImages;
        }

        public static List<ProductDetail> GetProductDetail(Adapter ad, int productId)
        {
            var productDetails = new List<ProductDetail>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_ProductDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productDetail = new ProductDetail();
                            productDetail.Id = Convert.ToInt32(reader.GetValue(0));
                            productDetail.Name = reader.GetString(1);
                            productDetail.Category = reader.GetString(2);
                            productDetail.ShortDescription = (reader.GetString(3)).ToUpper();
                            productDetail.CompanyId = Convert.ToInt32(reader.GetValue(4));
                            productDetail.CompanyName = reader.GetString(5);
                            productDetail.Location = reader.GetString(6);
                            productDetails.Add(productDetail);
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
            return productDetails;
        }


        public static SearchCount GetSearchCount(Adapter ad, string keyword)
        {           
            var response = new SearchCount();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetSearchItemCount", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = keyword, ParameterName = "@Keyword" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.TotalProduct = Convert.ToInt32(reader.GetValue(0));
                            response.TotalService = Convert.ToInt32(reader.GetValue(1));
                            response.TotalCompany = Convert.ToInt32(reader.GetValue(2));
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

        public static List<Description> GetProductDescription(Adapter ad, int productId)
        {
            var productDescriptions = new List<Description>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_ProductDetailDescription", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productDescription = new Description();

                            productDescription.Name = Convert.ToString(reader.GetValue(0));
                            productDescription.SKUNo = reader.GetString(1).ToUpper();
                            productDescription.Brand = reader.GetString(2).ToUpper();
                            productDescription.ModelNo = (reader.GetString(3)).ToUpper();
                            productDescription.Condition = Convert.ToString(reader.GetValue(4));
                            productDescription.Material = reader.GetString(5);
                            productDescription.CountryOrigin = reader.GetString(6);

                            if(reader.GetValue(7).ToString() == "")
                            {
                                productDescription.LongDescription = "No Description provided for this product";
                            }
                            else
                            {
                                productDescription.LongDescription = reader.GetString(7);
                            }
                            

                            productDescriptions.Add(productDescription);
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
            return productDescriptions;
        }

        public static List<CompanyProfile> GetProfile(Adapter ad, int productId)
        {
            var productCompanyProfiles = new List<CompanyProfile>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_ProductDetailProfile", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = productId, ParameterName = "@ProductId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productCompanyProfile = new CompanyProfile();

                            productCompanyProfile.CompanyName = reader.GetString(0);
                            productCompanyProfile.DateIncorporated = reader.GetString(1);
                            productCompanyProfile.Country = reader.GetString(2);
                            productCompanyProfile.WebsiteName = (reader.GetString(3));
                            productCompanyProfile.WebsiteURL = (reader.GetString(4)).ToUpper();
                            productCompanyProfile.LogoUrl = (reader.GetValue(5) == DBNull.Value) ? "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg" : (reader.GetString(5));
                            productCompanyProfiles.Add(productCompanyProfile);
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
            return productCompanyProfiles;
        }

        public static List<ServiceImage> GetServiceImage(Adapter ad, int serviceId)
        {
            var serviceImages = new List<ServiceImage>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_ServiceDetailImage", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var serviceImage = new ServiceImage();
                            serviceImage.ImageId = Convert.ToInt32(reader.GetValue(0));
                            serviceImage.ImageURL = Convert.ToString(reader.GetValue(1));
                            serviceImage.IsDefault = reader.GetBoolean(2);
                            serviceImages.Add(serviceImage);
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
            return serviceImages;
        }

        public static List<ServiceDetail> GetServiceDetail(Adapter ad, int serviceId)
        {
            var serviceDetails = new List<ServiceDetail>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_ServiceDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var serviceDetail = new ServiceDetail();
                            serviceDetail.Id = Convert.ToInt32(reader.GetValue(0));
                            serviceDetail.Name = reader.GetString(1);
                            serviceDetail.Category = reader.GetString(2);
                            serviceDetail.ShortDescription = (reader.GetString(3)).ToUpper();
                            serviceDetail.CompanyId = Convert.ToInt32(reader.GetValue(4));
                            serviceDetail.CompanyName = reader.GetString(5);
                            serviceDetail.Location = reader.GetString(6);
                            serviceDetails.Add(serviceDetail);
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
            return serviceDetails;
        }

        public static List<ServiceDescription> GetServiceDescription(Adapter ad, int serviceId)
        {
            var serviceDescriptions = new List<ServiceDescription>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_ServiceDetailDescription", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var serviceDescription = new ServiceDescription();

                            serviceDescription.Name = Convert.ToString(reader.GetValue(0));
                            serviceDescription.ServiceNo = reader.GetString(1).ToUpper();
                            if (reader.GetValue(2).ToString() == "")
                            {
                                serviceDescription.LongDescription = "No Description provided for this service";
                            }
                            else
                            {
                                serviceDescription.LongDescription = reader.GetString(2);
                            }
                            serviceDescriptions.Add(serviceDescription);
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
            return serviceDescriptions;
        }

        public static List<ServiceCompanyProfile> GetServiceProfile(Adapter ad, int serviceId)
        {
            var serviceCompanyProfiles = new List<ServiceCompanyProfile>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_ServiceDetailProfile", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = serviceId, ParameterName = "@ServiceId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var serviceCompanyProfile = new ServiceCompanyProfile();

                            serviceCompanyProfile.CompanyName = reader.GetString(0);
                            serviceCompanyProfile.DateIncorporated = reader.GetString(1);
                            serviceCompanyProfile.Country = reader.GetString(2);
                            serviceCompanyProfile.WebsiteName = (reader.GetString(3));
                            serviceCompanyProfile.WebsiteURL = (reader.GetString(4)).ToUpper();
                            serviceCompanyProfile.LogoUrl = (reader.GetValue(5) == DBNull.Value) ? "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg" : (reader.GetString(5));

                            serviceCompanyProfiles.Add(serviceCompanyProfile);
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
            return serviceCompanyProfiles;
        }

        //websites

        public static List<HeaderWebsite> GetWebsiteCompanyInfo(Adapter ad, int tenantId)
        {
            var companyInfos = new List<HeaderWebsite>();
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetWebsiteCompanyInfo", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var companyInfo = new HeaderWebsite();
                            companyInfo.BannerImg = Convert.ToString(reader.GetValue(0));
                            companyInfo.LogoImg = reader.GetString(1);
                            companyInfo.CompanyName = myTI.ToTitleCase(reader.GetString(2));
                            companyInfos.Add(companyInfo);
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
            return companyInfos;
        }

        public static List<GeneralInfo> GetWebsiteGeneralInfo(Adapter ad, int tenantId)
        {
            var companyInfos = new List<GeneralInfo>();
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetWebsiteGeneralInfo", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var companyInfo = new GeneralInfo();
                            companyInfo.RegistrationNo = myTI.ToUpper(Convert.ToString(reader.GetValue(0)));
                            companyInfo.DateIncorporated = Convert.ToDateTime(reader.GetValue(1)).ToString("dd MMM yyyy");
                            companyInfo.RegisteredAddress = myTI.ToTitleCase(reader.GetString(2));
                            companyInfo.AuthorizeCapital = myTI.ToUpper(reader.GetValue(3).ToString());
                            companyInfo.TotalEmployees = Convert.ToString(reader.GetValue(4));
                            companyInfos.Add(companyInfo);
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
            return companyInfos;
        }

        public static List<Branch> GetWebsiteBranch(Adapter ad, int tenantId)
        {
            var branches = new List<Branch>();
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetWebsiteBranch", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var branch = new Branch();
                            branch.BranchImg = Convert.ToString(reader.GetValue(0));
                            branch.Name = reader.GetString(1);
                            branch.Type = reader.GetString(2);
                            branch.Location = myTI.ToTitleCase(reader.GetString(3));

                            branches.Add(branch);
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
            return branches;
        }

        public static List<CorporateReg> GetWebsiteCorporate(Adapter ad, int tenantId)
        {
            var corporateRegs = new List<CorporateReg>();
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetWebsiteCorporate", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var corporateReg = new CorporateReg();
                            corporateReg.CorporateImg = Convert.ToString(reader.GetValue(0));
                            corporateReg.CorporateName = myTI.ToTitleCase(reader.GetString(1));

                            corporateRegs.Add(corporateReg);
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
            return corporateRegs;
        }

        public static List<Certification> GetWebsiteCertification(Adapter ad, int tenantId)
        {
            var certifications = new List<Certification>();
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetWebsiteCertification", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var certification = new Certification();
                            certification.CertificationImg = Convert.ToString(reader.GetValue(0));
                            certification.CertName = myTI.ToUpper(reader.GetString(1));
                            certification.IssuedBy = myTI.ToUpper(reader.GetString(2));
                            certification.DateIssued = myTI.ToTitleCase(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy"));

                            certifications.Add(certification);
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
            return certifications;
        }

        public static List<Award> GetWebsiteAward(Adapter ad, int tenantId)
        {
            var awards = new List<Award>();
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetWebsiteAward", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var award = new Award();
                            award.AwardImg = Convert.ToString(reader.GetValue(0));
                            award.AwardName = myTI.ToUpper(reader.GetString(1));
                            award.AwardBy = myTI.ToUpper(reader.GetString(2));
                            award.DateAwarded = myTI.ToTitleCase(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy"));
                            awards.Add(award);
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
            return awards;
        }
        
        public static List<WebsiteItem> GetWebsiteProductList(Adapter ad, int tenantId)
        {
            var productWebsites = new List<WebsiteItem>();
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetWebsiteProductList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productWebsite = new WebsiteItem();

                            productWebsite.Id = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                productWebsite.DefaultImage = reader.GetString(1);
                            }
                            else
                            {
                                productWebsite.DefaultImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            productWebsite.Name = myTI.ToTitleCase(reader.GetString(2));
                            productWebsite.Category = myTI.ToTitleCase(reader.GetString(3));
                            productWebsite.Description = myTI.ToTitleCase(reader.GetString(4));

                            productWebsites.Add(productWebsite);
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
            return productWebsites;
        }
        

        public static (List<WebsiteItem>, PageInfo) GetWebsiteProductList2(Adapter ad, int tenantId, string searchKey = null, Pager pager = null)
        {
            var productWebsites = new List<WebsiteItem>();
            var response2 = new PageInfo();

            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetWebsiteProductList", ad.SQLConn, ad.SQLTran))
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
                            var productWebsite = new WebsiteItem();

                            productWebsite.Id = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                productWebsite.DefaultImage = reader.GetString(1);
                            }
                            else
                            {
                                productWebsite.DefaultImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            productWebsite.Name = myTI.ToTitleCase(reader.GetString(2));
                            productWebsite.Category = myTI.ToTitleCase(reader.GetString(3));
                            productWebsite.Description = myTI.ToTitleCase(reader.GetString(4));

                            productWebsites.Add(productWebsite);
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
            return (productWebsites, response2);
        }


        
        public static List<WebsiteItem> GetWebsiteServiceList(Adapter ad, int tenantId)
        {
            var serviceWebsites = new List<WebsiteItem>();
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetWebsiteServiceList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var serviceWebsite = new WebsiteItem();

                            serviceWebsite.Id = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                serviceWebsite.DefaultImage = reader.GetString(1);
                            }
                            else
                            {
                                serviceWebsite.DefaultImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            serviceWebsite.Name = myTI.ToTitleCase(reader.GetString(2));
                            serviceWebsite.Category = myTI.ToTitleCase(reader.GetString(3));
                            serviceWebsite.Description = myTI.ToTitleCase(reader.GetString(4));

                            serviceWebsites.Add(serviceWebsite);
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
            return serviceWebsites;
        }
        


        public static (List<WebsiteItem>, PageInfo) GetWebsiteServiceList2(Adapter ad, int tenantId, string searchKey = null, Pager pager = null)
        {
            var serviceWebsites = new List<WebsiteItem>();
            var response2 = new PageInfo();

            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_GetWebsiteServiceList", ad.SQLConn, ad.SQLTran))
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
                            var serviceWebsite = new WebsiteItem();

                            serviceWebsite.Id = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                serviceWebsite.DefaultImage = reader.GetString(1);
                            }
                            else
                            {
                                serviceWebsite.DefaultImage = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            serviceWebsite.Name = myTI.ToTitleCase(reader.GetString(2));
                            serviceWebsite.Category = myTI.ToTitleCase(reader.GetString(3));
                            serviceWebsite.Description = myTI.ToTitleCase(reader.GetString(4));

                            serviceWebsites.Add(serviceWebsite);
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
            return (serviceWebsites, response2);
        }

        //--------------PUT Method--------------

        public static PostApiResponse UpdatePublicTenantRfqItemVariant(Adapter ad, TenantRfqItemVariantNew request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_UpdateTenantRfqItemVariant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.tenantRfqItemVariantId, ParameterName = "@TenantRfqItemVariantId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.quantity, ParameterName = "@Quantity" });
                    command.Parameters.Add(new SqlParameter() { Value = request.uomId, ParameterName = "@UomId" });

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

        public static PostApiResponse UpdatePublicTenantInquiry(Adapter ad, int tenantInquiryId, TenantInquiry request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_UpdateTenantInquiry", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantInquiryId, ParameterName = "@TenantInquiryId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.title, ParameterName = "@Title" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                           // response.Id = Convert.ToInt32(reader.GetValue(2));
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

        public static PostApiResponse UpdatePublicTenantRfq(Adapter ad, int tenantRfqId, TenantRfq request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_UpdateTenantRfq", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantRfqId, ParameterName = "@TenantRfqId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.title, ParameterName = "@Title" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            //response.Id = Convert.ToInt32(reader.GetValue(2));
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
        public static PostApiResponse InsertPublicTenantInquiry2(Adapter ad, TenantInquiry request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_InsertTenantInquiry", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ticketNo, ParameterName = "@TicketNo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.toTenantId, ParameterName = "@ToTenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.fromUserId, ParameterName = "@FromUserId" });
                    //command.Parameters.Add(new SqlParameter() { Value = request.tenantProductId, ParameterName = "@TenantProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.title, ParameterName = "@Title" });
                    command.Parameters.Add(new SqlParameter() { Value = request.inquiryStatusSaleId, ParameterName = "@InquiryStatusSaleId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.inquiryStatusQuotId, ParameterName = "@InquiryStatusQuotId" });

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
        public static PostApiResponse InsertPublicTenantInquiry(Adapter ad, TenantInquiry request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_InsertTenantInquiry", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ticketNo, ParameterName = "@TicketNo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.toTenantId, ParameterName = "@ToTenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.fromUserId, ParameterName = "@FromUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.tenantProductId, ParameterName = "@TenantProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.title, ParameterName = "@Title" });
                    command.Parameters.Add(new SqlParameter() { Value = request.inquiryStatusSaleId, ParameterName = "@InquiryStatusSaleId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.inquiryStatusQuotId, ParameterName = "@InquiryStatusQuotId" });

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

        public static PostApiResponse InsertPublicTenantRfq(Adapter ad, TenantRfq request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_InsertTenantRfq", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.rfqNo, ParameterName = "@RfqNo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.toTenantId, ParameterName = "@ToTenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.fromUserId, ParameterName = "@FromUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.title, ParameterName = "@Title" });
                    command.Parameters.Add(new SqlParameter() { Value = request.rfqStatusSaleId, ParameterName = "@RfqStatusSaleId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.rfqStatusQuotId, ParameterName = "@RfqStatusQuotId" });

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

        public static PostApiResponse InsertPublicTenantRfqItem(Adapter ad, TenantRfqItemNew request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_InsertTenantRfqItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.tenantRfqId, ParameterName = "@TenantRfqId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.productId, ParameterName = "@ProductId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.serviceId, ParameterName = "@ServiceId" });                                       
                    command.Parameters.Add(new SqlParameter() { Value = request.categoryTypeId, ParameterName = "@CategoryTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.quantity, ParameterName = "@Quantity" });
                    command.Parameters.Add(new SqlParameter() { Value = request.uomId, ParameterName = "@UomId" });

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

        public static PostApiResponse InsertPublicTenantRfqItemVariant(Adapter ad, int tenantRfqId, TenantRfqItemVariantNew request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_InsertTenantRfqItemVariant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantRfqId, ParameterName = "@TenantRfqId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.productVariantId, ParameterName = "@ProductVariantId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.serviceVariantId, ParameterName = "@ServiceVariantId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.categoryTypeId, ParameterName = "@CategoryTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.quantity, ParameterName = "@Quantity" });
                    command.Parameters.Add(new SqlParameter() { Value = request.uomId, ParameterName = "@UomId" });

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


        public static PostApiResponse InsertPublicEmailNewsletter(Adapter ad, EmailNewsletterReq request)
        {
            var response = new PostApiResponse();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_InsertEmainNewsletter", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.email, ParameterName = "@email" });
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
        public static BasicApiResponse DeleteTenantRfqItemVariant(Adapter ad, int tenantRfqItemVariantId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_DeleteTenantRfqItemVariant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantRfqItemVariantId, ParameterName = "@TenantRfqItemVariantId" });

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

        public static BasicApiResponse DeleteTenantRfqItemVariantByParent(Adapter ad, int tenantRfqId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_DeleteTenantRfqItemVariantByParent", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantRfqId, ParameterName = "@TenantRfqId" });

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

        public static BasicApiResponse DeleteTenantInquiryHistoryByParent(Adapter ad, int tenantInquiryId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_DeleteTenantInquiryHistoryByParent", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantInquiryId, ParameterName = "@TenantInquiryId" });

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


        public static BasicApiResponse DeleteTenantRfqHistoryByParent(Adapter ad, int tenantRfqId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Public_DeleteTenantRfqHistoryByParent", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantRfqId, ParameterName = "@TenantRfqId" });

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
