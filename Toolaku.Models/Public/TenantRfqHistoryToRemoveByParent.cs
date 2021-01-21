using System;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Models.Public
{
    public class TenantRfqHistoryToRemoveByParent
    {
        public int tenantRfqId { get; set; }
    }
    public class TenantRfqHistoriesToRemoveByParent
    {
        public List<TenantRfqHistoryToRemoveByParent> removeIds { get; set; }
    }
}
