using Toolaku.Models.DTO;

namespace Toolaku.Models.Product
{
    public class ProductInventory
    {
        public int availableStock { get; set; }
        public int moq { get; set; }
        public int uomId { get; set; }
        public decimal priceUnit { get; set; }
        public int countryId { get; set; }
        public int stateId { get; set; }
        public int cityId { get; set; }
        public string city { get; set; }


    }
    public class ProductInventoryIn
    {
        public int productId { get; set; }
        public int availableStock { get; set; }
        public int moq { get; set; }
        public int uomId { get; set; }
        public decimal priceUnit { get; set; }
        public int countryId { get; set; }
        public int stateId { get; set; }
        public int cityId { get; set; }
        public string city { get; set; }
    }
    public class ProductInventoryUp
    {
        public int inventoryId { get; set; }
        public int availableStock { get; set; }
        public int moq { get; set; }
        public int uomId { get; set; }
        public decimal priceUnit { get; set; }
        public int countryId { get; set; }
        public int stateId { get; set; }
        public int cityId { get; set; }
        public string city { get; set; }
    }
}
