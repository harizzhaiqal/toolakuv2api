using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using Toolaku.Business;
using Toolaku.Library;
using Toolaku.Models;
using Toolaku.Models.DTO;
using Toolaku.Models.Product;
using Toolaku.Models.Pagingnation;

namespace ToolakuV2_API.Controllers
{
    [RoutePrefix("api/product")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ProductController : ApiController
    {
        //--------------------------------------
        //--------------GET Method--------------
        //--------------------------------------
        [HttpGet]
        [Authorize]
        [Route("list")]
        /*
        public IHttpActionResult GetProductList()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.GetProductList(ad, Convert.ToInt32(tenantId));
                return Ok(response);
            }

        }*/
        public IHttpActionResult GetProductList(string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ProductBusiness.GetProductList(ad, Convert.ToInt32(tenantId), searchKey, page);
                return Ok(response);
            }

        }


        [HttpGet]
        [Authorize]
        [Route("general")]
        public IHttpActionResult GetProductGeneralInfo(int productId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.GetProductGeneralInfo(ad, productId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("category")]
        public IHttpActionResult GetProductCategory(int productId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.GetProductCategory(ad, productId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("description")]
        public IHttpActionResult GetProductDescription(int productId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.GetProductDescription(ad, productId);
                return Ok(response);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("inventory/list")]
        /*
         public IHttpActionResult GetProductInventoryList(int productId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.GetProductInventoryList(ad, productId);
                return Ok(response);
            }

        }
            */
        public IHttpActionResult GetProductInventoryList(int productId, string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ProductBusiness.GetProductInventoryList(ad, productId, searchKey, page);
                return Ok(response);
            }

        }

       
        [HttpGet]
        [Authorize]
        [Route("inventory")]
        public IHttpActionResult GetProductInventoryDetail(int inventoryId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.GetProductInventoryDetail(ad, inventoryId);
                return Ok(response);
            }

        }


        [HttpGet]
        [Authorize]
        [Route("variant")]
        public IHttpActionResult GetProductVariantDetails(int productVariantId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.GetProductVariantDetails(ad, productVariantId);
                return Ok(response);
            }

        }


        //--------------------------------------
        //--------------PUT Method--------------
        //--------------------------------------
        [HttpPut]
        [Authorize]
        [Route("list/remove")]
        public IHttpActionResult DeleteProductList(List<ProductToRemove> productToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ProductBusiness.DeleteProductList(ad, userId, productToRemove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("enlist")]
        public IHttpActionResult EnlistProduct(List<ProductToRemove> productToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ProductBusiness.EnlistProduct(ad, userId, productToRemove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("general")]
        public IHttpActionResult UpdateProductGeneral(ProductGeneralUpdate productGeneralUpdate)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.UpdateProductGeneral(ad, productGeneralUpdate);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("description")]
        public IHttpActionResult UpdateProductDescription(ProductDescriptionUpdate productDescriptionUpdate)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.UpdateProductDescription(ad, productDescriptionUpdate);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("inventory/list")]
        public IHttpActionResult DeleteInventoryList(InventoriesToRemove inventoriesToRemove)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.DeleteInventoryList(ad, inventoriesToRemove);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("inventory")]
        public IHttpActionResult UpdateProductInventory(ProductInventoryUp productInventoryUp)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.UpdateProductInventory(ad, productInventoryUp);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("variant")]
        public IHttpActionResult UpdateProductVariant(ProductVariant productVariant)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.UpdateProductVariant(ad, productVariant);
                return Ok(response);
            }

        }


        [HttpPut]
        [Authorize]
        [Route("variant/remove")]
        public IHttpActionResult DeleteProductVariant(int productVariantId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.DeleteProductVariant(ad, productVariantId);
                return Ok(response);
            }

        }


        //---------------------------------------
        //--------------POST Method--------------
        //---------------------------------------
        [HttpPost]
        [Authorize]
        [Route("general")]
        public IHttpActionResult InsertProductGeneral(ProductGeneralRequest productGeneralRequest)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            if (string.IsNullOrWhiteSpace(productGeneralRequest.productName))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Product Name is empty"));
            }

            if (string.IsNullOrWhiteSpace(productGeneralRequest.shortDescription))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Short Description is empty"));
            }

            if (string.IsNullOrWhiteSpace(productGeneralRequest.skuNo))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "SKU No is empty"));
            }

            if (productGeneralRequest.conditionId == 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Product Condition is empty"));
            }

            if (productGeneralRequest.countryOriginId == 0)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Country Origin is empty"));
            }

            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.InsertProductGeneral(ad, Convert.ToInt32(tenantId), productGeneralRequest);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("category")]
        public IHttpActionResult UpdateProductCategory(TenantProductCategoryUpdate tenantProductCategoryUpdate)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.UpdateProductCategory(ad, tenantProductCategoryUpdate);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("inventory")]
        public IHttpActionResult InsertProductInventory(ProductInventoryIn productInventoryIn)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.InsertProductInventory(ad, productInventoryIn);
                return Ok(response);
            }

        }



        [HttpPost]
        [Authorize]
        [Route("variant")]
        public IHttpActionResult InsertProductVariant(int tenantProductId, ProductVariant productVariantRequest)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.InsertProductVariant(ad, tenantProductId, productVariantRequest);
                return Ok(response);
            }

        }


        //-----------------------------------------
        //--------------DELETE Method--------------
        //-----------------------------------------

        [HttpDelete]
        [Authorize]
        [Route("general/image")]
        public IHttpActionResult DeleteProductImage(int productImageId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ProductBusiness.DeleteProductImage(ad, productImageId);
                return Ok(response);
            }

        }


    }
}
