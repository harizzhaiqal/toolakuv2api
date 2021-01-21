
using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class AgencyCodeToRemove
    {
        public int AgencyCodeId { get; set; }
    }

    public class AgencyCodesToRemove
    {
        public List<AgencyCodeToRemove> ids { get; set; }
    }

}
