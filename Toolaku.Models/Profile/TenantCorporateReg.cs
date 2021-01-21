using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Profile
{
    public class TenantCorporateReg
    {
        public int TenantAgencyId { get; set; }
        public string ImageURL { get; set; }
        public string OrgName { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTill { get; set; }
    }

    public class TenantCorporateRegs : ResponseBase
    {
        public List<TenantCorporateReg> Result { get; set; }
    }

    public class TenantAgencyDetail : ResponseBase
    {
        public int TenantAgencyId { get; set; }
        public int AgencyId { get; set; }
        public int TenantAgencyGradeId { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTill { get; set; }
    }
    public class TenantAgencyCode
    {
        public int TenantAgencyCodeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class TenantAgencyCodes : ResponseBase
    {
        public List<TenantAgencyCode> Result { get; set; }
    }

    public class CodeToRemove
    {
        public int TenantAgencyCodeId { get; set; }
    }
    
    public class CodeToRemoves
    {
        public List<CodeToRemove> removeIds { get; set; }
    }

}
