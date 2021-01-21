
using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class AgencyToRemove
    {
        public int AgencyId { get; set; }
    }

    public class AgenciesToRemove
    {
        public List<AgencyToRemove> ids { get; set; }
    }

}
