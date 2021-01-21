using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class ProductMaterialToRemove
    {
        public int ProductMaterialId { get; set; }
    }

    public class ProductMaterialsToRemove
    {
        public List<ProductMaterialToRemove> ids { get; set; }
    }

}

