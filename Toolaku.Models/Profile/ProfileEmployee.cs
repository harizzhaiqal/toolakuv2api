using System.Collections.Generic;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Profile
{
    public class ProfileEmployee
    {
        public int TenantEmployeeId { get; set; }
        public string DepartmentName { get; set; }
        public int NoPermanentStaff { get; set; }
        public int NoContractStaff { get; set; }
    }

    public class ProfileEmployeeNew
    {
        public string DepartmentName { get; set; }
        public int NoPermanentStaff { get; set; }
        public int NoContractStaff { get; set; }
    }

    public class ProfileEmployees : ResponseBase
    {
        public IList<ProfileEmployee> Result { get; set; }

        public PageInfo pageInfo { get; set; }
    }
}
