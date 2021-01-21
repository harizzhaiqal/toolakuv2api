using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Sale
{
    public class TenantInquiryHistory
    {
        public int tenantInquiryHistoryId { get; set; }
        public int tenantInquiryId { get; set; }
        public string inquiryBody { get; set; }
        public string flagSide { get; set; }
        public string CreationDateTime { get; set; }
    }

    public class TenantInquiryHistories : ResponseBase
    {
        public List<TenantInquiryHistory> list { get; set; }
    }

    public class TenantInquiryHistoryViewModal : ResponseBase
    {
        public TenantInquiry titleInfo { get; set; }

        public List<TenantInquiryHistory> historyList { get; set; }
    }
}
