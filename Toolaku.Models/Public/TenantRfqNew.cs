using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Public
{
    public class TenantRfqNew
    {
        public int tenantRfqId { get; set; }
        public string rfqNo { get; set; }
        public string title { get; set; }
        public int toTenantId { get; set; }
        public int fromUserId { get; set; }
        public int rfqStatusSaleId { get; set; }
        public int rfqStatusQuotId { get; set; }
        public string rfqBody { get; set; }
        public string attachmentUrl { get; set; }
        public List<TenantRfqItemVariantNew> itemVariants { get; set; }

    }

    public class TenantRfqNew2
    {
        public int productServiceId { get; set; }
        public string rfqNo { get; set; }
        public int categoryTypeId { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public int toTenantId { get; set; }
        public int fromUserId { get; set; }
        public int rfqStatusSaleId { get; set; }
        public int rfqStatusQuotId { get; set; }
        public string rfqBody { get; set; }
        public int productUomId { get; set; }
        


    }
}


