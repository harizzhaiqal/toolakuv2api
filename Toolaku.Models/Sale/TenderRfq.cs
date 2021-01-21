using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Sale
{
    public class TenderRfq
    {

        public int tenderRfqId { get; set; }
        public int offerTypeId { get; set; }
        public string offerTypeName { get; set; }
        public string publishDate { get; set; }
        public string closingDate { get; set; }
        public int agencyId { get; set; }
        public string agencyName { get; set; }
        public string idNo { get; set; }
        public string title { get; set; }
        public int briefingTypeId { get; set; }
        public string briefingTypeName { get; set; }        
        public string briefingDateTime { get; set; }
        public string briefingVenue { get; set; }
        public decimal documentFee { get; set; }
        public string docAttachmentURL { get; set; }
        public string criteria { get; set; }
    }

    public class TenderRfqs : ResponseBase
    {
        public List<TenderRfq> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class TenderRfqViewModal : ResponseBase
    {
        public TenderRfq tenderRfqDetails { get; set; }

        public List<TenderRfqCriteria> criteriaList { get; set; }
    }
}
