using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Public
{
    public class RfqTenderSummary : ResponseBase
    {
        public List<RFQTenderSummary> TenderResult { get; set; }
        public List<RFQTenderSummary> RfqResult { get; set; }
    }

    public class RFQTenderSummary
    {
        public int Id { get; set; }
        public string OfferType { get; set; }
        public string Agency { get; set; }
        public string Title { get; set; }
        public string ClosingDate { get; set; }
    }
}
