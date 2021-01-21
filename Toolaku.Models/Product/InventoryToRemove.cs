using System;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Models.Product
{
    public class InventoryToRemove
    {
        public int inventoryId { get; set; }
    }
    public class InventoriesToRemove
    {
        public List<InventoryToRemove> removeIds { get; set; }
    }
}
