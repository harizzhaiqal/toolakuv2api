using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Sale
{
    public class TenantRfqItemNew
    {
        public int tenantRfqItemId { get; set; }
        public int tenantRfqId { get; set; }
        public int productId { get; set; }
        public int serviceId { get; set; }
        public int categoryTypeId { get; set; }
        public int quantity { get; set; }
        public int uomId { get; set; }
    }
}
