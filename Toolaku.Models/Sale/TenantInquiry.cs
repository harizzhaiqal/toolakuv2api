using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Sale
{
    public class TenantInquiry
    {
        public int tenantInquiryId { get; set; }
        public string ticketNo { get; set; }
        public string title { get; set; }
        public int toTenantId { get; set; }
        public string toTenantName { get; set; }
        public int fromUserId { get; set; }
        public string fromTenantName { get; set; }
        public int inquiryStatusSaleId { get; set; }
        public string inquiryStatusSaleName { get; set; }
        public int inquiryStatusQuotId { get; set; }
        public string inquiryStatusQuotName { get; set; }
        public int tenantProductId { get; set; }
        public string CreationDateTime { get; set; }
        public string productName { get; set; }
        public string ToTenantlogoUrl { get; set; }
        public string FromTenantlogoUrl { get; set; }

    }

    public class TenantInquiryUpdateStatusRequest
    {
        public int tenantInquiryId { get; set; }
        public int inquiryStatusSaleId { get; set; }
        public int inquiryStatusQuotId { get; set; }
    }

    public class TenantInquiries : ResponseBase
    {
        public List<TenantInquiry> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }
}
