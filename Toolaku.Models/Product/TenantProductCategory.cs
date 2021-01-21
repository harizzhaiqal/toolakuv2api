using Toolaku.Models.DTO;

namespace Toolaku.Models.Product
{
    public class TenantProductCategory : ResponseBase
    {
        public int level1CatId { get; set; }
        public int level2CatId { get; set; }
        public int level3CatId { get; set; }
    }

    public class TenantProductCategoryUpdate
    {
        public int productId { get; set; }
        public int level1CatId { get; set; }
        public int level2CatId { get; set; }
        public int level3CatId { get; set; }
    }
}
