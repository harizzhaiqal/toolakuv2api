using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Sale
{
    public class TenantRfqItem
    {
        public int tenantRfqItemId { get; set; }
        public int tenantRfqId { get; set; }
        public int productServiceId { get; set; }

        public string productServiceName { get; set; }
        public int categoryTypeId { get; set; }
        public string categoryTypeName { get; set; }
        public int quantity { get; set; }
        public int uomId { get; set; }
        public string uomName { get; set; }
        public string quantityUnit { get; set; }
        public string productServiceNo { get; set; }

        
    }

    public class TenantRfqItems : ResponseBase
    {
        public List<TenantRfqItem> list { get; set; }
    }
}
