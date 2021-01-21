using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class ProductState
    {
        public int stateId { get; set; }
        public string stateCode { get; set; }
        public string stateName { get; set; }
    }

    public class ProductStates : ResponseBase
    {
        public List<ProductState> result { get; set; }
    }
}
