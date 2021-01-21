using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Profile
{
    public class TenantAward : ResponseBase
    {
        public int TenantAwardId { get; set; }
        public string LogoURL { get; set; }
        public string AwardName { get; set; }
        public string Description { get; set; }
        public string AwardedBy { get; set; }
        public string DateAwarded { get; set; }
    }

    public class TenantAwardNew
    {
        public string LogoURL { get; set; }
        public string AwardName { get; set; }
        public string Description { get; set; }
        public string AwardedBy { get; set; }
        public string DateAwarded { get; set; }
    }

    public class TenantAwards : ResponseBase
    {
        public List<TenantAward> Result { get; set; }
    }

    public class TenantAwardUpdate
    {
        public int TenantAwardId { get; set; }
        public string LogoURL { get; set; }
        public string AwardName { get; set; }
        public string Description { get; set; }
        public string AwardedBy { get; set; }
        public string DateAwarded { get; set; }
    }
}
