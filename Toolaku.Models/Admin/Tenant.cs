using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Admin
{
    public class TenantList
    {
        public int TenantId { get; set; }
        public int RefEditionId { get; set; }
        public string TenantName { get; set; }
        public string BusinessRegistrationNo { get; set; }
        public string RefEditionName { get; set; }
    }


    public class NotificationLists : ResponseBase
    {
        public List<NotificationList> list { get; set; }
    }

    public class TenantListDT : ResponseBase
    {
        public List<TenantList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class NotificationCount : ResponseBase
    {
        public int Count { get; set; }
    }


    public class NotificationList : ResponseBase
    {
        public int NotificationCount { get; set; }
        public string EventName { get; set; }
        public string MenuPath { get; set; }
        public string ScreenPath { get; set; }
        public string TimeAgo { get; set; }
        public string listIds { get; set; }
        public string key { get; set; }
        public int useKey { get; set; }

    }



    public class NotificationInsert
    {
        public int TenantId { get; set; }
        public int RefModuleId { get; set; }
        public int CreatorUserId { get; set; }
        public string EventName { get; set; }
        public string MenuPath { get; set; }
        public string ScreenPath { get; set; }
    }


    public class NotificationUpdate
    {        
        public string ListNotificationId { get; set; }
    }


    

}