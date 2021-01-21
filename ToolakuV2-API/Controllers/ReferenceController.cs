using System.Web.Http;
using Toolaku.Library;
using System.Collections.Generic;
using Toolaku.Models.DTO;
using Toolaku.Business;
using Toolaku.Models;
using System.Web.Http.Cors;
using System.Security.Claims;
using System.Net.Http;
using System.Linq;
using Toolaku.Models.Reference;
using Toolaku.Models.Pagingnation;
using System;

namespace ToolakuAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/reference")]
    public class ReferenceController : ApiController
    {
        //--------------------------------------
        //--------------GET Method--------------
        //--------------------------------------

        [HttpGet]
        [AllowAnonymous]
        [Route("edition")]
        public IHttpActionResult GetEdition()
        {
            using (Adapter ad = new Adapter())
            {
                var response = new Editions();

                response = ReferenceBusiness.GetEdition(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("dayType")]
        public IHttpActionResult GetDayType()
        {
            using (Adapter ad = new Adapter())
            {
                var response = new DayTypes();

                response = ReferenceBusiness.GetDayType(ad);
                return Ok(response);
            }
        }
        /*
        [HttpGet]
        [AllowAnonymous]
        [Route("documentType")]
        public IHttpActionResult GetDocumentType()
        {
            using (Adapter ad = new Adapter())
            {
                var response = new DocumentTypes();

                response = ReferenceBusiness.GetDocumentType(ad);
                return Ok(response);
            }
        }
        */

        [HttpGet]
        [AllowAnonymous]
        [Route("documentType")]
        public IHttpActionResult GetDocumentType()
        {
            using (Adapter ad = new Adapter())
            {
              
                    var response = new DocumentTypes();

                    response = ReferenceBusiness.GetDocumentType(ad);
                    return Ok(response);
                
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("frequency")]
        public IHttpActionResult GetFrequency()
        {
            using (Adapter ad = new Adapter())
            {
                var response = new Frequencies();

                response = ReferenceBusiness.GetFrequency(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("gender")]
        public IHttpActionResult GetGender()
        {
            using (Adapter ad = new Adapter())
            {
                var response = new Genders();

                response = ReferenceBusiness.GetGender(ad);
                return Ok(response);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("leaveDurationType")]
        public IHttpActionResult GetLeaveDurationType()
        {
            using (Adapter ad = new Adapter())
            {
                var response = new LeaveDurationTypes();

                response = ReferenceBusiness.GetLeaveDurationType(ad);
                return Ok(response);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("leaveType")]
        public IHttpActionResult GetLeaveType()
        {
            using (Adapter ad = new Adapter())
            {
                var response = new LeaveTypes();

                response = ReferenceBusiness.GetLeaveType(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("maritialStatus")]
        public IHttpActionResult GetMaritalStatus()
        {
            using (Adapter ad = new Adapter())
            {
                var response = new MaritalStatuses();

                response = ReferenceBusiness.GetMaritalStatus(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("employmentStatus")]
        public IHttpActionResult GetEmploymentStatus()
        {
            using (Adapter ad = new Adapter())
            {
                var response = new EmploymentStatuses();

                response = ReferenceBusiness.GetEmploymentStatus(ad);
                return Ok(response);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("category/type")]
        public IHttpActionResult GetCategoryType()
        {
            using (Adapter ad = new Adapter())
            {
                var response = new CategoryTypes();

                response = ReferenceBusiness.GetCategoryType(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/category/parent")]
        public IHttpActionResult GetProductCategoryParent()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetProductCategoryParent(ad);
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
                var response = ReferenceBusiness.GetProductCategory(ad, categoryId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("service/category/parent")]
        public IHttpActionResult GetServiceCategoryParent()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetServiceCategoryParent(ad);
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
                var response = ReferenceBusiness.GetServiceCategory(ad, categoryId);
                return Ok(response);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("country")]
        public IHttpActionResult GetCountry()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetCountry(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("month")]
        public IHttpActionResult GetMonth()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetMonth(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("vehicle")]
        public IHttpActionResult GetVehicle()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetVehicle(ad);
                return Ok(response);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("telcoSupplier")]
        public IHttpActionResult GetTelcoSupplier()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetTelcoSupplier(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/country")]
        public IHttpActionResult GetProductCountry()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetCountry(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("state")]
        public IHttpActionResult GetState(int countryId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetState(ad, countryId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("city")]
        public IHttpActionResult GetCity(int stateId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetCity(ad, stateId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/state")]
        public IHttpActionResult GetProductState(int countryId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetState(ad, countryId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/city")]
        public IHttpActionResult GetProductCity(int stateId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetCity(ad, stateId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("location/type")]
        public IHttpActionResult GetLocationType()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetLocationType(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/condition")]
        public IHttpActionResult GetPoductCondition()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetPoductCondition(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/material")]
        public IHttpActionResult GetPoductMaterial()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetPoductMaterial(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/uom")]
        public IHttpActionResult GetUnitOfMeasurement()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetUnitOfMeasurement(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("agency")]
        public IHttpActionResult GetAgency()
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetAgency(ad);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("agency/grade")]
        public IHttpActionResult GetAgencyGrade(int agencyId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetAgencyGrade(ad, agencyId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("agency/code/parent")]
        public IHttpActionResult GetAgencyCodeParent(int agencyId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetAgencyCodeParent(ad, agencyId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("agency/code")]
        public IHttpActionResult GetAgencyCode(int agencyCodeId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetAgencyCode(ad, agencyCodeId);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("departmentRole/list")]
        public IHttpActionResult GetDepartmentRoleList(string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = ReferenceBusiness.GetDepartmentRoleList(ad, searchKey, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("departmentRole/details")]
        public IHttpActionResult GetDepartmentRoleDetails(int id)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.GetDepartmentRoleDetails(ad, id);
                return Ok(response);
            }
        }

        //--------------------------------------
        //--------------PUT Method--------------
        //--------------------------------------
        [HttpPut]
        [Authorize]
        [Route("category/type")]
        public IHttpActionResult UpdateCategoryType(CategoryType categoryType)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.UpdateCategoryType(ad, categoryType);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("category/type/remove")]
        public IHttpActionResult DeleteCategoryTypeList(List<CategoryTypeToRemove> CategoryTypeToRemove)
        {
           
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ReferenceBusiness.DeleteCategoryTypeList(ad, CategoryTypeToRemove);
                return Ok(response);
            }

        }


        [HttpPut]
        [Authorize]
        [Route("agency")]
        public IHttpActionResult UpdateAgency(Agency Agency)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.UpdateAgency(ad, Agency);
                return Ok(response);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("agency/remove")]
        public IHttpActionResult DeleteAgencyList(List<AgencyToRemove> AgencyToRemove)
        {

            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ReferenceBusiness.DeleteAgencyList(ad, AgencyToRemove);
                return Ok(response);
            }

        }



        [HttpPut]
        [Authorize]
        [Route("agency/code")]
        public IHttpActionResult UpdateAgencyCode(AgencyCode AgencyCode)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.UpdateAgencyCode(ad, AgencyCode);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("agency/code/remove")]
        public IHttpActionResult DeleteAgencyCodeList(List<AgencyCodeToRemove> AgencyCodeToRemove)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ReferenceBusiness.DeleteAgencyCodeList(ad, AgencyCodeToRemove);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("agency/grade")]
        public IHttpActionResult UpdateAgencyGrade(AgencyGrade AgencyGrade)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.UpdateAgencyGrade(ad, AgencyGrade);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("agency/grade/remove")]
        public IHttpActionResult DeleteAgencyGradeList(List<AgencyGradeToRemove> AgencyGradeToRemove)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ReferenceBusiness.DeleteAgencyGradeList(ad, AgencyGradeToRemove);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("product/material")]
        public IHttpActionResult UpdateProductMaterial(ProductMaterial ProductMaterial)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.UpdateProductMaterial(ad, ProductMaterial);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("product/material/remove")]
        public IHttpActionResult DeleteProductMaterialList(List<ProductMaterialToRemove> ProductMaterialToRemove)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = ReferenceBusiness.DeleteProductMaterialList(ad, ProductMaterialToRemove);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("departmentRole")]
        public IHttpActionResult UpdateDepartmentRole(UpdateDepartmentRole request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.UpdateDepartmentRole(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }



        //---------------------------------------
        //--------------POST Method--------------
        //---------------------------------------

        [HttpPost]
        [Authorize]
        [Route("category/type")]
        public IHttpActionResult InsertCategoryType(CategoryType categoryType)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.InsertCategoryType(ad, categoryType);
                return Ok(response);
            }

        }


        [HttpPost]
        [Authorize]
        [Route("agency")]
        public IHttpActionResult InsertAgency(Agency Agency)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.InsertAgency(ad, Agency);
                return Ok(response);
            }

        }


        [HttpPost]
        [Authorize]
        [Route("agency/code")]
        public IHttpActionResult InsertAgencyCode(AgencyCode AgencyCode)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.InsertAgencyCode(ad, AgencyCode);
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("agency/grade")]
        public IHttpActionResult InsertAgencyGrade(AgencyGrade AgencyGrade)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.InsertAgencyGrade(ad, AgencyGrade);
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("product/material")]
        public IHttpActionResult InsertProductMaterial(ProductMaterial ProductMaterial)
        {
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.InsertProductMaterial(ad, ProductMaterial);
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("departmentRole")]
        public IHttpActionResult InsertDepartmentRole(InsertDepartmentRole request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.InsertDepartmentRole(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        //-----------------------------------------
        //--------------DELETE Method--------------
        //-----------------------------------------
        [HttpPut]
        [Authorize]
        [Route("departmentRole/delete")]
        public IHttpActionResult DeleteDepartmentRole(List<RefListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = ReferenceBusiness.DeleteDepartmentRole(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }
    }
}
