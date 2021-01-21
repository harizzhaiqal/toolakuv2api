using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Sale
{
    public class TenantRfq
    {
        public int tenantRfqId { get; set; }
        public string rfqNo { get; set; }
        public string title { get; set; }
        public int toTenantId { get; set; }
        public string toTenantName { get; set; }
        public int fromUserId { get; set; }
        public string fromTenantName { get; set; }
        public int rfqStatusSaleId { get; set; }
        public string rfqStatusSaleName { get; set; }
        public int rfqStatusQuotId { get; set; }
        public string rfqStatusQuotName { get; set; }
        public string CreationDateTime { get; set; }
        public string ToTenantlogoUrl { get; set; }
        public string FromTenantlogoUrl { get; set; }
    }

    public class TenantRfqUpdateStatusRequest
    {
        public int tenantRfqId { get; set; }
        public int rfqStatusSaleId { get; set; }
        public int rfqStatusQuotId { get; set; }
    }

    public class TenantRfqs : ResponseBase
    {
        public List<TenantRfq> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }
}
