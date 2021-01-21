using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class ProductCategory
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }

    public class ProductCategories : ResponseBase
    {
        public List<ProductCategory> result { get; set; }
    }
}
