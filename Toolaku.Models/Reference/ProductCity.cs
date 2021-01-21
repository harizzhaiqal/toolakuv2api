using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class ProductCity
    {
        public int cityId { get; set; }
        public string cityName { get; set; }
    }
    public class ProductCities : ResponseBase
    {
        public List<ProductCity> result { get; set; }
    }
}
