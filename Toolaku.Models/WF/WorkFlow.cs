using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.WF;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.WF
{
    public class GroupProcessList
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string GroupName { get; set; }
        public string ModuleName { get; set; }
        public int IsDeleted { get; set; }
        public int IsEnable { get; set; }
    }

    public class GroupProcessListDT : ResponseBase
    {
        public List<GroupProcessList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }


    public class ProcessList
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int GroupProcessId { get; set; }
        public string ParentProcessName { get; set; }
        public string ProcessName { get; set; }
        public string MenuName { get; set; }
        public string ModuleName { get; set; }
        public string GroupName { get; set; }
        public string MenuPath { get; set; }
        public int ProcessOrder { get; set; }
        public int ParentProcessOrder { get; set; }
        public double Order { get; set; }
        public int IsDeleted { get; set; }
        public int IsEnable { get; set; }
    }

    public class ProcessListDT : ResponseBase
    {
        public List<ProcessList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }


    public class ModuleStateList
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string StateName { get; set; }
        public string ModuleName { get; set; }
        public int IsDeleted { get; set; }
        public int IsEnable { get; set; }
    }

    public class ModuleStateListDT : ResponseBase
    {
        public List<ModuleStateList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }


    public class ProcessStateList
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int ModuleStateId { get; set; }
        public string ProcessName { get; set; }
        public string StateName { get; set; }
        public int FlagInsert { get; set; }
        public int FlagUpdate { get; set; }
        public int FlagDelete { get; set; }
        public int IsDeleted { get; set; }
        public int IsEnable { get; set; }
        public int StatePoint { get; set; }
    }

    public class ProcessStateListDT : ResponseBase
    {
        public List<ProcessStateList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }



    public class TenantGroupProcessList
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int GroupProcessId { get; set; }
        public string GroupName { get; set; }
        public int IsDeleted { get; set; }
        public int IsEnable { get; set; }
    }

    public class TenantGroupProcessListDT : ResponseBase
    {
        public List<TenantGroupProcessList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }


    public class ProcessDepartmentRoleList
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int DepartmentRoleId { get; set; }
        public string DepartmentRoleName { get; set; }
        public int IsDeleted { get; set; }
        public int IsEnable { get; set; }
    }

    public class ProcessDepartmentRoleListDT : ResponseBase
    {
        public List<ProcessDepartmentRoleList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }



    public class PreProcessList
    {
        public int Id { get; set; }
        public int PreProcessId { get; set; }
        public string ProcessName { get; set; }
        public int IsDeleted { get; set; }
        public int IsEnable { get; set; }
    }

    public class PreProcessListDT : ResponseBase
    {
        public List<PreProcessList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class GroupProcessDetail
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int IsEnable { get; set; }
    }

    public class ProcessDetails
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int GroupProcessId { get; set; }
        public string Name { get; set; }
        public string Menu { get; set; }
        public string MenuPath { get; set; }
        public int Order { get; set; }
        public int IsEnable { get; set; }
    }

    public class ModuleStateDetails
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int IsEnable { get; set; }
    }

    public class ProcessStateDetails
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int ModuleStateId { get; set; }
        public int FlagInsert { get; set; }
        public int FlagUpdate { get; set; }
        public int FlagDelete { get; set; }
        public int StatePoint { get; set; }
        public int IsEnable { get; set; }
    }

    public class TenantGroupProcessDetails
    {
        public int Id { get; set; }
        public int GroupProcessId { get; set; }
        public string Name { get; set; }
        public int IsEnable { get; set; }
    }

    public class ProcessDepartmentRoleDetails
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int DepartmentRoleId { get; set; }
        public int IsEnable { get; set; }
    }

    public class PreProcessDetails
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int PreProcessId { get; set; }
        public int IsEnable { get; set; }
    }


    public class InsertGroupProcess
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateGroupProcess
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int IsEnable { get; set; }
    }

    public class InsertProcess
    {
        public int ParentId { get; set; }
        public int GroupProcessId { get; set; }
        public string Name { get; set; }
        public string Menu { get; set; }
        public string MenuPath { get; set; }
        public int Order { get; set; }        
    }

    public class UpdateProcess
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int GroupProcessId { get; set; }
        public string Name { get; set; }
        public string Menu { get; set; }
        public string MenuPath { get; set; }
        public int Order { get; set; }
        public int IsEnable { get; set; }
    }

    

    public class InsertModuleState
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateModuleState
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int IsEnable { get; set; }
    }

    public class InsertProcessState
    {
        public int ProcessId { get; set; }
        public int ModuleStateId { get; set; }
        public int FlagInsert { get; set; }
        public int FlagUpdate { get; set; }
        public int FlagDelete { get; set; }
        public int StatePoint { get; set; }
    }

    public class UpdateProcessState
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int ModuleStateId { get; set; }
        public int FlagInsert { get; set; }
        public int FlagUpdate { get; set; }
        public int FlagDelete { get; set; }
        public int StatePoint { get; set; }
        public int IsEnable { get; set; }
    }

    public class InsertTenantGroupProcess
    {
        public int TenantId { get; set; }
        public int GroupProcessId { get; set; }
    }

    public class UpdateTenantGroupProcess
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int GroupProcessId { get; set; }
        public int IsEnable { get; set; }
    }

    public class InsertProcessDepartmentRole
    {
        public int ProcessId { get; set; }
        public int DepartmentRoleId { get; set; }
    }

    public class UpdateProcessDepartmentRole
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int DepartmentRoleId { get; set; }
        public int IsEnable { get; set; }
    }

    public class InsertPreProcess
    {
        public int ProcessId { get; set; }
        public int PreProcessId { get; set; }
    }
    public class UpdatePreProcess
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int PreProcessId { get; set; }
        public int IsEnable { get; set; }
    }

    
    public class WFListIdToDelete
    {
        public int id { get; set; }
    }
    

}