using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Profile
{
    public class TenantBranchList
    {
        public int TenantBranchId { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string LocationTypeName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
    }

    public class TenantBranchLists : ResponseBase
    {
        public IList<TenantBranchList> Result { get; set; }
    }
}
