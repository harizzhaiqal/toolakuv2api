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
using Toolaku.Models.PM;
using Toolaku.Models.Pagingnation;


namespace ToolakuV2_API.Controllers
{
    [RoutePrefix("api/pm")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class PMController : ApiController
    {
        //--------------GET Method--------------

        [HttpGet]
        [AllowAnonymous]
        [Route("tenant/list")]
        public IHttpActionResult GetPMTenantList()
        {
           
            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMTenantList(ad);
                return Ok(response);
            }
        }

        /*
        [HttpGet]
        [AllowAnonymous]
        [Route("user/list")]
        public IHttpActionResult GetPMUserListByTenant(int taskId, string searchKey, int tenantId = 0)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMUserListByTenant(ad, tenantId, searchKey, taskId);
                return Ok(response);
            }
        }
        */


        [HttpGet]
        [Authorize]
        [Route("user/list/default")]
        public IHttpActionResult GetPMUserListDefaultByTenant(int taskId, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
                var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = PMBusiness.GetPMUserListByTenant(ad, Convert.ToInt32(tenantId), searchKey, taskId, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("project/list")]
        public IHttpActionResult GetPMProjeckByTenantList(string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;
                var response = PMBusiness.GetPMProjeckByTenantList(ad, Convert.ToInt32(tenantId), searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("project/listByUserTask")]
        public IHttpActionResult GetPMProjeckByUserIdTaskList(string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
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

                var response = PMBusiness.GetPMProjeckByUserIdTaskList(ad, Convert.ToInt32(userId), searchKey, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("project")]
        public IHttpActionResult GetPMProjectDetails(int projectManagementId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMProjectDetails(ad, projectManagementId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("project/task")]
        public IHttpActionResult GetPMProjectTaskDetails(int projectManagementTaskId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMProjectTaskDetailsWithListDoc(ad, 0, projectManagementTaskId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("project/task/main/list")]
        public IHttpActionResult GetPMProjeckTask1stLayerList(int projectManagementId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMProjeckTask1stLayerList(ad, Convert.ToInt32(projectManagementId));
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("project/task/sub/list")]
        public IHttpActionResult GetPMProjeckSubTaskList(int projectManagemenTaskId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMProjeckSubTaskList(ad, Convert.ToInt32(projectManagemenTaskId));
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("project/task/people/list")]
        public IHttpActionResult GetPMProjeckTaskPeopleList(int projectManagemenTaskId, string searchKey)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMProjeckTaskPeopleList(ad, Convert.ToInt32(projectManagemenTaskId), searchKey);
                return Ok(response);
            }

        }


        [HttpGet]
        [AllowAnonymous]
        [Route("taskBoard/status/list")]
        public IHttpActionResult GetPMProjeckStatusList(int projectManagementId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMProjeckStatusList(ad, projectManagementId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("taskBoard/task/list")]
        public IHttpActionResult GetPMProjectTaskByStatusAndPeopleList(int projectManagementId, int statusId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMProjectTaskByStatusAndPeopleList(ad, projectManagementId, statusId, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("taskBoard/task/main/list")]
        public IHttpActionResult GetPMTBProjeckTask1stLayerList(int projectManagementTaskPeopleId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMTBProjeckTask1stLayerList(ad, Convert.ToInt32(projectManagementTaskPeopleId), Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("taskBoard/task/sub/list")]
        public IHttpActionResult GetPMTBProjeckSubTaskList(int projectManagementTaskId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMTBProjeckSubTaskList(ad, Convert.ToInt32(projectManagementTaskId), Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("taskBoard/task/view")]
        public IHttpActionResult GetPMProjectDetailsWithListDocListPeople(int projectManagementTaskId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.GetPMProjectDetailsWithListDocListPeople(ad, Convert.ToInt32(userId), Convert.ToInt32(projectManagementTaskId));
                return Ok(response);
            }
        }

        //--------------PUT Method--------------

        [HttpPut]
        [Authorize]
        [Route("project")]
        public IHttpActionResult UpdateProject(ProjectManagementUpsert upsert)
        {
            var response = new BasicApiResponse();
            var errMsg = "";

            if (upsert.name == "")
            {
                errMsg += "Project name is required. ";
            }
            else if (DateTime.Parse(upsert.endDate) < DateTime.Parse(upsert.startDate))
            {
                errMsg += "End Date must be after the start date. ";
            }


            if (errMsg != "")
            {
                response.ReturnCode = 401;
                response.ResponseMessage = errMsg;
            }
            else
            {
                using (Adapter ad = new Adapter())
                {
                    response = PMBusiness.UpdateProject(ad, upsert);                    
                }
            }
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        [Route("project/task")]
        public IHttpActionResult UpdateProjectTask(ProjectManagementTaskUpsert upsert)
        {
            var response = new BasicApiResponse();
            var errMsg = "";

            if (upsert.taskName == "")
            {
                errMsg += "Task name is required. ";
            }
            else if (DateTime.Parse(upsert.endDate) < DateTime.Parse(upsert.startDate))
            {
                errMsg += "End Date must be after the start date. ";
            }


            if (errMsg != "")
            {
                response.ReturnCode = 401;
                response.ResponseMessage = errMsg;
            }
            else
            {
                using (Adapter ad = new Adapter())
                {
                    response = PMBusiness.UpdateProjectTask(ad, upsert);
                    
                }
            }
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        [Route("taskBoard/task")]
        //public IHttpActionResult UpdateProjectTaskPeopleStatus(int taskPeopleId, int statusId)
        public IHttpActionResult UpdateProjectTaskPeopleStatus(ProjectTaskByStatusAndPeopleRequestUpdate request)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.UpdateProjectTaskPeopleStatus(ad, request.taskPeopleId, request.statusId);
                return Ok(response);
            }
        }

        //--------------POST Method--------------

        [HttpPost]
        [Authorize]
        [Route("project")]
        public IHttpActionResult InsertPMInsertProject(ProjectManagementUpsert upsert)
        {
            var response = new PostApiResponse();
            var errMsg = "";

            if (upsert.name == "")
            {
                errMsg += "Project name is required. ";
            }
            else if (upsert.endDate != "" && upsert.startDate != "" && (DateTime.Parse(upsert.endDate) < DateTime.Parse(upsert.startDate)))
            {
                errMsg += "End Date must be after the start date. ";
            }


            if (errMsg != "")
            {
                response.ReturnCode = 401;
                response.ResponseMessage = errMsg;
            }
            else
            {

                ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
                var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
                var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

                using (Adapter ad = new Adapter())
                {
                    response = PMBusiness.InsertPMInsertProject(ad, Convert.ToInt32(tenantId), Convert.ToInt32(userId), upsert);
                }
            }
            return Ok(response);

        }

        [HttpPost]
        [Authorize]
        [Route("project/document")]
        public IHttpActionResult InsertPMInsertProjectDocument(ProjectManagementDocumentUpsert upsert)
        {
            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.InsertPMInsertProjectDocument(ad, upsert);
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("project/task")]
        public IHttpActionResult InsertPMInsertProjectTask(ProjectManagementTaskUpsert requestUpsert)
        {
            var response = new PostApiResponse();
            var errMsg = "";

            if (requestUpsert.taskName == "")
            {
                errMsg += "Task name is required. ";
            }
            else if (DateTime.Parse(requestUpsert.endDate) < DateTime.Parse(requestUpsert.startDate))
            {
                errMsg += "End Date must be after the start date. ";
            }


            if (errMsg != "")
            {
                response.ReturnCode = 401;
                response.ResponseMessage = errMsg;
            }
            else
            {
                ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
                var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
                var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

                using (Adapter ad = new Adapter())
                {
                    response = PMBusiness.InsertPMInsertProjectTask(ad, requestUpsert.projectManagementId, requestUpsert.parentId, Convert.ToInt32(userId), requestUpsert);
                   
                }
            }
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        [Route("project/task/document")]
        public IHttpActionResult InsertPMInsertProjectTaskDocument(ProjectManagementTaskDocumentUpsert upsert)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.InsertPMInsertProjectTaskDocument(ad, Convert.ToInt32(userId), upsert);
                return Ok(response);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("project/task/people")]
        //public IHttpActionResult InsertPMInsertProjectTaskPeople(int projectManagementTaskId, List<ProjectManagementTaskPeopleToAdd> userIds)
        public IHttpActionResult InsertPMInsertProjectTaskPeople(ProjectManagementTaskPeoplesToAdd request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = PMBusiness.InsertPMInsertProjectTaskPeople(ad, request.projectManagementTaskId, Convert.ToInt32(userId), request.userIds);
                return Ok(response);
            }
        }

        //--------------DELETE Method--------------

        [HttpPut]
        [Authorize]
        [Route("project/delete")]
        public IHttpActionResult DeletePMProject(List<ProjectManagementToRemove> ids)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = PMBusiness.DeletePMProject(ad, ids);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("project/document/delete")]
        public IHttpActionResult DeletePMProjectDocument(List<ProjectManagementDocumentToRemove> ids)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = PMBusiness.DeletePMProjectDocument(ad, ids);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("project/task/document/delete")]
        public IHttpActionResult DeletePMProjectTaskDocument(List<ProjectManagementTaskDocumentToRemove> ids)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = PMBusiness.DeletePMProjectTaskDocument(ad, ids);
                return Ok(response);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("project/task/delete")]
        public IHttpActionResult DeletePMProjectTask(int projectManagementTaskId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = PMBusiness.DeletePMProjectTask(ad, projectManagementTaskId);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("project/task/people/delete")]
        public IHttpActionResult DeletePMProjectTaskPeople(List<ProjectManagementTaskPeopleToRemove> ids)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new BasicApiResponse();

                response = PMBusiness.DeletePMProjectTaskPeople(ad, ids);
                return Ok(response);
            }
        }

    }
}
