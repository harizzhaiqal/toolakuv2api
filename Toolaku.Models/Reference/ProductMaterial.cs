using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class ProductMaterial
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string Description { get; set; }
    }

    public class ProductMaterials : ResponseBase
    {
        public List<ProductMaterial> Result { get; set; }
    }
}
