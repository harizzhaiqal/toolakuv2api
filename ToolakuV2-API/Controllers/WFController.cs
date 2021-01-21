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
using Toolaku.Models.WF;
using Toolaku.Models.Pagingnation;

namespace ToolakuV2_API.Controllers
{
    [RoutePrefix("api/WF")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class WFController : ApiController
    {
        //--------------------------------------
        //--------------GET Method--------------
        //--------------------------------------

        [HttpGet]
        [Authorize]
        [Route("groupProcess/list")]
        public IHttpActionResult GetGroupProcessList(string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {   
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = WFBusiness.GetGroupProcessList(ad, searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("processByModule/list")]
        public IHttpActionResult GetProcessByModuleList(int moduleId, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = WFBusiness.GetProcessByModuleList(ad, moduleId, searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("processByParent/list")]
        public IHttpActionResult GetProcessByParentList(int parentId, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = WFBusiness.GetProcessByParentList(ad, parentId, searchKey, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("moduleState/list")]
        public IHttpActionResult GetModuleStateList(int parentId, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = WFBusiness.GetModuleStateList(ad, parentId, searchKey, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("processState/list")]
        public IHttpActionResult GetProcessStateList(int processId, int statePoint, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = WFBusiness.GetProcessStateList(ad, processId, statePoint, searchKey, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("tenantGroupProcess/list")]
        public IHttpActionResult GetTenantGroupProcessList(int tenantId, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = WFBusiness.GetTenantGroupProcessList(ad, tenantId, searchKey, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("processDepartmentRole/list")]
        public IHttpActionResult GetProcessDepartmentRoleList(int processId, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = WFBusiness.GetProcessDepartmentRoleList(ad, processId, searchKey, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("preProcess/list")]
        public IHttpActionResult GetPreProcessList(int processId, int groupProcessId, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = WFBusiness.GetPreProcessList(ad, processId, groupProcessId, searchKey, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("groupProcess/details")]
        public IHttpActionResult GetGroupProcessDetails(int id)
        {
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.GetGroupProcessDetails(ad, id);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("process/details")]
        public IHttpActionResult GetProcessDetails(int id)
        {
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.GetProcessDetails(ad, id);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("moduleState/details")]
        public IHttpActionResult GetModuleStateDetails(int id)
        {
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.GetModuleStateDetails(ad, id);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("processState/details")]
        public IHttpActionResult GetProcessStateDetails(int id)
        {
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.GetProcessStateDetails(ad, id);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("tenantGroupProcess/details")]
        public IHttpActionResult GetTenantGroupProcessDetails(int id)
        {
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.GetTenantGroupProcessDetails(ad, id);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("processDepartmentRole/details")]
        public IHttpActionResult GetProcessDepartmentRoleDetails(int id)
        {
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.GetProcessDepartmentRoleDetails(ad, id);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("preProcess/details")]
        public IHttpActionResult GetPreProcessDetails(int id)
        {
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.GetPreProcessDetails(ad, id);
                return Ok(response);
            }
        }


        //--------------------------------------
        //--------------POST Method--------------
        //--------------------------------------

        [HttpPost]
        [Authorize]
        [Route("groupProcess")]
        public IHttpActionResult InsertGroupProcess(InsertGroupProcess request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.InsertGroupProcess(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("process")]
        public IHttpActionResult InsertProcess(InsertProcess request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.InsertProcess(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("moduleState")]
        public IHttpActionResult InsertModuleState(InsertModuleState request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.InsertModuleState(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("processState")]
        public IHttpActionResult InsertProcessState(InsertProcessState request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.InsertProcessState(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("tenantGroupProcess")]
        public IHttpActionResult InsertTenantGroupProcess(InsertTenantGroupProcess request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.InsertTenantGroupProcess(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("processDepartmentRole")]
        public IHttpActionResult InsertProcessDepartmentRole(InsertProcessDepartmentRole request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.InsertProcessDepartmentRole(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("preProcess")]
        public IHttpActionResult InsertPreProcess(InsertPreProcess request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.InsertPreProcess(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        //--------------------------------------
        //--------------PUT Method--------------
        //--------------------------------------

        [HttpPut]
        [Authorize]
        [Route("groupProcess")]
        public IHttpActionResult UpdateGroupProcess(UpdateGroupProcess request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.UpdateGroupProcess(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("process")]
        public IHttpActionResult UpdateProcess(UpdateProcess request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.UpdateProcess(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("moduleState")]
        public IHttpActionResult UpdateModuleState(UpdateModuleState request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.UpdateModuleState(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("processState")]
        public IHttpActionResult UpdateProcessState(UpdateProcessState request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.UpdateProcessState(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("tenantGroupProcess")]
        public IHttpActionResult UpdateTenantGroupProcess(UpdateTenantGroupProcess request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.UpdateTenantGroupProcess(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("processDepartmentRole")]
        public IHttpActionResult UpdateProcessDepartmentRole(UpdateProcessDepartmentRole request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.UpdateProcessDepartmentRole(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("preProcess")]
        public IHttpActionResult UpdatePreProcess(UpdatePreProcess request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.UpdatePreProcess(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        //--------------------------------------
        //--------------DELETE Method--------------
        //--------------------------------------

        [HttpPut]
        [Authorize]
        [Route("groupProcess/delete")]
        public IHttpActionResult DeleteGroupProcess(List<WFListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.DeleteGroupProcess(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("process/delete")]
        public IHttpActionResult DeleteProcess(List<WFListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.DeleteProcess(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("moduleState/delete")]
        public IHttpActionResult DeleteModuleState(List<WFListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.DeleteModuleState(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("processState/delete")]
        public IHttpActionResult DeleteProcessState(List<WFListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.DeleteProcessState(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("tenantGroupProcess/delete")]
        public IHttpActionResult DeleteTenantGroupProcess(List<WFListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.DeleteTenantGroupProcess(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("processDepartmentRole/delete")]
        public IHttpActionResult DeleteProcessDepartmentRole(List<WFListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.DeleteProcessDepartmentRole(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("preProcess/delete")]
        public IHttpActionResult DeletePreProcess(List<WFListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = WFBusiness.DeletePreProcess(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

    }
}
