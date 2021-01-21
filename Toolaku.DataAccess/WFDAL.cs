using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.WF;
using Toolaku.Models.Pagingnation;

namespace Toolaku.DataAccess
{
    public class WFDAL
    {
        //--------------GET Method--------------

        public static (List<GroupProcessList>, PageInfo) GetGroupProcessList(Adapter ad, string searchKey, Pager pager = null)
        {
            var response = new List<GroupProcessList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetGroupProcessList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ModuleId = reader.GetOrdinal("ModuleId");
                        int GroupName = reader.GetOrdinal("GroupName");
                        int ModuleName = reader.GetOrdinal("ModuleName");
                        int IsDeleted = reader.GetOrdinal("IsDeleted");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            var result = new GroupProcessList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                ModuleId = Convert.ToInt32(reader.GetValue(ModuleId)),
                                GroupName = (reader.GetValue(GroupName) == DBNull.Value) ? "" : reader.GetString(GroupName),
                                ModuleName = (reader.GetValue(ModuleName) == DBNull.Value) ? "" : reader.GetString(ModuleName),
                                IsDeleted = Convert.ToInt32(reader.GetValue(IsDeleted)),
                                IsEnable = Convert.ToInt32(reader.GetValue(IsEnable)),
                            };
                            response.Add(result);
                        }

                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }



        public static (List<ProcessList>, PageInfo) GetProcessByModuleList(Adapter ad, int moduleId, string searchKey, Pager pager = null)
        {
            var response = new List<ProcessList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetProcessByModuleList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = moduleId, ParameterName = "@ModuleId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ParentId = reader.GetOrdinal("ParentId");
                        int GroupProcessId = reader.GetOrdinal("GroupProcessId");
                        int ParentProcessName = reader.GetOrdinal("ParentProcessName");
                        int ProcessName = reader.GetOrdinal("ProcessName");
                        int MenuName = reader.GetOrdinal("MenuName");
                        int ModuleName = reader.GetOrdinal("ModuleName");
                        int GroupName = reader.GetOrdinal("GroupName");
                        int MenuPath = reader.GetOrdinal("MenuPath");
                        int ProcessOrder = reader.GetOrdinal("ProcessOrder");
                        int ParentProcessOrder = reader.GetOrdinal("ParentProcessOrder");
                        int Order = reader.GetOrdinal("Order");
                        int IsDeleted = reader.GetOrdinal("IsDeleted");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            var result = new ProcessList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                ParentId = (reader.GetValue(ParentId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ParentId)),
                                GroupProcessId = (reader.GetValue(GroupProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(GroupProcessId)),
                                ParentProcessName = (reader.GetValue(ParentProcessName) == DBNull.Value) ? "" : reader.GetString(ParentProcessName),
                                ProcessName = (reader.GetValue(ProcessName) == DBNull.Value) ? "" : reader.GetString(ProcessName),
                                MenuName = (reader.GetValue(MenuName) == DBNull.Value) ? "" : reader.GetString(MenuName),
                                ModuleName = (reader.GetValue(ModuleName) == DBNull.Value) ? "" : reader.GetString(ModuleName),
                                GroupName = (reader.GetValue(GroupName) == DBNull.Value) ? "" : reader.GetString(GroupName),
                                MenuPath = (reader.GetValue(MenuPath) == DBNull.Value) ? "" : reader.GetString(MenuPath),
                                ProcessOrder = (reader.GetValue(ProcessOrder) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ProcessOrder)),
                                ParentProcessOrder = (reader.GetValue(ParentProcessOrder) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ParentProcessOrder)),
                                Order = (reader.GetValue(Order) == DBNull.Value) ? 0 : Convert.ToDouble(reader.GetValue(Order)),
                                IsDeleted = Convert.ToInt32(reader.GetValue(IsDeleted)),
                                IsEnable = Convert.ToInt32(reader.GetValue(IsEnable)),
                            };
                            response.Add(result);
                        }

                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }




        public static (List<ProcessList>, PageInfo) GetProcessByParentList(Adapter ad, int parentId, string searchKey, Pager pager = null)
        {
            var response = new List<ProcessList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetProcessByParentList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = parentId, ParameterName = "@ParentId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ParentId = reader.GetOrdinal("ParentId");
                        int GroupProcessId = reader.GetOrdinal("GroupProcessId");
                        int ParentProcessName = reader.GetOrdinal("ParentProcessName");
                        int ProcessName = reader.GetOrdinal("ProcessName");
                        int MenuName = reader.GetOrdinal("MenuName");
                        int ModuleName = reader.GetOrdinal("ModuleName");
                        int GroupName = reader.GetOrdinal("GroupName");
                        int MenuPath = reader.GetOrdinal("MenuPath");
                        int ProcessOrder = reader.GetOrdinal("ProcessOrder");
                        int ParentProcessOrder = reader.GetOrdinal("ParentProcessOrder");
                        int Order = reader.GetOrdinal("Order");
                        int IsDeleted = reader.GetOrdinal("IsDeleted");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            var result = new ProcessList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                ParentId = (reader.GetValue(ParentId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ParentId)),
                                GroupProcessId = (reader.GetValue(GroupProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(GroupProcessId)),
                                ParentProcessName = (reader.GetValue(ParentProcessName) == DBNull.Value) ? "" : reader.GetString(ParentProcessName),
                                ProcessName = (reader.GetValue(ProcessName) == DBNull.Value) ? "" : reader.GetString(ProcessName),
                                MenuName = (reader.GetValue(MenuName) == DBNull.Value) ? "" : reader.GetString(MenuName),
                                ModuleName = (reader.GetValue(ModuleName) == DBNull.Value) ? "" : reader.GetString(ModuleName),
                                GroupName = (reader.GetValue(GroupName) == DBNull.Value) ? "" : reader.GetString(GroupName),
                                MenuPath = (reader.GetValue(MenuPath) == DBNull.Value) ? "" : reader.GetString(MenuPath),
                                ProcessOrder = (reader.GetValue(ProcessOrder) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ProcessOrder)),
                                ParentProcessOrder = (reader.GetValue(ParentProcessOrder) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ParentProcessOrder)),
                                Order = (reader.GetValue(Order) == DBNull.Value) ? 0 : Convert.ToDouble(reader.GetValue(Order)),
                                IsDeleted = Convert.ToInt32(reader.GetValue(IsDeleted)),
                                IsEnable = Convert.ToInt32(reader.GetValue(IsEnable)),
                            };
                            response.Add(result);
                        }

                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }


        public static (List<ModuleStateList>, PageInfo) GetModuleStateList(Adapter ad, int moduleId, string searchKey, Pager pager = null)
        {
            var response = new List<ModuleStateList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetModuleStateList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = moduleId, ParameterName = "@ModuleId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ModuleId = reader.GetOrdinal("ModuleId");
                        int StateName = reader.GetOrdinal("StateName");
                        int ModuleName = reader.GetOrdinal("ModuleName");
                        int IsDeleted = reader.GetOrdinal("IsDeleted");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            var result = new ModuleStateList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                ModuleId = (reader.GetValue(ModuleId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ModuleId)),
                                StateName = (reader.GetValue(StateName) == DBNull.Value) ? "" : reader.GetString(StateName),
                                ModuleName = (reader.GetValue(ModuleName) == DBNull.Value) ? "" : reader.GetString(ModuleName),
                                IsDeleted = Convert.ToInt32(reader.GetValue(IsDeleted)),
                                IsEnable = Convert.ToInt32(reader.GetValue(IsEnable)),
                            };
                            response.Add(result);
                        }

                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }



        public static (List<ProcessStateList>, PageInfo) GetProcessStateList(Adapter ad, int processId, int statePoint, string searchKey, Pager pager = null)
        {
            var response = new List<ProcessStateList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetProcessStateList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = processId, ParameterName = "@ProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = statePoint, ParameterName = "@StatePoint" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ProcessId = reader.GetOrdinal("ProcessId");
                        int ModuleStateId = reader.GetOrdinal("ModuleStateId");
                        int ProcessName = reader.GetOrdinal("ProcessName");
                        int StateName = reader.GetOrdinal("StateName");
                        int FlagInsert = reader.GetOrdinal("FlagInsert");
                        int FlagUpdate = reader.GetOrdinal("FlagUpdate");
                        int FlagDelete = reader.GetOrdinal("FlagDelete");
                        int StatePoint = reader.GetOrdinal("StatePoint");
                        int IsDeleted = reader.GetOrdinal("IsDeleted");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            var result = new ProcessStateList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                ProcessId = (reader.GetValue(ProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ProcessId)),
                                ModuleStateId = (reader.GetValue(ModuleStateId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ModuleStateId)),
                                ProcessName = (reader.GetValue(ProcessName) == DBNull.Value) ? "" : reader.GetString(ProcessName),
                                StateName = (reader.GetValue(StateName) == DBNull.Value) ? "" : reader.GetString(StateName),
                                FlagInsert = Convert.ToInt32(reader.GetValue(FlagInsert)),
                                FlagUpdate = Convert.ToInt32(reader.GetValue(FlagUpdate)),
                                FlagDelete = Convert.ToInt32(reader.GetValue(FlagDelete)),
                                IsDeleted = Convert.ToInt32(reader.GetValue(IsDeleted)),
                                IsEnable = Convert.ToInt32(reader.GetValue(IsEnable)),
                                StatePoint = Convert.ToInt32(reader.GetValue(StatePoint)),
                            };
                            response.Add(result);
                        }

                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }



        public static (List<TenantGroupProcessList>, PageInfo) GetTenantGroupProcessList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantGroupProcessList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetTenantGroupProcessList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int TenantId = reader.GetOrdinal("TenantId");
                        int GroupProcessId = reader.GetOrdinal("GroupProcessId");
                        int GroupName = reader.GetOrdinal("GroupName");
                        int IsDeleted = reader.GetOrdinal("IsDeleted");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            var result = new TenantGroupProcessList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                TenantId = (reader.GetValue(TenantId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(TenantId)),
                                GroupProcessId = (reader.GetValue(GroupProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(GroupProcessId)),
                                GroupName = (reader.GetValue(GroupName) == DBNull.Value) ? "" : reader.GetString(GroupName),
                                IsDeleted = Convert.ToInt32(reader.GetValue(IsDeleted)),
                                IsEnable = Convert.ToInt32(reader.GetValue(IsEnable)),
                            };
                            response.Add(result);
                        }

                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }


        public static (List<ProcessDepartmentRoleList>, PageInfo) GetProcessDepartmentRoleList(Adapter ad, int processId, string searchKey, Pager pager = null)
        {
            var response = new List<ProcessDepartmentRoleList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetProcessDepartmentRoleList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = processId, ParameterName = "@ProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ProcessId = reader.GetOrdinal("ProcessId");
                        int DepartmentRoleId = reader.GetOrdinal("DepartmentRoleId");
                        int DepartmentRoleName = reader.GetOrdinal("DepartmentRoleName");
                        int IsDeleted = reader.GetOrdinal("IsDeleted");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            var result = new ProcessDepartmentRoleList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                ProcessId = (reader.GetValue(ProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ProcessId)),
                                DepartmentRoleId = (reader.GetValue(DepartmentRoleId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(DepartmentRoleId)),
                                DepartmentRoleName = (reader.GetValue(DepartmentRoleName) == DBNull.Value) ? "" : reader.GetString(DepartmentRoleName),
                                IsDeleted = Convert.ToInt32(reader.GetValue(IsDeleted)),
                                IsEnable = Convert.ToInt32(reader.GetValue(IsEnable)),
                            };
                            response.Add(result);
                        }

                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }



        public static (List<PreProcessList>, PageInfo) GetPreProcessList(Adapter ad, int processId, int groupProcessId, string searchKey, Pager pager = null)
        {
            var response = new List<PreProcessList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetPreProcessList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = processId, ParameterName = "@ProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = groupProcessId, ParameterName = "@GroupProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int PreProcessId = reader.GetOrdinal("PreProcessId");
                        int ProcessName = reader.GetOrdinal("ProcessName");
                        int IsDeleted = reader.GetOrdinal("IsDeleted");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            var result = new PreProcessList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                PreProcessId = (reader.GetValue(PreProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(PreProcessId)),
                                ProcessName = (reader.GetValue(ProcessName) == DBNull.Value) ? "" : reader.GetString(ProcessName),
                                IsDeleted = Convert.ToInt32(reader.GetValue(IsDeleted)),
                                IsEnable = Convert.ToInt32(reader.GetValue(IsEnable)),
                            };
                            response.Add(result);
                        }

                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }




        public static GroupProcessDetail GetGroupProcessDetails(Adapter ad, int id)
        {
            var response = new GroupProcessDetail();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetGroupProcessDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ModuleId = reader.GetOrdinal("ModuleId");
                        int Name = reader.GetOrdinal("Name");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.ModuleId = Convert.ToInt32(reader.GetValue(ModuleId));
                            response.Name = (reader.GetValue(Name) == DBNull.Value) ? "" : reader.GetString(Name);
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
               throw ex;
            }
            return response;
        }



        public static ProcessDetails GetProcessDetails(Adapter ad, int id)
        {
            var response = new ProcessDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetProcessDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ParentId = reader.GetOrdinal("ParentId");
                        int GroupProcessId = reader.GetOrdinal("GroupProcessId");
                        int Name = reader.GetOrdinal("Name");
                        int Menu = reader.GetOrdinal("Menu");
                        int MenuPath = reader.GetOrdinal("MenuPath");
                        int Order = reader.GetOrdinal("Order");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.ParentId = (reader.GetValue(ParentId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ParentId));
                            response.GroupProcessId = (reader.GetValue(GroupProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(GroupProcessId));
                            response.Name = (reader.GetValue(Name) == DBNull.Value) ? "" : reader.GetString(Name);
                            response.Menu = (reader.GetValue(Menu) == DBNull.Value) ? "" : reader.GetString(Menu);
                            response.MenuPath = (reader.GetValue(MenuPath) == DBNull.Value) ? "" : reader.GetString(MenuPath);
                            response.Order = (reader.GetValue(Order) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(Order));
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return response;
        }

        public static ModuleStateDetails GetModuleStateDetails(Adapter ad, int id)
        {
            var response = new ModuleStateDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetModuleStateDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ModuleId = reader.GetOrdinal("ModuleId");
                        int Name = reader.GetOrdinal("Name");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.ModuleId = (reader.GetValue(ModuleId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ModuleId));
                            response.Name = (reader.GetValue(Name) == DBNull.Value) ? "" : reader.GetString(Name);
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return response;
        }


        public static ProcessStateDetails GetProcessStateDetails(Adapter ad, int id)
        {
            var response = new ProcessStateDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetProcessStateDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ProcessId = reader.GetOrdinal("ProcessId");
                        int ModuleStateId = reader.GetOrdinal("ModuleStateId");
                        int FlagInsert = reader.GetOrdinal("FlagInsert");
                        int FlagUpdate = reader.GetOrdinal("FlagUpdate");
                        int FlagDelete = reader.GetOrdinal("FlagDelete");
                        int StatePoint = reader.GetOrdinal("StatePoint");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.ProcessId = (reader.GetValue(ProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ProcessId));
                            response.ModuleStateId = (reader.GetValue(ModuleStateId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ModuleStateId));
                            response.FlagInsert = (reader.GetValue(FlagInsert) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(FlagInsert));
                            response.FlagUpdate = (reader.GetValue(FlagUpdate) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(FlagUpdate));
                            response.FlagDelete = (reader.GetValue(FlagDelete) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(FlagDelete));
                            response.StatePoint = (reader.GetValue(StatePoint) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(StatePoint));
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return response;
        }



        public static TenantGroupProcessDetails GetTenantGroupProcessDetails(Adapter ad, int id)
        {
            var response = new TenantGroupProcessDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetTenantGroupProcessDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int GroupProcessId = reader.GetOrdinal("GroupProcessId");
                        int Name = reader.GetOrdinal("Name");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.GroupProcessId = (reader.GetValue(GroupProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(GroupProcessId));
                            response.Name = (reader.GetValue(Name) == DBNull.Value) ? "" : reader.GetString(Name);
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return response;
        }


        public static ProcessDepartmentRoleDetails GetProcessDepartmentRoleDetails(Adapter ad, int id)
        {
            var response = new ProcessDepartmentRoleDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetProcessDepartmentRoleDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ProcessId = reader.GetOrdinal("ProcessId");
                        int DepartmentRoleId = reader.GetOrdinal("DepartmentRoleId");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.ProcessId = (reader.GetValue(ProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ProcessId));
                            response.DepartmentRoleId = (reader.GetValue(DepartmentRoleId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(DepartmentRoleId));
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return response;
        }


        public static PreProcessDetails GetPreProcessDetails(Adapter ad, int id)
        {
            var response = new PreProcessDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_GetPreProcessDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int ProcessId = reader.GetOrdinal("ProcessId");
                        int PreProcessId = reader.GetOrdinal("PreProcessId");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.ProcessId = (reader.GetValue(ProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(ProcessId));
                            response.PreProcessId = (reader.GetValue(PreProcessId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(PreProcessId));
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return response;
        }


        //--------------POST Method--------------

        public static PostApiResponse InsertGroupProcess(Adapter ad, InsertGroupProcess request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_InsertGroupProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ModuleId, ParameterName = "@ModuleId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static PostApiResponse InsertProcess(Adapter ad, InsertProcess request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_InsertProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ParentId, ParameterName = "@ParentId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.GroupProcessId, ParameterName = "@GroupProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Menu, ParameterName = "@Menu" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MenuPath, ParameterName = "@MenuPath" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Order, ParameterName = "@Order" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static PostApiResponse InsertModuleState(Adapter ad, InsertModuleState request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_InsertModuleState", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ModuleId, ParameterName = "@ModuleId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static PostApiResponse InsertProcessState(Adapter ad, InsertProcessState request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_InsertProcessState", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ProcessId, ParameterName = "@ProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ModuleStateId, ParameterName = "@ModuleStateId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.FlagInsert, ParameterName = "@FlagInsert" });
                    command.Parameters.Add(new SqlParameter() { Value = request.FlagUpdate, ParameterName = "@FlagUpdate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.FlagDelete, ParameterName = "@FlagDelete" });
                    command.Parameters.Add(new SqlParameter() { Value = request.StatePoint, ParameterName = "@StatePoint" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }



        public static PostApiResponse InsertTenantGroupProcess(Adapter ad, InsertTenantGroupProcess request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_InsertTenantGroupProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                                    
                    command.Parameters.Add(new SqlParameter() { Value = request.TenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.GroupProcessId, ParameterName = "@GroupProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static PostApiResponse InsertProcessDepartmentRole(Adapter ad, InsertProcessDepartmentRole request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_InsertProcessDepartmentRole", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ProcessId, ParameterName = "@ProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.DepartmentRoleId, ParameterName = "@DepartmentRoleId" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static PostApiResponse InsertPreProcess(Adapter ad, InsertPreProcess request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_InsertPreProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ProcessId, ParameterName = "@ProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.PreProcessId, ParameterName = "@PreProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        //--------------PUT Method--------------

        public static BasicApiResponse UpdateGroupProcess(Adapter ad, UpdateGroupProcess request, int updatorUserId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_UpdateGroupProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ModuleId, ParameterName = "@ModuleId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = updatorUserId, ParameterName = "@UpdatorUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.IsEnable, ParameterName = "@IsEnable" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static BasicApiResponse UpdateProcess(Adapter ad, UpdateProcess request, int updatorUserId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_UpdateProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ParentId, ParameterName = "@ParentId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.GroupProcessId, ParameterName = "@GroupProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Menu, ParameterName = "@Menu" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MenuPath, ParameterName = "@MenuPath" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Order, ParameterName = "@Order" });
                    command.Parameters.Add(new SqlParameter() { Value = updatorUserId, ParameterName = "@UpdatorUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.IsEnable, ParameterName = "@IsEnable" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static BasicApiResponse UpdateModuleState(Adapter ad, UpdateModuleState request, int updatorUserId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_UpdateModuleState", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ModuleId, ParameterName = "@ModuleId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = updatorUserId, ParameterName = "@UpdatorUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.IsEnable, ParameterName = "@IsEnable" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }



        public static BasicApiResponse UpdateProcessState(Adapter ad, UpdateProcessState request, int updatorUserId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_UpdateProcessState", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ProcessId, ParameterName = "@ProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ModuleStateId, ParameterName = "@ModuleStateId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.FlagInsert, ParameterName = "@FlagInsert" });
                    command.Parameters.Add(new SqlParameter() { Value = request.FlagUpdate, ParameterName = "@FlagUpdate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.FlagDelete, ParameterName = "@FlagDelete" });
                    command.Parameters.Add(new SqlParameter() { Value = request.StatePoint, ParameterName = "@StatePoint" });
                    command.Parameters.Add(new SqlParameter() { Value = updatorUserId, ParameterName = "@UpdatorUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.IsEnable, ParameterName = "@IsEnable" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }



        public static BasicApiResponse UpdateTenantGroupProcess(Adapter ad, UpdateTenantGroupProcess request, int updatorUserId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_UpdateTenantGroupProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.GroupProcessId, ParameterName = "@GroupProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = updatorUserId, ParameterName = "@UpdatorUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.IsEnable, ParameterName = "@IsEnable" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static BasicApiResponse UpdateProcessDepartmentRole(Adapter ad, UpdateProcessDepartmentRole request, int updatorUserId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_UpdateProcessDepartmentRole", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ProcessId, ParameterName = "@ProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.DepartmentRoleId, ParameterName = "@DepartmentRoleId" });
                    command.Parameters.Add(new SqlParameter() { Value = updatorUserId, ParameterName = "@UpdatorUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.IsEnable, ParameterName = "@IsEnable" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }



        public static BasicApiResponse UpdatePreProcess(Adapter ad, UpdatePreProcess request, int updatorUserId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_UpdatePreProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ProcessId, ParameterName = "@ProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.PreProcessId, ParameterName = "@PreProcessId" });
                    command.Parameters.Add(new SqlParameter() { Value = updatorUserId, ParameterName = "@UpdatorUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.IsEnable, ParameterName = "@IsEnable" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }
        //--------------DELETE Method--------------


        public static BasicApiResponse DeleteGroupProcess(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_DeleteGroupProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ids, ParameterName = "@Ids" });
                    command.Parameters.Add(new SqlParameter() { Value = deleteUserId, ParameterName = "@DeleteUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static BasicApiResponse DeleteProcess(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_DeleteProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ids, ParameterName = "@Ids" });
                    command.Parameters.Add(new SqlParameter() { Value = deleteUserId, ParameterName = "@DeleteUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }



        public static BasicApiResponse DeleteModuleState(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_DeleteModuleState", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ids, ParameterName = "@Ids" });
                    command.Parameters.Add(new SqlParameter() { Value = deleteUserId, ParameterName = "@DeleteUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static BasicApiResponse DeleteProcessState(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_DeleteProcessState", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ids, ParameterName = "@Ids" });
                    command.Parameters.Add(new SqlParameter() { Value = deleteUserId, ParameterName = "@DeleteUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static BasicApiResponse DeleteTenantGroupProcess(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_DeleteTenantGroupProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ids, ParameterName = "@Ids" });
                    command.Parameters.Add(new SqlParameter() { Value = deleteUserId, ParameterName = "@DeleteUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static BasicApiResponse DeleteProcessDepartmentRole(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_DeleteProcessDepartmentRole", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ids, ParameterName = "@Ids" });
                    command.Parameters.Add(new SqlParameter() { Value = deleteUserId, ParameterName = "@DeleteUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static BasicApiResponse DeletePreProcess(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_WF_DeletePreProcess", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ids, ParameterName = "@Ids" });
                    command.Parameters.Add(new SqlParameter() { Value = deleteUserId, ParameterName = "@DeleteUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


    }

}
