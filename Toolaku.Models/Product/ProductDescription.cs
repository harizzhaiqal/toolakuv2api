using Toolaku.Models.DTO;

namespace Toolaku.Models.Product
{
    public class ProductDescription : ResponseBase
    {
        public int productId { get; set; }
        public string description { get; set; }
    }

    public class ProductDescriptionUpdate
    {
        public int productId { get; set; }
        public string description { get; set; }
    }
}
