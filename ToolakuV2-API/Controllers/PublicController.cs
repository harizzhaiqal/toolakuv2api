using System.Web.Http;
using System;
using Toolaku.Business;
using Toolaku.Library;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Security.Claims;
using Toolaku.Models.Sale;
using Toolaku.Models.Public;
using System.Linq;
using Toolaku.Models.Pagingnation;

namespace ToolakuV2_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/public")]
    public class PublicController : ApiController
    {
        //--------------GET Method--------------

        [HttpGet]
        [AllowAnonymous]
        [Route("category/top10/")]
        public IHttpActionResult GetCategoryTop10()
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetCategoryTop10(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("category/all/")]
        public IHttpActionResult GetAllGategory()
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetAllGategory(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/recommended/")]
        public IHttpActionResult GetRecommendedProduct()
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetRecommendedProduct(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("service/recommended/")]
        public IHttpActionResult GetRecommendedService()
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetRecommendedService(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("rfqtender/list/")]
        public IHttpActionResult GetRfqTenderSummary()
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetRfqTenderSummary(ad);
                return Ok(response);
            }
        }

        /*
        [HttpGet]
        [AllowAnonymous]
        [Route("search/item/")]
        public IHttpActionResult GetSearchItem(string searchKeyword, string itemType)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetSearchItem(ad, searchKeyword, itemType);
                return Ok(response);
            }
        }
        */

        [HttpGet]
        [AllowAnonymous]
        [Route("search/item/")]
        public IHttpActionResult GetSearchItem(string searchKeyword = "", string itemType = "", int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = PublicBusiness.GetSearchItem(ad, searchKeyword, itemType, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("search/item/count")]
        public IHttpActionResult GetSearchCount(string keyword = "")
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetSearchCount(ad, keyword);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/category")]
        public IHttpActionResult GetProductCategory(int categoryId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetProductCategory(ad, categoryId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/list/category")]
        public IHttpActionResult GetProductListByCategory(int categoryId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetProductListByCategory(ad, categoryId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("service/category")]
        public IHttpActionResult GetServiceCategory(int categoryId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetServiceCategory(ad, categoryId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("service/list/category")]
        public IHttpActionResult GetServiceListByCategory(int categoryId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetServiceListByCategory(ad, categoryId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/detail")]
        public IHttpActionResult GetProductDetail(int productId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetProductDetail(ad, productId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("service/detail")]
        public IHttpActionResult GetServiceDetail(int serviceId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetServiceDetail(ad, serviceId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("tenant/website")]
        public IHttpActionResult GetTenantWebsite(int tenantId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.GetTenantWebsite(ad, tenantId);
                return Ok(response);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("tenant/website/product/list")]
        public IHttpActionResult GetWebsiteProductList(int tenantId, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = PublicBusiness.GetWebsiteProductList(ad, tenantId, searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("tenant/website/service/list")]
        public IHttpActionResult GetWebsiteServiceList(int tenantId, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = PublicBusiness.GetWebsiteServiceList(ad, tenantId, searchKey, page);
                return Ok(response);
            }
        }




        [HttpGet]
        [AllowAnonymous]
        [Route("inquiry/history/viewmodal")]
        public IHttpActionResult GetTenantInquiryHistoryViewModal(int tenantInquiryId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.GetTenantInquiryHistoryViewModal(ad, false, "public", Convert.ToInt32(tenantInquiryId));
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("rfq/history/viewmodal")]
        public IHttpActionResult GetTenantRfqHistoryViewModal(int tenantRfqId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = SaleBusiness.GetTenantRfqHistoryViewModal(ad, false, "public", Convert.ToInt32(tenantRfqId));
                return Ok(response);
            }
        }

        //--------------PUT Method--------------


        [HttpPut]
        [Authorize]
        [Route("inquiry/sent/draft")]
        public IHttpActionResult UpdatePublicTenantInquiry(int tenantInquiryId, TenantInquiryNew tenantInquiry)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.UpdatePublicDraftTenantInquiry(ad, "N", tenantInquiryId, tenantInquiry);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("rfq/sent/draft")]
        public IHttpActionResult UpdatePublicRfqInquiryDraftSent(int tenantRfqId, TenantRfqNew tenantRfq)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.UpdatePublicDraftTenantRfq(ad, "N", tenantRfqId, tenantRfq);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("inquiry/update/draft")]
        public IHttpActionResult UpdatePublicTenantInquiryDraftSent(int tenantInquiryId, TenantInquiryNew tenantInquiry)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.UpdatePublicDraftTenantInquiry(ad, "D", tenantInquiryId, tenantInquiry);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("rfq/update/draft")]
        public IHttpActionResult UpdatePublicRfqInquiry(int tenantRfqId, TenantRfqNew tenantRfq)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.UpdatePublicDraftTenantRfq(ad, "D", tenantRfqId, tenantRfq);
                return Ok(response);
            }
        }


        //--------------POST Method--------------

        [HttpPost]
        [Authorize]
        [Route("inquiry/new")]
        public IHttpActionResult InsertPublicTenantInquiryNew(TenantInquiryNew tenantInquiry)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            
            using (Adapter ad = new Adapter())
            {                
                
                tenantInquiry.fromUserId = Convert.ToInt32(userId);

                var response = PublicBusiness.InsertPublicTenantInquiry(ad, "N", tenantInquiry);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("inquiry/draft")]
        public IHttpActionResult InsertPublicTenantInquiryDraft(TenantInquiryNew tenantInquiry)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {

                tenantInquiry.fromUserId = Convert.ToInt32(userId);

                var response = PublicBusiness.InsertPublicTenantInquiry(ad, "D", tenantInquiry);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("rfq/new")]
        public IHttpActionResult InsertPublicTenantRfqNew(TenantRfqNew tenantRfq)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
           

            using (Adapter ad = new Adapter())
            {
                
                tenantRfq.fromUserId = Convert.ToInt32(userId);

                var response = PublicBusiness.InsertPublicTenantRfq(ad, "N", tenantRfq);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("rfq/draft")]
        public IHttpActionResult InsertPublicTenantRfqDraft(TenantRfqNew tenantRfq)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            
            using (Adapter ad = new Adapter())
            {

                tenantRfq.fromUserId = Convert.ToInt32(userId);

                var response = PublicBusiness.InsertPublicTenantRfq(ad, "D", tenantRfq);
                return Ok(response);
            }

        }

        [HttpPost]
        [Authorize]
        [Route("rfq/item")]
        public IHttpActionResult InsertPublicTenantRfqItem(TenantRfqItemNew tenantRfqItem)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.InsertPublicTenantRfqItem(ad, tenantRfqItem);
                return Ok(response);
            }

        }



        [HttpPost]
        [AllowAnonymous]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        [Route("rfq/new2")]
        public IHttpActionResult addRfq([FromBody] TenantRfqNew2 rfqNew)
        {
            try
            {
                using (Adapter ad = new Adapter())
                {
                    var response = PublicBusiness.InsertPublicTenantRfq2(ad, rfqNew);
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }

        [HttpPost]
        [AllowAnonymous]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        [Route("inquiry/new2")]
        public IHttpActionResult addInquiry(TenantInquiryNew tenantInquiry)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.InsertPublicTenantInquiry2(ad, tenantInquiry);
                return Ok(response);
            }

        }


        [HttpPost]
        [AllowAnonymous]
        [Route("newsletter/add")]
        public IHttpActionResult InsertPublicEmailNewsletter(EmailNewsletterReq req)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PublicBusiness.InsertPublicEmailNewsletter(ad, req);
                return Ok(response);
            }
        }


    }

}
