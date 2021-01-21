using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }

    public class Countries : ResponseBase
    {
        public List<Country> Result {get;set;}
    }
}
