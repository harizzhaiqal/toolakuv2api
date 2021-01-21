using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.PM;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.PM
{
    public class ProjectManagementRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string description { get; set; }
    }


    public class PMDetailsWithListDocRequest
    {
        public ProjectManagementRequest pmDetails { get; set; }
        public List<ProjectManagementDocumentRequest> documentList { get; set; }
    }



    public class ProjectManagementDocumentRequest
    {
        public int id { get; set; }
        public string attachmentURL { get; set; }
        public string description { get; set; }
    }

    public class ProjectManagementStatusRequest
    {
        public int id { get; set; }
        public int projectManagemenId { get; set; }
        public string statusName { get; set; }
        public int flagComplete { get; set; }
        public int order { get; set; }
    }

    public class ProjectManagementDocumentUpsert
    {
        public int id { get; set; }
        public int projectManagementId { get; set; }
        public string attachmentURL { get; set; }
        public string description { get; set; }
    }

    public class ProjectManagementUpsert
    {
        public int id { get; set; }
        public string name { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string description { get; set; }
        public int tenantId { get; set; }
        public int userId { get; set; }
    }

    public class ProjectManagementStatuses : ResponseBase
    {
        public ProjectManagementRequest pmDetails { get; set; }
        public List<ProjectManagementStatusRequest> statusList { get; set; }
    }

    public class ProjectManagements : ResponseBase
    {
        public List<ProjectManagementRequest> projectList { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class ProjectManagementDocuments : ResponseBase
    {
        public List<ProjectManagementDocumentRequest> documentList { get; set; }
    }

    public class ProjectManagementToRemove
    {
        public int ProjectManagementId { get; set; }
    }

    public class ProjectManagementsToRemove
    {
        public List<ProjectManagementToRemove> ids { get; set; }
    }

    public class ProjectManagementDocumentToRemove
    {
        public int ProjectManagementDocumentId { get; set; }
    }

    public class ProjectManagementDocumentsToRemove
    {
        public List<ProjectManagementDocumentToRemove> ids { get; set; }
    }

    public class ProjectManagementTaskDeleteRequest
    {
        public int projectManagementTaskId { get; set; }
    }
}
