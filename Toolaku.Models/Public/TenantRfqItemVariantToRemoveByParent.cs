using System;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Models.Public
{
    public class TenantRfqItemVariantToRemoveByParent
    {
        public int tenantRfqId { get; set; }
    }
    public class TenantRfqItemVariantsToRemoveByParent
    {
        public List<TenantRfqItemVariantToRemoveByParent> removeIds { get; set; }
    }
}
