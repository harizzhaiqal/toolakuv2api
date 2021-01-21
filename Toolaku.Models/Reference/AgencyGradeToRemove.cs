
using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class AgencyGradeToRemove
    {
        public int AgencyGradeId { get; set; }
    }

    public class AgencyGradesToRemove
    {
        public List<AgencyGradeToRemove> ids { get; set; }
    }

}

