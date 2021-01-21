using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Service
{
    public class CoverageList
    {
        public int coverageId { get; set; }
        public string countryName { get; set; }
        public string stateName { get; set; }
        public string cityName { get; set; }
    }

    public class CoverageLists : ResponseBase
    {
        public List<CoverageList> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }
}
