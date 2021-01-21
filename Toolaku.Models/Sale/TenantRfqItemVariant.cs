using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Sale
{
    public class TenantRfqItemVariant
    {
        public int tenantRfqItemVariantId { get; set; }
        public int tenantRfqId { get; set; }
        public int productServiceVariantId { get; set; }

        public string productServiceVariantName { get; set; }
        public int categoryTypeId { get; set; }
        public string categoryTypeName { get; set; }
        public int quantity { get; set; }
        public int uomId { get; set; }
        public string uomName { get; set; }
        public string quantityUnit { get; set; }
        public string productServiceVariantNo { get; set; }
        public string productServiceName { get; set; }


    }

    public class TenantRfqItemVariants : ResponseBase
    {
        public List<TenantRfqItemVariant> list { get; set; }
    }
}
