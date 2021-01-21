using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class Month
    {
        public int MonthId { get; set; }
        public string MonthName { get; set; }
    }

    public class Months : ResponseBase
    {
        public List<Month> Result { get; set; }
    }
}
