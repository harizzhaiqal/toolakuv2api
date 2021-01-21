using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.PM;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.PM
{
    public class ProjectManagementTaskRequest
    {
        public int id { get; set; }
        public int projectManagementId { get; set; }
        public string taskName { get; set; }
        public string userName { get; set; }
        public string tenantName { get; set; }
        public int parentId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string description { get; set; }
        public int order { get; set; }
        public string projectName { get; set; }
        public int flagCanDelete { get; set; }
        public string statusName { get; set; }
        public int CreatorUserId { get; set; }
        public int flagCanEdit { get; set; }

        public int totalSub { get; set; }
        
    }

    public class PMTaskDetailsWithListDocRequest
    {
        
        public ProjectManagementTaskRequest pmTaskDetails { get; set; }
        public List<ProjectManagementTaskDocumentRequest> documentList { get; set; }
    }


    public class PMTaskDetailsWithListDocListPeopleRequest
    {
        public ProjectManagementTaskRequest pmTaskDetails { get; set; }
        public List<ProjectManagementTaskDocumentRequest> documentList { get; set; }
        public List<ProjectManagementTaskPeopleRequest> peopleList { get; set; }
    }

    public class ProjectManagementTaskDocumentRequest
    {
        public int id { get; set; }
        public string attachmentURL { get; set; }
        public string description { get; set; }
        public string uploaderName { get; set; }
        public string uploaderTenantName { get; set; }
        public int flagShare { get; set; }
        public int flagDelete { get; set; }

    }

    public class ProjectManagementTaskPeopleRequest
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userTenant { get; set; }
        public string statusName { get; set; }
        
    }

    public class ProjectManagementUserRequest
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
    }

    public class ProjectManagementUsersRequest : ResponseBase
    {
        public List<ProjectManagementUserRequest> userList { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class ProjectManagementTenantRequest
    {
        public int id { get; set; }
        public string tenantName { get; set; }
    }

    public class ProjectManagementTenantsRequest : ResponseBase
    {
        public List<ProjectManagementTenantRequest> tenantList { get; set; }
    }

    public class ProjectManagementTaskDocumentUpsert
    {
        public int id { get; set; }
        public int projectManagementTaskId { get; set; }
        public string attachmentURL { get; set; }
        public string description { get; set; }
        public int flagShare { get; set; }
        public int userId { get; set; }
    }

    public class ProjectManagementTaskPeopleUpsert
    {
        public int id { get; set; }
        public int projectManagementTaskId { get; set; }
        public int userId { get; set; }
        public int createrUserId { get; set; }
    }

    public class ProjectManagementTaskPeopleBundleUpsert
    {
        public int userId { get; set; }       
    }

    public class ProjectManagementTaskPeoplesBundleUpsert
    {
        public List<ProjectManagementTaskPeopleBundleUpsert> ids { get; set; }
    }

    public class ProjectManagementTaskUpsert
    {
        public int id { get; set; }
        public int parentId { get; set; }
        public int projectManagementId { get; set; }
        public string taskName { get; set; }        
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string description { get; set; }
        public int order { get; set; }
        public int userId { get; set; }
    }


    

    public class ProjectManagementTaskPeoples : ResponseBase
    {
        public ProjectManagementTaskRequest pmTaskDetails { get; set; }
        public List<ProjectManagementTaskPeopleRequest> peopleList { get; set; }
    }

    public class ProjectManagementTasks : ResponseBase
    {
        public List<ProjectManagementTaskRequest> projectTaskList { get; set; }
    }

    public class ProjectManagementTask1Layers : ResponseBase
    {
        public ProjectManagementRequest pmProjectDetails { get; set; }
        public List<ProjectManagementTaskRequest> projectTaskList { get; set; }
    }

    public class ProjectManagementTBTask1Layers : ResponseBase
    {
        public ProjectManagementTaskRequest pmProjectTaskDetails { get; set; }
        public List<ProjectManagementTaskRequest> projectTaskList { get; set; }
    }


    public class ProjectManagementTaskDocuments : ResponseBase
    {
        public List<ProjectManagementTaskDocumentRequest> documentList { get; set; }
    }

    public class ProjectManagementTaskToRemove
    {
        public int ProjectManagementTaskId { get; set; }
    }

    public class ProjectManagementTasksToRemove
    {
        public List<ProjectManagementTaskToRemove> ids { get; set; }
    }

    public class ProjectManagementTaskPeopleToRemove
    {
        public int ProjectManagementTaskPeopleId { get; set; }
    }

    public class ProjectManagementTaskPeoplesToRemove
    {
        public List<ProjectManagementTaskPeopleToRemove> ids { get; set; }
    }

    public class ProjectManagementTaskDocumentToRemove
    {
        public int ProjectManagementTaskDocumentId { get; set; }
    }

    public class ProjectManagementTaskDocumentsToRemove
    {
        public List<ProjectManagementTaskDocumentToRemove> ids { get; set; }
    }

    public class ProjectManagementTaskPeopleToAdd
    {
        public int UserId { get; set; }
    }

    public class ProjectManagementTaskPeoplesToAdd
    {
        public int projectManagementTaskId { get; set; }
        public List<ProjectManagementTaskPeopleToAdd> userIds { get; set; }
    }

}
