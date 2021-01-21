using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.Public;
using Toolaku.Models.Sale;
using Toolaku.Models.Pagingnation;


namespace Toolaku.Business
{
    public class PublicBusiness
    {
        public static CategoryTop10s GetCategoryTop10(Adapter ad)
        {
            var response = new CategoryTop10s();

            try
            {
                var result = PublicDAL.GetCategoryTop10(ad);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.Result = result;
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

        public static SearchCount GetSearchCount(Adapter ad, string keyword)
        {
            var response = new SearchCount();
            try
            {
                response = PublicDAL.GetSearchCount(ad, keyword);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static CategoryHierarchys GetAllGategory(Adapter ad)
        {
            var response = new CategoryHierarchys();

            try
            {
                var result = PublicDAL.GetAllGategory(ad);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.Result = result;
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

        public static RecommendedItems GetRecommendedProduct(Adapter ad)
        {
            var response = new RecommendedItems();

            try
            {
                var result = PublicDAL.GetRecommendedProduct(ad);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Ok";
                    response.Result = result;
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

        public static RecommendedItems GetRecommendedService(Adapter ad)
        {
            var response = new RecommendedItems();

            try
            {
                var result = PublicDAL.GetRecommendedService(ad);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Ok";
                    response.Result = result;
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

        public static RfqTenderSummary GetRfqTenderSummary(Adapter ad)
        {
            var response = new RfqTenderSummary();
            var errorMsg = string.Empty;

            try
            {
                var resultRfq = PublicDAL.GetRfqSummary(ad);

                if (resultRfq.Count != 0)
                {
                    response.RfqResult = resultRfq;
                }
                else
                {
                    errorMsg = "No RFQ available at the moment";
                }

                var resultTender = PublicDAL.GetTenderSummary(ad);

                if (resultTender.Count != 0)
                {
                    response.TenderResult = resultTender;
                }
                else
                {
                    if (errorMsg == string.Empty)
                    {
                        errorMsg = "No Tender available currently";
                    }
                    else
                    {
                        errorMsg = "No RFQ & Tender are available at the moment";
                    }

                }

                if (errorMsg == string.Empty)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Ok";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = errorMsg;
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
        public static SearchItems GetSearchItem(Adapter ad, string searchKeyword, string itemType)
        {
            var response = new SearchItems();
            var errorMsg = string.Empty;

            try
            {
                var result = PublicDAL.GetSearchItem(ad, searchKeyword, itemType);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Ok";
                    response.Result = result;
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

        public static SearchItems GetSearchItem(Adapter ad, string searchKeyword, string itemType, Pager pager = null)
        {
            var response = new SearchItems();
            var errorMsg = string.Empty;

            try
            {
                var result = PublicDAL.GetSearchItem(ad, searchKeyword, itemType, pager);
               
                if (result.Item1.Count != 0)
                {
                    response.Result = result.Item1;
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

        public static ProductCategories GetProductCategory(Adapter ad, int categoryId)
        {
            var response = new ProductCategories();
            var errorMsg = string.Empty;

            try
            {
                var result = PublicDAL.GetProductCategory(ad, categoryId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Ok";
                    response.CategoryList = result;
                    response.ParentCategoryId = result[1].ParentCategoryId;
                    response.ParentCategoryName = result[1].ParentCategoryName;
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

        public static ProductByCategories GetProductListByCategory(Adapter ad, int categoryId)
        {
            var response = new ProductByCategories();
            var errorMsg = string.Empty;

            try
            {
                var result = PublicDAL.GetProductListByCategory(ad, categoryId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Ok";
                    response.Result = result;

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

        public static ServiceCategories GetServiceCategory(Adapter ad, int categoryId)
        {
            var response = new ServiceCategories();
            var errorMsg = string.Empty;

            try
            {
                var result = PublicDAL.GetServiceCategory(ad, categoryId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Ok";
                    response.CategoryList = result;
                    response.ParentCategoryId = result[1].ParentCategoryId;
                    response.ParentCategoryName = result[1].ParentCategoryName;
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

        public static ServiceByCategories GetServiceListByCategory(Adapter ad, int categoryId)
        {
            var response = new ServiceByCategories();
            var errorMsg = string.Empty;

            try
            {
                var result = PublicDAL.GetServiceListByCategory(ad, categoryId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Ok";
                    response.Result = result;

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

        public static PageDetail GetProductDetail(Adapter ad, int productId)
        {
            var response = new PageDetail();
            var errorMsg = string.Empty;

            try
            {
                //get product images
                var resultImage = PublicDAL.GetProductImage(ad, productId);
                if (resultImage.Count != 0)
                {
                    response.productImage = resultImage;
                }
                else
                {
                    var productImage = new ProductImage();
                    productImage.ImageId = 0;
                    productImage.IsDefault = true;
                    productImage.ImageURL = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                    response.productImage.Add(productImage);
                }

                //get product detail list
                var resultDetail = PublicDAL.GetProductDetail(ad, productId);
                response.productDetail = resultDetail;

                //getdescription
                var resultDesctiption = PublicDAL.GetProductDescription(ad, productId);
                response.description = resultDesctiption;

                //get companyprofile
                var resultProfile = PublicDAL.GetProfile(ad, productId);
                response.companyProfile = resultProfile;

                response.ReturnCode = 200;
                response.ResponseMessage = "Ok";

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ServicePageDetail GetServiceDetail(Adapter ad, int serviceId)
        {
            var response = new ServicePageDetail();
            var errorMsg = string.Empty;

            try
            {
                //get product images
                var resultImage = PublicDAL.GetServiceImage(ad, serviceId);
                if (resultImage.Count != 0)
                {
                    response.serviceImage = resultImage;
                }
                else
                {
                    var serviceImage = new ServiceImage();
                    serviceImage.ImageId = 0;
                    serviceImage.IsDefault = true;
                    serviceImage.ImageURL = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                    response.serviceImage.Add(serviceImage);
                }

                //get product detail list
                var resultDetail = PublicDAL.GetServiceDetail(ad, serviceId);
                response.serviceDetail = resultDetail;

                //getdescription
                var resultDesctiption = PublicDAL.GetServiceDescription(ad, serviceId);
                response.description = resultDesctiption;

                //get companyprofile
                var resultProfile = PublicDAL.GetServiceProfile(ad, serviceId);
                response.companyProfile = resultProfile;

                response.ReturnCode = 200;
                response.ResponseMessage = "Ok";

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static CompanyOverView GetTenantWebsite(Adapter ad, int tenantId)
        {
            var response = new CompanyOverView();

            try
            {
                // get company info
                var companyInfo  = PublicDAL.GetWebsiteCompanyInfo(ad, tenantId);
                response.headerInfo = companyInfo;
              
                // get general info
                var generalInfo = PublicDAL.GetWebsiteGeneralInfo(ad, tenantId);
                response.generalInfo = generalInfo;

                //get branch list
                var branchResult = PublicDAL.GetWebsiteBranch(ad, tenantId);
                response.branchList = branchResult;

                //get corporate list
                var corporateResult = PublicDAL.GetWebsiteCorporate(ad, tenantId);
                response.corporateList = corporateResult;

                //get Certification list
                var certResult = PublicDAL.GetWebsiteCertification(ad, tenantId);
                response.certificateList = certResult;

                //get Award list
                var awardResult = PublicDAL.GetWebsiteAward(ad, tenantId);
                response.awardList = awardResult;

                //get product lists
                var productList = PublicDAL.GetWebsiteProductList(ad, tenantId);
                response.productList = productList;

                //get service list
                var serviceList = PublicDAL.GetWebsiteServiceList(ad, tenantId);
                response.serviceList = serviceList;

                //response.ReturnCode = 200;
                //response.ResponseMessage = "Ok";

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }


        public static CompanyProductList GetWebsiteProductList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new CompanyProductList();
            try
            {
                var result = PublicDAL.GetWebsiteProductList2(ad, tenantId, searchKey, pager);
                if (result.Item1.Count != 0)
                {
                    response.productList = result.Item1;
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


        public static CompanyServiceList GetWebsiteServiceList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new CompanyServiceList();
            try
            {
                var result = PublicDAL.GetWebsiteServiceList2(ad, tenantId, searchKey, pager);
                if (result.Item1.Count != 0)
                {
                    response.serviceList = result.Item1;
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
        public static BasicApiResponse UpdatePublicDraftTenantInquiry(Adapter ad, string flagNewDraft, int tenantInquiryId, TenantInquiryNew tenantInquiryNew)
        {
            var response = new BasicApiResponse();
            var tenantInquiry = new TenantInquiry();
            var tenantInquiryHistory = new TenantInquiryHistory();

            try
            {
                tenantInquiry.title = tenantInquiryNew.title;

                if (flagNewDraft == "N")
                {
                    SaleDAL.UpdateStatusInquiry(ad, tenantInquiryId, 2, 3);
                }

                var result = PublicDAL.UpdatePublicTenantInquiry(ad, tenantInquiryId, tenantInquiry);
                

                PublicDAL.DeleteTenantInquiryHistoryByParent(ad, tenantInquiryId);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;

                    tenantInquiryHistory.tenantInquiryId = tenantInquiryId;
                    tenantInquiryHistory.inquiryBody = tenantInquiryNew.inquiryBody;
                    tenantInquiryHistory.flagSide = "Q";

                   
                    SaleDAL.InsertSaleTenantInquiryHistory(ad, tenantInquiryHistory);
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

        public static BasicApiResponse UpdatePublicDraftTenantRfq(Adapter ad, string flagNewDraft, int tenantRfqId, TenantRfqNew tenantRfqNew)
        {
            var response = new BasicApiResponse();
            var tenantRfq = new TenantRfq();
            var tenantRfqHistory = new TenantRfqHistory();

            try
            {
                tenantRfq.rfqNo = tenantRfqNew.rfqNo;
                tenantRfq.toTenantId = tenantRfqNew.toTenantId;
                tenantRfq.fromUserId = tenantRfqNew.fromUserId;
                tenantRfq.title = tenantRfqNew.title;

                if (flagNewDraft == "N")
                {
                    SaleDAL.UpdateStatusRfq(ad, tenantRfqId, 2, 3);
                }


                var result = PublicDAL.UpdatePublicTenantRfq(ad, tenantRfqId, tenantRfq);
                PublicDAL.DeleteTenantRfqHistoryByParent(ad, tenantRfqId);
                PublicDAL.DeleteTenantRfqItemVariant(ad, tenantRfqId);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;

                    tenantRfqHistory.tenantRfqId = tenantRfqId;
                    tenantRfqHistory.rfqBody = tenantRfqNew.rfqBody;
                    tenantRfqHistory.attachmentUrl = tenantRfqNew.attachmentUrl;
                    tenantRfqHistory.flagSide = "Q";


                    SaleDAL.InsertSaleTenantRfqHistory(ad, tenantRfqHistory);

                    foreach (var itemVariant in tenantRfqNew.itemVariants)
                    {
                        var tenantRfqItemVariant = new TenantRfqItemVariantNew();

                        tenantRfqItemVariant.productVariantId = itemVariant.productVariantId;
                        tenantRfqItemVariant.serviceVariantId = itemVariant.serviceVariantId;
                        tenantRfqItemVariant.uomId = itemVariant.uomId;
                        tenantRfqItemVariant.quantity = itemVariant.quantity;
                        tenantRfqItemVariant.categoryTypeId = itemVariant.categoryTypeId;

                        PublicDAL.InsertPublicTenantRfqItemVariant(ad, tenantRfqHistory.tenantRfqId, tenantRfqItemVariant);


                    }
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

        public static PostApiResponse InsertPublicTenantInquiry(Adapter ad, string flagNewDraft, TenantInquiryNew tenantInquiryNew)
        {
            var response = new PostApiResponse();
            var tenantInquiry = new TenantInquiry();
            var tenantInquiryHistory = new TenantInquiryHistory();

            try
            {
                tenantInquiry.ticketNo = tenantInquiryNew.ticketNo;
                tenantInquiry.toTenantId = tenantInquiryNew.toTenantId;
                tenantInquiry.fromUserId = tenantInquiryNew.fromUserId;
                tenantInquiry.tenantProductId = tenantInquiryNew.tenantProductId;
                tenantInquiry.title = tenantInquiryNew.title;
             
                if (flagNewDraft == "N")
                {
                    tenantInquiry.inquiryStatusSaleId = 2;
                    tenantInquiry.inquiryStatusQuotId = 3;
                }
                else
                {
                    tenantInquiry.inquiryStatusSaleId = 1;
                    tenantInquiry.inquiryStatusQuotId = 1;
                }


                var result = PublicDAL.InsertPublicTenantInquiry(ad, tenantInquiry);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;

                    tenantInquiryHistory.tenantInquiryId = result.Id;
                    tenantInquiryHistory.inquiryBody = tenantInquiryNew.inquiryBody;
                    tenantInquiryHistory.flagSide = "Q";

                    SaleDAL.InsertSaleTenantInquiryHistory(ad, tenantInquiryHistory);
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


        public static PostApiResponse InsertPublicTenantInquiry2(Adapter ad, TenantInquiryNew tenantInquiryNew)
        {
            var response = new PostApiResponse();
            var tenantInquiry = new TenantInquiry();
            var tenantInquiryHistory = new TenantInquiryHistory();

            try
            {
                tenantInquiry.ticketNo = tenantInquiryNew.ticketNo;
                tenantInquiry.toTenantId = tenantInquiryNew.toTenantId;
                tenantInquiry.fromUserId = tenantInquiryNew.fromUserId;
                //tenantInquiry.tenantProductId = tenantInquiryNew.tenantProductId;
                tenantInquiry.title = tenantInquiryNew.title;
                tenantInquiry.inquiryStatusSaleId = 2;
                tenantInquiry.inquiryStatusQuotId = 3;                

                var result = PublicDAL.InsertPublicTenantInquiry2(ad, tenantInquiry);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;

                    tenantInquiryHistory.tenantInquiryId = result.Id;
                    tenantInquiryHistory.inquiryBody = tenantInquiryNew.inquiryBody;
                    tenantInquiryHistory.flagSide = "Q";

                    SaleDAL.InsertSaleTenantInquiryHistory(ad, tenantInquiryHistory);
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

        public static PostApiResponse InsertPublicTenantRfq(Adapter ad, string flagNewDraft, TenantRfqNew tenantRfqNew)
        {
            var response = new PostApiResponse();
            var tenantRfq = new TenantRfq();
            var tenantRfqHistory = new TenantRfqHistory();

            try
            {
                tenantRfq.rfqNo = tenantRfqNew.rfqNo;
                tenantRfq.toTenantId = tenantRfqNew.toTenantId;
                tenantRfq.fromUserId = tenantRfqNew.fromUserId;
                tenantRfq.title = tenantRfqNew.title;
                if (flagNewDraft == "N")
                {
                    tenantRfq.rfqStatusSaleId = 2;
                    tenantRfq.rfqStatusQuotId = 3;
                }
                else
                {
                    tenantRfq.rfqStatusSaleId = 1;
                    tenantRfq.rfqStatusQuotId = 1;
                }


                var result = PublicDAL.InsertPublicTenantRfq(ad, tenantRfq);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;

                    tenantRfqHistory.tenantRfqId = result.Id;
                    tenantRfqHistory.rfqBody = tenantRfqNew.rfqBody;
                    tenantRfqHistory.attachmentUrl = tenantRfqNew.attachmentUrl;
                    tenantRfqHistory.flagSide = "Q";

                    SaleDAL.InsertSaleTenantRfqHistory(ad, tenantRfqHistory);

                    foreach (var itemVariant in tenantRfqNew.itemVariants)
                    {
                        var tenantRfqItemVariant = new TenantRfqItemVariantNew();
                        
                        tenantRfqItemVariant.productVariantId = itemVariant.productVariantId;
                        tenantRfqItemVariant.serviceVariantId = itemVariant.serviceVariantId;
                        tenantRfqItemVariant.uomId = itemVariant.uomId;
                        tenantRfqItemVariant.quantity = itemVariant.quantity;
                        tenantRfqItemVariant.categoryTypeId = itemVariant.categoryTypeId;

                        PublicDAL.InsertPublicTenantRfqItemVariant(ad, tenantRfqHistory.tenantRfqId, tenantRfqItemVariant);

                       
                    }
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


        public static PostApiResponse InsertPublicTenantRfq2(Adapter ad, TenantRfqNew2 rfqNew)
        {
            var response = new PostApiResponse();
            var tenantRfq = new TenantRfq();
            var tenantRfqHistory = new TenantRfqHistory();

            try
            {
                tenantRfq.rfqNo = rfqNew.rfqNo;
                tenantRfq.toTenantId = rfqNew.toTenantId;
                tenantRfq.fromUserId = rfqNew.fromUserId;
                tenantRfq.title = rfqNew.title;
                tenantRfq.rfqStatusSaleId = 2;
                tenantRfq.rfqStatusQuotId = 3;


                var result = PublicDAL.InsertPublicTenantRfq(ad, tenantRfq);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;

                    tenantRfqHistory.tenantRfqId = result.Id;
                    tenantRfqHistory.rfqBody = rfqNew.rfqBody;
                    tenantRfqHistory.flagSide = "Q";

                    SaleDAL.InsertSaleTenantRfqHistory(ad, tenantRfqHistory);

                    var tenantRfqItemVariant = new TenantRfqItemVariantNew();

                    tenantRfqItemVariant.productVariantId = rfqNew.productServiceId;
                    tenantRfqItemVariant.serviceVariantId = rfqNew.productServiceId;                    
                    tenantRfqItemVariant.quantity = rfqNew.quantity;
                    tenantRfqItemVariant.categoryTypeId = rfqNew.categoryTypeId;
                    tenantRfqItemVariant.uomId = rfqNew.productUomId;
                    

                    PublicDAL.InsertPublicTenantRfqItemVariant(ad, tenantRfqHistory.tenantRfqId, tenantRfqItemVariant);

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

        public static PostApiResponse InsertPublicTenantRfqItem(Adapter ad, TenantRfqItemNew tenantRfqItem)
        {
            var response = new PostApiResponse();

            try
            {
                var result = PublicDAL.InsertPublicTenantRfqItem(ad, tenantRfqItem);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;
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


        public static PostApiResponse InsertPublicEmailNewsletter(Adapter ad, EmailNewsletterReq req)
        {
            var response = new PostApiResponse();
            try
            {
                var result = PublicDAL.InsertPublicEmailNewsletter(ad, req);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;


                    var mailBody = "You have successfully subscribed the Toolaku Newsletter.";

                    var result2 = AdminDAL.PushEmailSingle(req.email, "Toolaku Newsletter", mailBody);

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

    }
}
