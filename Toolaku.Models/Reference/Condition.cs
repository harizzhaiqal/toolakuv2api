using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class Condition
    {
        public int ConditionId { get; set; }
        public string ConditionCode { get; set; }
    }

    public class Conditions : ResponseBase
    {
        public List<Condition> Result { get; set; }
    }
}
