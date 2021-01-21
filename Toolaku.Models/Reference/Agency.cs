using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{

    public class Agency
    {
        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public string AgencyLogo { get; set; }
        public string AgencyCode { get; set; }
        public string AgencyDecription { get; set; }
        public int AgencyTypeId { get; set; }
    }
    public class Agencies : ResponseBase
    {
        public List<Agency> result { get; set; }
    }
    public class AgencyGrade
    {
        public int AgencyGradeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }      
        public int AgencyId { get; set; }
    }
    public class AgencyGrades : ResponseBase
    {
        public List<AgencyGrade> result { get; set; }
    }
    public class AgencyCodeParent
    {
        public int AgencyCodeId { get; set; }
        public string CodeName { get; set; }
    }

    public class AgencyCodeParents : ResponseBase
    {
        public List<AgencyCodeParent> result { get; set; }
    }
    public class AgencyCode
    {
        public int AgencyCodeId { get; set; }
        public string CodeName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public int AgencyId { get; set; }
    }

    public class AgencyCodes : ResponseBase
    {
        public List<AgencyCode> result { get; set; }
    }
}
