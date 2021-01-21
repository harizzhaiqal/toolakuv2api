using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Service
{
    public class TenantServiceCategory : ResponseBase
    {
        public int level1CatId { get; set; }
        public int level2CatId { get; set; }
        public int level3CatId { get; set; }
    }

    public class TenantServiceCategoryUpdate
    {
        public int serviceId { get; set; }
        public int level1CatId { get; set; }
        public int level2CatId { get; set; }
        public int level3CatId { get; set; }
    }
}
