using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class Uom
    {
        public int uomId { get; set; }
        public string symbol { get; set; }
        public string unitName { get; set; }
    }
    public class Uoms : ResponseBase
    {
        public List<Uom> result { get; set; }
    }
}
