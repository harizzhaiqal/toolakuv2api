using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Sale
{
    public class TenantRfqHistoryNew
    {
        public int tenantRfqHistoryId { get; set; }
        public int tenantRfqId { get; set; }
        public string rfqBody { get; set; }
        public string attachmentUrl { get; set; }
        public int rfqStatusSaleId { get; set; }
        public int rfqStatusQuotId { get; set; }
        public string flagSide { get; set; }
        public string fileName { get; set; }
    }

}
