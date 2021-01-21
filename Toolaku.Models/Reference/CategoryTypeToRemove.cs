
using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class CategoryTypeToRemove
    {
        public int CategoryTypeId { get; set; }
    }

    public class CategoryTypesToRemove
    {
        public List<CategoryTypeToRemove> ids { get; set; }
    }

}
