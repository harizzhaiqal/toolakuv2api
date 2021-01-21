using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Sale
{
    public class TenantInquiryHistoryNew
    {
        public int tenantInquiryHistoryId { get; set; }
        public int tenantInquiryId { get; set; }
        public string inquiryBody { get; set; }
        public int inquiryStatusSaleId { get; set; }
        public int inquiryStatusQuotId { get; set; }
        public string flagSide { get; set; }
    }
}

    
