using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class TelcoSupplier
    {
        public int TelcoId { get; set; }
        public string TelcoName { get; set; }
    }

    public class TelcoSuppliers : ResponseBase
    {
        public List<TelcoSupplier> Result { get; set; }
    }
}
