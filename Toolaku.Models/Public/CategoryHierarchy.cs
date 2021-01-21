using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Public
{
    public class CategoryHierarchy
    {
        public string TypeName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ShortDescription { get; set; }
    }

    public class CategoryHierarchys : ResponseBase
    {
        public List<CategoryHierarchy> Result { get; set; }
    }
}
