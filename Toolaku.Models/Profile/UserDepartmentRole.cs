using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Profile
{
    public class UserDepartmentRoleList
    {
        public int Id { get; set; }
        public int UserRoleId { get; set; }
        public int DepartmentRoleId { get; set; }
        public string DepartmentRoleName { get; set; }
        public int IsDeleted { get; set; }
        public int IsEnable { get; set; }
    }

    public class UserDepartmentRoleListDT : ResponseBase
    {
        public List<UserDepartmentRoleList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class UserDepartmentRoleDetails
    {
        public int Id { get; set; }
        public int UserRoleId { get; set; }
        public int DepartmentRoleId { get; set; }
        public int IsEnable { get; set; }
    }

    public class InsertUserDepartmentRole
    {
        public int UserRoleId { get; set; }
        public int DepartmentRoleId { get; set; }
    }

    public class UpdateUserDepartmentRole
    {
        public int Id { get; set; }
        public int UserRoleId { get; set; }
        public int DepartmentRoleId { get; set; }
        public int IsEnable { get; set; }
    }
    /*
    public class ListIdToDelete
    {
        public int id { get; set; }
    }
    */

}
