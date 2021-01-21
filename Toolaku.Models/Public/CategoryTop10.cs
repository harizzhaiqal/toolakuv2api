using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Public
{
    public class CategoryTop10
    {
        public string IconURL { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
        public string ShortDescription { get; set; }
    }

    public class CategoryTop10s : ResponseBase
    {
        public IList<CategoryTop10> Result { get; set; }
    }
}
