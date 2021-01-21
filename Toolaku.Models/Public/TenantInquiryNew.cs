using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Public
{
    public class TenantInquiryNew
    {
        public int tenantInquiryId { get; set; }
        public string ticketNo { get; set; }
        public string title { get; set; }
        public int toTenantId { get; set; }
        public int fromUserId { get; set; }
        public int inquiryStatusSaleId { get; set; }
        public int inquiryStatusQuotId { get; set; }
        public int tenantProductId { get; set; }
        public string inquiryBody { get; set; }
    }
}