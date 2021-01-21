using System.Collections.Generic;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Reference
{
    public class DepartmentRoleList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsDeleted { get; set; }
        public int IsEnable { get; set; }
    }

    public class DepartmentRoleListDT : ResponseBase
    {
        public List<DepartmentRoleList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class DepartmentRoleDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsEnable { get; set; }
    }

    public class InsertDepartmentRole
    {
        public string Name { get; set; }
    }

    public class UpdateDepartmentRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsEnable { get; set; }
    }

   
    public class RefListIdToDelete
    {
        public int id { get; set; }
    }
    
}
