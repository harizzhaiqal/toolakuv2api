using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Profile
{
    public class TenantRole
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool ActiveStatus { get; set; }
        public List<TenantModule> moduleIds { get; set; }
    }


    public class TenantRoleList
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool ActiveStatus { get; set; }
    }

    public class TenantRoleLists : ResponseBase
    {
        public List<TenantRoleList> roleList { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class TenantModule
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
    }

    public class TenantModules : ResponseBase
    {
        public List<TenantModule> Result { get; set; }
    }

    public class TenantRoleReference
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class TenantRoleReferences : ResponseBase
    {
        public List<TenantRoleReference> Result { get; set; }
    }

    public class TenantRoleNew
    {
        public string Name { get; set; }
        public bool ActiveStatus { get; set; }
        public List<TenantModuleNew> moduleIds { get; set; }
    }
    public class TenantModuleNew
    {
        public int ModuleId { get; set; }
    }

    public class RoleToRemove
    {
        public int RoleId { get; set; }
    }
}
