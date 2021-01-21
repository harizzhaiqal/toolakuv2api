using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Public
{
    public class ServiceCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public int ParentCategoryId { get; set; }
    }

    public class ServiceCategories : ResponseBase
    {
        public int ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        public List<ServiceCategory> CategoryList { get; set; }
    }
}
