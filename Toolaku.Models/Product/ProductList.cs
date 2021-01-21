using System.Collections.Generic;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models
{
    public class ProductList
    {
        public int productId { get; set; }
        public string imageURL { get; set; }
        public string productName { get; set; }
        public string skuNo { get; set; }
        public string category { get; set; }
        public bool listing { get; set; }
    }

    public class ProductLists : ResponseBase
    {
        public List<ProductList> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class ProductToRemove
    {
        public int productId { get; set; }
    }
    public class ProductToRemoves
    {
        public List<ProductToRemove> request { get; set; }
    }
}
