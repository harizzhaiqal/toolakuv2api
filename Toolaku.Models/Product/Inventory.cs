using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Product
{
    public class Inventory
    {
        public int inventoryId { get; set; }
        public int availableStock { get; set; }
        public int moq { get; set; }
        public string uom { get; set; }
        public decimal priceUnit { get; set; }
        public string stockLocation { get; set; }
    }

    public class Inventories : ResponseBase
    {
        public List<Inventory> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }
}
