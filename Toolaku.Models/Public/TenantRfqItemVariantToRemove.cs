using System;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Models.Public
{
    public class TenantRfqItemVariantToRemove
    {
        public int tenantRfqItemVariantId { get; set; }
    }
    public class TenantRfqItemVariantsToRemove
{
        public List<TenantRfqItemVariantToRemove> removeIds { get; set; }
    }
}
