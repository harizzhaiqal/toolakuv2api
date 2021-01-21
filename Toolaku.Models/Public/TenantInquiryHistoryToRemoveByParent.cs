using System;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Models.Public
{
    public class TenantInquiryHistoryToRemoveByParent
    {
        public int tenantInquiryId { get; set; }
    }
    public class TenantInquiryHistoriesToRemoveByParent
    {
        public List<TenantInquiryHistoryToRemoveByParent> removeIds { get; set; }
    }
}
