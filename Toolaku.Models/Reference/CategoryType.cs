
using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models
{
    public class CategoryType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }

    public class CategoryTypes : ResponseBase
    {
        public IList<CategoryType> Result { get; set; }
    }       

}
