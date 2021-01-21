using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class ProductCountry
    {
        public int countryId { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
    }
    public class ProductCountries : ResponseBase
    {
        public List<ProductCountry> result { get; set; }
    }
}