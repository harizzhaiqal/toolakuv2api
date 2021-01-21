using System;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Models.Service
{
    public class CoverageDetailInsert
    {
        public int serviceId { get; set; }
        public int countryId { get; set; }
        public int stateId { get; set; }
        public int cityId { get; set; }
        public string city { get; set; }

    }
    

}
