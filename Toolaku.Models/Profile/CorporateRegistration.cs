namespace Toolaku.Models.Profile
{
    public class CorporateRegistration
    {
        public int AgencyId { get; set; }
        public int AgencyGradeId { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTill { get; set; }

    }

    public class AgencyCode
    {
        public int AgencyCodeId { get; set; }
    }

    public class AgencyCodeInsert
    {
        public int TenantAgencyId { get; set; }
        public int ParentCodeId { get; set; }
        public int ChildCodeId { get; set; }
        public int CodeId { get; set; }
    }

    public class CorporateRegistrationUpdate
    {
        public int TenantAgencyId { get; set; }
        public int AgencyGradeId { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTill { get; set; }
    }
}
