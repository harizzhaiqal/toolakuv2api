using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Public
{
    public class SearchItem
    {
        public int Id { get; set; }
        public string ItemImage { get; set; }
        public string ItemImageAlt { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public string ShortDescription { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
    }

    public class SearchItems : ResponseBase
    {
        public List<SearchItem> Result { get; set; }

        public PageInfo pageInfo { get; set; }
    }
}
