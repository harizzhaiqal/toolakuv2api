using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Public
{
    public class ProductByCategory
    {
        public int Id { get; set; }
        public string ItemImage { get; set; }
        public string ItemImage2 { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ShortDescription { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
    }

    public class ProductByCategories : ResponseBase
    {
        public List<ProductByCategory> Result { get; set; }
    }
}
