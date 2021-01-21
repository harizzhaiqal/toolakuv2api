using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class ServiceCategory
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }
    public class ServiceCategories : ResponseBase
    {
        public List<ServiceCategory> result { get; set; }
    }
}
