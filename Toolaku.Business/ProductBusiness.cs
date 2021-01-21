using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models;
using Toolaku.Models.DTO;
using Toolaku.Models.Product;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Business
{
    public class ProductBusiness
    {
        //--------------GET Method--------------
        /*
        public static ProductLists GetProductList(Adapter ad, int tenantId)
        {
            var response = new ProductLists();

            try
            {
                var result = ProductDAL.GetProductList(ad, tenantId);

                if (result.Count != 0)
                {
                    response.result = result;
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


        public static ProductLists GetProductList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new ProductLists();

            try
            {
                var result = ProductDAL.GetProductList(ad, tenantId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.result = result.Item1;
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

        public static ProductGenerals GetProductGeneralInfo(Adapter ad, int productId)
        {
            var response = new ProductGenerals();

            try
            {
                var infoResult = ProductDAL.GetProductGeneralInfo(ad, productId);

                if (infoResult.Count != 0)
                {

                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                    response.basicInfo = infoResult;

                    var imageResult = ProductDAL.GetProductImage(ad, productId);
                    response.imageList = imageResult;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Such Record. Please insert new record";
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

        public static TenantProductCategory GetProductCategory(Adapter ad, int productId)
        {
            var response = new TenantProductCategory();

            try
            {
                response = ProductDAL.GetProductCategory(ad, productId);

                if (response.level1CatId != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Such Record. Please insert new record";
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

        public static ProductDescription GetProductDescription(Adapter ad, int productId)
        {
            var response = new ProductDescription();

            try
            {
                response = ProductDAL.GetProductDescription(ad, productId);

                if (response.description != string.Empty)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No description. Please insert new record";
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
    public static Inventories GetProductInventoryList(Adapter ad, int productId)
    {
        var response = new Inventories();

        try
        {
            var result = ProductDAL.GetProductInventoryList(ad, productId);

            if (result.Count != 0)
            {
                response.list = result;
                response.ReturnCode = 200;
                response.ResponseMessage = "";
            }
            else
            {
                response.ReturnCode = 204;
                response.ResponseMessage = "No stock list. Please insert new record";
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

        public static Inventories GetProductInventoryList(Adapter ad, int productId, string searchKey, Pager pager = null)
        {
            var response = new Inventories();

            try
            {
                var result = ProductDAL.GetProductInventoryList(ad, productId, searchKey, pager);

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
                    response.ResponseMessage = "No stock list. Please insert new record";
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


        public static ProductInventory GetProductInventoryDetail(Adapter ad, int inventoryId)
        {
            var response = new ProductInventory();

            try
            {
                response = ProductDAL.GetProductInventoryDetail(ad, inventoryId);
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ProductGenerals GetProductVariantList(Adapter ad, int productId)
        {
            var response = new ProductGenerals();

            try
            {
                var result = ProductDAL.GetProductVariantList(ad, productId);               

                if (result.Count != 0)
                {
                    response.productVariantList = result;
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



        public static ProductVariant GetProductVariantDetails(Adapter ad, int productVariantId)
        {
            var response = new ProductVariant();

            try
            {
                response = ProductDAL.GetProductVariantDetails(ad, productVariantId);
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
        public static BasicApiResponse DeleteProductList(Adapter ad, string userId, List<ProductToRemove> productToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in productToRemove)
                {
                    var result = ProductDAL.DeleteProductList(ad, Convert.ToInt32(id.productId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Products are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Delete Operation Fail";
                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse EnlistProduct(Adapter ad, string userId, List<ProductToRemove> productToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {

                foreach (var id in productToRemove)
                {
                    var result = ProductDAL.EnlistProduct(ad, Convert.ToInt16(id.productId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Products are successfully unlist";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Unlist Operation Fail";
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

        public static PostApiResponse UpdateProductGeneral(Adapter ad, ProductGeneralUpdate productGeneralUpdate)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ProductDAL.UpdateProductGeneral(ad, productGeneralUpdate);

                if (result.ReturnCode == 0)
                {
                    //delete all image first in table TenantProductImage
                    var imageDelete = ProductDAL.DeleteProductImageAll(ad, productGeneralUpdate.productId);
                    //---

                    var myImage = productGeneralUpdate.imageList;
                    for (var i = 0; i < myImage.Count; i++)
                    {
                        var imageInsert = ProductDAL.InsertProductImage(ad, productGeneralUpdate.productId, myImage[i].imageURL, myImage[i].isDefault);
                    }
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

        public static BasicApiResponse UpdateProductCategory(Adapter ad, TenantProductCategoryUpdate tenantProductCategoryUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProductDAL.UpdateProductCategory(ad, tenantProductCategoryUpdate);

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

        public static BasicApiResponse UpdateProductDescription(Adapter ad, ProductDescriptionUpdate productDescriptionUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProductDAL.UpdateProductDescription(ad, productDescriptionUpdate);

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

        public static BasicApiResponse UpdateProductInventory(Adapter ad, ProductInventoryUp productInventoryUp)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProductDAL.UpdateProductInventory(ad, productInventoryUp);

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



        public static BasicApiResponse UpdateProductVariant(Adapter ad, ProductVariant productVariant)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProductDAL.UpdateProductVariant(ad, productVariant);

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
        public static PostApiResponse InsertProductGeneral(Adapter ad, int tenantId, ProductGeneralRequest productGeneralRequest)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ProductDAL.InsertProductGeneral(ad, tenantId, productGeneralRequest);

                if (result.ReturnCode == 0)
                {
                    var productId = result.Id;
                    var myImage = productGeneralRequest.imageList;
                    for (var i = 0; i < myImage.Count; i++)
                    {
                            var imageInsert = ProductDAL.InsertProductImage(ad, productId, myImage[i].imageURL, myImage[i].isDefault);
                    }
                    response.Id = result.Id;
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

        public static BasicApiResponse InsertProductInventory(Adapter ad, ProductInventoryIn productInventoryIn)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProductDAL.InsertProductInventory(ad, productInventoryIn);

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



        public static BasicApiResponse InsertProductVariant(Adapter ad, int tenantProductId, ProductVariant productVariantRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProductDAL.InsertProductVariant(ad, tenantProductId, productVariantRequest);

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


        //--------------DELETE Method--------------
        public static BasicApiResponse DeleteProductImage(Adapter ad, int productImageId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProductDAL.DeleteProductImage(ad, productImageId);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 204;
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

        public static BasicApiResponse DeleteInventoryList(Adapter ad, InventoriesToRemove inventoriesToRemove)
        {
            var response = new BasicApiResponse();
            var returnCode = 0;


            try
            {
                var idsToRemove = inventoriesToRemove.removeIds;
                for (var i = 0; i < idsToRemove.Count; i++)
                {
                    var removeId = ProductDAL.DeleteInventoryList(ad, idsToRemove[i].inventoryId);
                    if (removeId.ReturnCode != 0)
                    {
                        returnCode = removeId.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Inventory successfully deleted from list";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Fail to delete inventory from list";
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

        public static BasicApiResponse DeleteProductVariant(Adapter ad, int productVariantId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProductDAL.DeleteProductVariant(ad, productVariantId);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 204;
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
