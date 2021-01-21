using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Sale
{
    public class TenantRfqHistory
    {
        public int tenantRfqHistoryId { get; set; }
        public int tenantRfqId { get; set; }
        public string rfqBody { get; set; }
        public string attachmentUrl { get; set; }
        public string flagSide { get; set; }
        public string CreationDateTime { get; set; }
        public string fileName { get; set; }
    }

    public class TenantRfqHistories : ResponseBase
    {
        public List<TenantRfqHistory> list { get; set; }
    }

    public class TenantRfqHistoryViewModal : ResponseBase
    {
        public TenantRfq titleInfo { get; set; }

        public List<TenantRfqHistory> historyList { get; set; }

        //public List<TenantRfqItem> rfqItem { get; set; }

        public List<TenantRfqItemVariant> rfqItemVariant { get; set; }
    }
}
