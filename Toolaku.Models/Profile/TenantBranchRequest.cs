using System;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Models.Profile
{
    public class TenantBranchRequest
    {
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public int LocationTypeId { get; set; }
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
}
