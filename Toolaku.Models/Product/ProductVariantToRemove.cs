
using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Product
{
    public class ProductVariantToRemove
    {
        public int ProductVariantId { get; set; }
    }

    public class ProductVariantsToRemove
    {
        public List<ProductVariantToRemove> ids { get; set; }
    }

}
