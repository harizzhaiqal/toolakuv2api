using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Sale
{
    public class TenantRfqDocument
    {
        public int tenantRfqDocumentId { get; set; }
        public int tenantRfqId { get; set; }
        public string attachmentURL { get; set; }
    }

    public class TenantRfqDocuments : ResponseBase
    {
        public List<TenantRfqDocument> list { get; set; }
    }
}
