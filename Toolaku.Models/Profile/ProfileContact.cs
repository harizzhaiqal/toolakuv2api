using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Profile
{
    public class ProfileContact
    {
        public Int32 TenantId { get; set; }
        public string OfficialEmail { get; set; }
        public string OfficePhone { get; set; }
        public string OfficePhone2 { get; set; }
        public string OfficeFax { get; set; }
        public string PICName { get; set; }
        public string PICDesignation { get; set; }
        public string MobileNo { get; set; }
    }

    public class ProfileContacts : ResponseBase
    {
        public List<ProfileContact> Result { get; set; }
    }
}
