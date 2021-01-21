using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Sale
{
    public class TenantInquiryRfqList
    {
        public int Id { get; set; }
        public string type { get; set; }
        public string refNo { get; set; }
        public string title { get; set; }
        public int toTenantId { get; set; }
        public string toTenantName { get; set; }
        public int fromUserId { get; set; }
        public string fromTenantName { get; set; }
        public int statusSaleId { get; set; }
        public string statusSaleName { get; set; }
        public int statusQuotId { get; set; }
        public string statusQuotName { get; set; }
        public int statusId { get; set; }
        public string CreationDateTime { get; set; }
    }

    public class TenantInquiryRfqLists : ResponseBase
    {
        public List<TenantInquiryRfqList> list { get; set; }

        public PageInfo pageInfo { get; set; }

    }
}
