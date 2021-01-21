using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.PM;

namespace Toolaku.Models.PM
{
    public class TaskBoardRequest
    {
        
        public List<ProjectManagementStatusRequest> statusList { get; set; }

        public List<ProjectTaskByStatusAndPeopleRequest> projectTaskByStatusAndPeopleList { get; set; }
    }

    public class ProjectTaskByStatusAndPeoples : ResponseBase
    {
        public List<ProjectTaskByStatusAndPeopleRequest> taskByPeopleStatusList { get; set; }
    }

  

    public class ProjectTaskByStatusAndPeopleRequest
    {
        public int taskId { get; set; }
        public int rowNum { get; set; }
        public int level { get; set; }
        public int order { get; set; }
        public int taskPeopleId { get; set; }
        public int userId { get; set; }
        public int statusId { get; set; }
        public string taskName { get; set; }
    }

    public class ProjectTaskByStatusAndPeopleRequestUpdate
    {       
        public int taskPeopleId { get; set; }
        public int statusId { get; set; }
    }



}
