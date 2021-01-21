
using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Service
{
    public class ServiceVariantToRemove
    {
        public int ServiceVariantId { get; set; }
    }

    public class ServiceVariantsToRemove
    {
        public List<ServiceVariantToRemove> ids { get; set; }
    }

}
