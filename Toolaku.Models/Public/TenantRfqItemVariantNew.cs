using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Public
{
    public class TenantRfqItemVariantNew
    {
        public int tenantRfqItemVariantId { get; set; }
        public int tenantRfqId { get; set; }
        public int productVariantId { get; set; }
        public int serviceVariantId { get; set; }
        public int categoryTypeId { get; set; }
        public int quantity { get; set; }
        public int uomId { get; set; }
    }

    public class EmailNewsletterReq
    {
        public string email { get; set; }
    }
}
