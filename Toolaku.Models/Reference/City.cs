using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }

    public class Cities : ResponseBase
    {
        public List<City> Result { get; set; }
    }
}
