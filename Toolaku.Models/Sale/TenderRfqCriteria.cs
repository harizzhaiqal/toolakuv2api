using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Sale
{
    public class TenderRfqCriteria
    {

        public int tenderRfqCriteriaId { get; set; }
        public int tenderRfqId { get; set; }
        public int agengyGradeId { get; set; }
        public int agengyCodeId { get; set; }
        public string agengyCodeCode { get; set; }
        public string agengyCodeName { get; set; }
        public string agengyGradeCode { get; set; }
        public string agengyGradeDescription { get; set; }
    }

    public class TenderRfqCriterias : ResponseBase
    {
        public List<TenderRfqCriteria> list { get; set; }
    }
}
