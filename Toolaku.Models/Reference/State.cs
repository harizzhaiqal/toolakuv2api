using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class State
    {
        public int StateId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }

    public class States : ResponseBase
    {
        public List<State> Result { get; set; }
    }
}
