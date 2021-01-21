using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Public
{
    public class RecommendedItem
    {
        public int ProductId { get; set; }
        public string DefaultImage { get; set; }
        public string AdditionalImage { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public int TenantId { get; set; }
        public string TenantName { get; set; }
    }

    public class RecommendedItems : ResponseBase
    {
        public List<RecommendedItem> Result { get; set; }
    }
}
