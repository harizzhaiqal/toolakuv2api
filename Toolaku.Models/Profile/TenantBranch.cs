using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Profile
{
    public class TenantBranch
    {
        public int TenantBranchId { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string LocationTypeId { get; set; }
        public int CountryId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Poscode { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string City { get; set; }
    }

    public class TenantBranches : ResponseBase
    {
        public List<TenantBranch> Result { get; set; }
    }
}
