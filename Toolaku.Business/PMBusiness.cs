using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models;
using Toolaku.Models.DTO;
using Toolaku.Models.PM;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Business
{
    public class PMBusiness
    {
        //--------------GET Method--------------
        /*
        public static ProjectManagements GetPMProjeckByTenantList(Adapter ad, int tenantId, string searchKey)
        {
            var response = new ProjectManagements();

            try
            {
                var result = PMDAL.GetPMProjeckByTenantList(ad, tenantId, searchKey);

                if (result.Count != 0)
                {
                    response.projectList = result;
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
        public static ProjectManagements GetPMProjeckByTenantList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new ProjectManagements();

            try
            {
                var result = PMDAL.GetPMProjeckByTenantList(ad, tenantId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.projectList = result.Item1;
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

        /*
        public static ProjectManagements GetPMProjeckByUserIdTaskList(Adapter ad, int userId, string searchKey)
        {
            var response = new ProjectManagements();

            try
            {
                var result = PMDAL.GetPMProjeckByUserIdTaskList(ad, userId, searchKey);

                if (result.Count != 0)
                {
                    response.projectList = result;
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

        public static ProjectManagements GetPMProjeckByUserIdTaskList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new ProjectManagements();

            try
            {
                var result = PMDAL.GetPMProjeckByUserIdTaskList(ad, userId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.projectList = result.Item1;
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

        public static PMDetailsWithListDocRequest GetPMProjectDetails(Adapter ad, int projectId)
        {
            var response = new PMDetailsWithListDocRequest();
            try
            {
                var pmDetails = PMDAL.GetPMProjectDetails(ad, projectId);
                response.pmDetails = pmDetails;

                var listDocument = PMDAL.GetPMProjeckDocumentList(ad, projectId);
                response.documentList = listDocument;
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static PMTaskDetailsWithListDocRequest GetPMProjectTaskDetailsWithListDoc(Adapter ad, int userId, int projectTaskId)
        {
            var response = new PMTaskDetailsWithListDocRequest();
            try
            {
                var pmTaskDetails = PMDAL.GetPMProjectTaskDetails(ad, projectTaskId, 0);
                response.pmTaskDetails = pmTaskDetails;

                var listDocument = PMDAL.GetPMProjeckTaskDocumentList(ad, userId, projectTaskId);
                response.documentList = listDocument;
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static PMTaskDetailsWithListDocListPeopleRequest GetPMProjectDetailsWithListDocListPeople(Adapter ad, int userId, int projectTaskId)
        {
            var response = new PMTaskDetailsWithListDocListPeopleRequest();
            try
            {
                var pmTaskDetails = PMDAL.GetPMProjectTaskDetails(ad, projectTaskId, userId);
                response.pmTaskDetails = pmTaskDetails;

                var listDocument = PMDAL.GetPMProjeckTaskDocumentList(ad, userId, projectTaskId);
                response.documentList = listDocument;

                var listPeople = PMDAL.GetPMProjeckTaskPeopleList(ad, projectTaskId, null);
                response.peopleList = listPeople;
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static ProjectTaskByStatusAndPeoples GetPMProjectTaskByStatusAndPeopleList(Adapter ad, int projectId, int statusId, int userId)
        {
            var response = new ProjectTaskByStatusAndPeoples();
            try
            {

                var taskList = PMDAL.GetPMProjectTaskByStatusAndPeopleList(ad, projectId, statusId, userId);
                response.taskByPeopleStatusList = taskList;

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static ProjectManagementStatuses GetPMProjeckStatusList(Adapter ad, int projectId)
        {
            var response = new ProjectManagementStatuses();
            try
            {

                var pmDetails = PMDAL.GetPMProjectDetails(ad, projectId);
                response.pmDetails = pmDetails;

                var statusList = PMDAL.GetPMProjeckStatusList(ad, projectId);
                response.statusList = statusList;

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static ProjectManagementDocuments GetPMProjeckDocumentList(Adapter ad, int projectManagementId)
        {
            var response = new ProjectManagementDocuments();

            try
            {
                var result = PMDAL.GetPMProjeckDocumentList(ad, projectManagementId);

                if (result.Count != 0)
                {
                    response.documentList = result;
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


        public static ProjectManagementTaskDocuments GetPMProjeckTaskDocumentList(Adapter ad, int userId, int projectTaskId)
        {
            var response = new ProjectManagementTaskDocuments();

            try
            {
                var result = PMDAL.GetPMProjeckTaskDocumentList(ad, userId, projectTaskId);

                if (result.Count != 0)
                {
                    response.documentList = result;
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



        public static ProjectManagementTaskPeoples GetPMProjeckTaskPeopleList(Adapter ad, int projectTaskId, string searchKey)
        {
            var response = new ProjectManagementTaskPeoples();

            try
            {
                var pmTaskDetails = PMDAL.GetPMProjectTaskDetails(ad, projectTaskId, 0);
                response.pmTaskDetails = pmTaskDetails;

                var peopleList = PMDAL.GetPMProjeckTaskPeopleList(ad, projectTaskId, searchKey);
                response.peopleList = peopleList;
                
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }


        public static ProjectManagementTenantsRequest GetPMTenantList(Adapter ad)
        {
            var response = new ProjectManagementTenantsRequest();

            try
            {
                var result = PMDAL.GetPMTenantList(ad);

                if (result.Count != 0)
                {
                    response.tenantList = result;
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

        /*
        public static ProjectManagementUsersRequest GetPMUserListByTenant(Adapter ad, int tenantId, string searchKey, int taskId)
        {
            var response = new ProjectManagementUsersRequest();

            try
            {
                var result = PMDAL.GetPMUserListByTenant(ad, tenantId, searchKey, taskId);

                if (result.Count != 0)
                {
                    response.userList = result;
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

        public static ProjectManagementUsersRequest GetPMUserListByTenant(Adapter ad, int tenantId, string searchKey, int taskId, Pager pager = null)
        {
            var response = new ProjectManagementUsersRequest();

            try
            {
                var result = PMDAL.GetPMUserListByTenant(ad, tenantId, searchKey, taskId, pager);

                if (result.Item1.Count != 0)
                {
                    response.userList = result.Item1;
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


        public static ProjectManagementTask1Layers GetPMProjeckTask1stLayerList(Adapter ad, int projectManagementId)
        {
            var response = new ProjectManagementTask1Layers();

            try
            {
                var pmPeojectDetails = PMDAL.GetPMProjectDetails(ad, projectManagementId);
                response.pmProjectDetails = pmPeojectDetails;

                var projectTaskList = PMDAL.GetPMProjeckTask1stLayerList(ad, projectManagementId);
                //response.projectTaskList = projectTaskList;

                if (projectTaskList.Count != 0)
                {
                    response.projectTaskList = projectTaskList;
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


        public static ProjectManagementTBTask1Layers GetPMTBProjeckTask1stLayerList(Adapter ad, int projectManagementTaskPeopleId, int userId)
        {
            var response = new ProjectManagementTBTask1Layers();

            try
            {
                var pmProjectTaskDetails = PMDAL.GetPMTBProjectTaskDetails_byLogin(ad, projectManagementTaskPeopleId);
                response.pmProjectTaskDetails = pmProjectTaskDetails;

                var projectTaskList = PMDAL.GetPMTBProjeckTask1stLayerList(ad, projectManagementTaskPeopleId, userId);
                
                if (projectTaskList.Count != 0)
                {
                    response.projectTaskList = projectTaskList;
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


        public static ProjectManagementTasks GetPMProjeckSubTaskList(Adapter ad, int parentTaskId)
        {
            var response = new ProjectManagementTasks();

            try
            {
                var result = PMDAL.GetPMProjeckSubTaskList(ad, parentTaskId);

                if (result.Count != 0)
                {
                    response.projectTaskList = result;
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


        public static ProjectManagementTasks GetPMTBProjeckSubTaskList(Adapter ad, int parentTaskId, int userId)
        {
            var response = new ProjectManagementTasks();

            try
            {
                var result = PMDAL.GetPMTBProjeckSubTaskList(ad, parentTaskId, userId);

                if (result.Count != 0)
                {
                    response.projectTaskList = result;
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

        //--------------PUT Method--------------

        public static BasicApiResponse UpdateProject(Adapter ad, ProjectManagementUpsert request)
        {
            var response = new BasicApiResponse();

            try
            {
                
                var result = PMDAL.UpdateProject(ad, request);

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

        public static BasicApiResponse UpdateProjectTaskPeopleStatus(Adapter ad, int peopleId, int statusId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = PMDAL.UpdateProjectTaskPeopleStatus(ad, peopleId, statusId);

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

        public static BasicApiResponse UpdateProjectTask(Adapter ad, ProjectManagementTaskUpsert request)
        {
            var response = new BasicApiResponse();

            try
            {                
                    var result = PMDAL.UpdateProjectTask(ad, request);

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

        public static PostApiResponse InsertPMInsertProject(Adapter ad, int tenantId, int userId, ProjectManagementUpsert requestUpsert)
        {
            var response = new PostApiResponse();
            
            try
            {
                
                var result = PMDAL.InsertPMInsertProject(ad, tenantId, userId, requestUpsert);

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


        public static PostApiResponse InsertPMInsertProjectTask(Adapter ad, int projectId, int parentTaskId, int userId, ProjectManagementTaskUpsert requestUpsert)
        {
            var response = new PostApiResponse();
           
            try
            {
                
                var result = PMDAL.InsertPMInsertProjectTask(ad, projectId, parentTaskId, userId, requestUpsert);

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

        public static PostApiResponse InsertPMInsertProjectDocument(Adapter ad, ProjectManagementDocumentUpsert request)
        {
            var response = new PostApiResponse();

            try
            {
                var result = PMDAL.InsertPMInsertProjectDocument(ad, request);

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

        public static PostApiResponse InsertPMInsertProjectTaskDocument(Adapter ad, int userId, ProjectManagementTaskDocumentUpsert request)
        {
            var response = new PostApiResponse();

            try
            {
                var result = PMDAL.InsertPMInsertProjectTaskDocument(ad, userId, request);

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


        public static PostApiResponse InsertPMInsertProjectTaskPeople(Adapter ad, int projectManagementTaskId, int userId, List<ProjectManagementTaskPeopleToAdd> userIds)
        {
            var response = new PostApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;
            var returnMsg = "";

            try
            {
                

                foreach (var id in userIds)
                {
                    var result = PMDAL.InsertPMInsertProjectTaskPeople(ad, projectManagementTaskId, userId, id.UserId);
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                        returnMsg =  result.ResponseMessage;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "People successfully added";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = returnMsg;
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

        public static BasicApiResponse DeletePMProject(Adapter ad, List<ProjectManagementToRemove> ids)
        {
            var response = new BasicApiResponse();

            try
            {
                var inIds = "0";
               foreach (var id in ids)
                {
                    inIds += ","+id.ProjectManagementId;
                }
                var result = PMDAL.DeletePMProject(ad, inIds);

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
            }

            return response;
        }

        public static BasicApiResponse DeletePMProjectTask(Adapter ad, int projectTaskId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = PMDAL.DeletePMProjectTask(ad, projectTaskId);

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

        /*
        public static BasicApiResponse DeletePMProjectTask(Adapter ad, List<ProjectManagementTaskToRemove> ids)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in ids)
                {
                    var result = PMDAL.DeletePMProjectTask(ad, Convert.ToInt32(id.ProjectManagementTaskId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Project Task successfully deleted";
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }
        */

        

        public static BasicApiResponse DeletePMProjectDocument(Adapter ad, List<ProjectManagementDocumentToRemove> ids)
        {
            var response = new BasicApiResponse();

            try
            {
                var inIds = "0";
                foreach (var id in ids)
                {
                    inIds += "," + id.ProjectManagementDocumentId;
                }
                var result = PMDAL.DeletePMProjectDocument(ad, inIds);

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
            }

            return response;
        }


        public static BasicApiResponse DeletePMProjectTaskDocument(Adapter ad, List<ProjectManagementTaskDocumentToRemove> ids)
        {
            var response = new BasicApiResponse();

            try
            {
                var inIds = "0";
                foreach (var id in ids)
                {
                    inIds += "," + id.ProjectManagementTaskDocumentId;
                }
                var result = PMDAL.DeletePMProjectTaskDocument(ad, inIds);

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
            }

            return response;
        }
                

        public static BasicApiResponse DeletePMProjectTaskPeople(Adapter ad, List<ProjectManagementTaskPeopleToRemove> ids)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                var inIds = "0";
                foreach (var id in ids)
                {
                    inIds += "," + id.ProjectManagementTaskPeopleId;
                }
                var result = PMDAL.DeletePMProjectTaskPeople(ad, inIds);

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
