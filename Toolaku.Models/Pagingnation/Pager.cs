using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Pagingnation
{
    public class Pager
    {
        public int RowsPerPage { get; set; }
        public int PageNumber { get; set; }
        public string OrderScript { get; set; }
        public string ColumnFilterScript { get; set; }
    }


    public class PageInfo
    {
        public int RowCount { get; set; }
    }
}
