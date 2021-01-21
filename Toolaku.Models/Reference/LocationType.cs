using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class LocationType
    {
        public int locationTypeId { get; set; }
        public string locationCode { get; set; }
        public string locationTypeName { get; set; }
    }

    public class LocationTypes : ResponseBase
    {
        public List<LocationType> result { get; set; }
    }
}
