using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.PM;
using Toolaku.Models.Pagingnation;

namespace Toolaku.DataAccess
{
    public class PMDAL
    {
        //--------------GET Method--------------
        /*
        public static List<ProjectManagementRequest> GetPMProjeckByTenantList(Adapter ad, int tenantId, string searchKey)
        {
            var response = new List<ProjectManagementRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjeckListByTenant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                name = reader.GetString(1),
                                startDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
                                endDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
                        };

                            response.Add(result);
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
            return response;
        }
        */

        public static (List<ProjectManagementRequest>, PageInfo)  GetPMProjeckByTenantList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<ProjectManagementRequest>();
            var response2 = new PageInfo();


            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjeckListByTenant", ad.SQLConn, ad.SQLTran))
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
                        while (reader.Read())
                        {
                            var result = new ProjectManagementRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                name = reader.GetString(1),
                                startDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
                                endDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
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

        public static List<ProjectManagementStatusRequest> GetPMProjeckStatusList(Adapter ad, int projectId)
        {
            var response = new List<ProjectManagementStatusRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjectStatusList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = projectId, ParameterName = "@ProjectManagementId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementStatusRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                projectManagemenId = Convert.ToInt32(reader.GetValue(1)),
                                statusName = reader.GetString(2),
                                flagComplete = Convert.ToInt32(reader.GetValue(3)),
                                order = Convert.ToInt32(reader.GetValue(4)),
                            };

                            response.Add(result);
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
            return response;
        }

        public static List<ProjectTaskByStatusAndPeopleRequest> GetPMProjectTaskByStatusAndPeopleList(Adapter ad, int projectId, int statusId, int userId)
        {
            var response = new List<ProjectTaskByStatusAndPeopleRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjectTaskByStatusAndPeopleList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = projectId, ParameterName = "@ProjectManagementId" });
                    command.Parameters.Add(new SqlParameter() { Value = statusId, ParameterName = "@StatusId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectTaskByStatusAndPeopleRequest
                            {
                                rowNum = Convert.ToInt32(reader.GetValue(0)),
                                taskId = Convert.ToInt32(reader.GetValue(1)),
                                taskName = reader.GetString(2),
                                taskPeopleId = Convert.ToInt32(reader.GetValue(3)),
                                userId = Convert.ToInt32(reader.GetValue(4)),
                                statusId = Convert.ToInt32(reader.GetValue(5)),
                                level = Convert.ToInt32(reader.GetValue(6)),
                                order = Convert.ToInt32(reader.GetValue(7)),
                            };

                            response.Add(result);
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
            return response;
        }

        /*
        public static List<ProjectManagementRequest> GetPMProjeckByUserIdTaskList(Adapter ad, int userId, string searchKey)
        {
            var response = new List<ProjectManagementRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjeckListByUserIdTask", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                name = reader.GetString(1),
                                startDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(2)).ToString("dd MMM yyyy")),
                                endDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
                            };

                            response.Add(result);
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
            return response;
        }
        */


        public static (List<ProjectManagementRequest>, PageInfo)  GetPMProjeckByUserIdTaskList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new List<ProjectManagementRequest>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjeckListByUserIdTask", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
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
                        while (reader.Read())
                        {
                            var result = new ProjectManagementRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                name = reader.GetString(1),
                                startDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(2)).ToString("dd MMM yyyy")),
                                endDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
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


        public static List<ProjectManagementDocumentRequest> GetPMProjeckDocumentList(Adapter ad, int projectManagementId)
        {
            var response = new List<ProjectManagementDocumentRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjeckDocumentList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = projectManagementId, ParameterName = "@ProjectManagementId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementDocumentRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                attachmentURL = reader.GetString(1),
                                description = reader.GetString(2),
                            };

                            response.Add(result);
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
            return response;
        }

        public static List<ProjectManagementTaskDocumentRequest> GetPMProjeckTaskDocumentList(Adapter ad, int userId, int parentTaskId)
        {
            var response = new List<ProjectManagementTaskDocumentRequest>();

            try
            {
                var sp = "sp_PM_GetProjeckTaskDocumentListAll";
                if (userId != 0)
                {
                    sp = "sp_PM_GetProjeckDocumentTaskList";
                }

                using (SqlCommand command = new SqlCommand(sp, ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = parentTaskId, ParameterName = "@ProjectManagementTaskId" });
                    if (userId != 0)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    }


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementTaskDocumentRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                attachmentURL = reader.GetString(1),
                                description = reader.GetString(2),
                                flagShare = Convert.ToInt32(reader.GetValue(3)),
                                flagDelete = userId != 0 ? Convert.ToInt32(reader.GetValue(4)) : 0,                                
                                uploaderName = userId != 0 ? reader.GetString(5): "",
                                uploaderTenantName = userId != 0 ? reader.GetString(6): "",
                            };

                            response.Add(result);
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
            return response;
        }

        public static List<ProjectManagementTaskDocumentRequest> GetPMProjeckTaskDocumentListAll(Adapter ad, int parentTaskId)
        {
            var response = new List<ProjectManagementTaskDocumentRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjeckTaskDocumentListAll", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = parentTaskId, ParameterName = "@ProjectManagementTaskId" });
                    


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementTaskDocumentRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                attachmentURL = reader.GetString(1),
                                description = reader.GetString(2),
                                flagShare = Convert.ToInt32(reader.GetValue(3)),
                            };

                            response.Add(result);
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
            return response;
        }

        public static List<ProjectManagementTaskPeopleRequest> GetPMProjeckTaskPeopleList(Adapter ad, int taskId, string searchKey)
        {
            var response = new List<ProjectManagementTaskPeopleRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjectTaskPeopleList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = taskId, ParameterName = "@ProjectManagementTaskId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });
                    

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementTaskPeopleRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                userName = reader.GetString(1),
                                userEmail = (reader.GetValue(2) == DBNull.Value) ? "" : reader.GetString(2),
                                userTenant = (reader.GetValue(3) == DBNull.Value) ? "" : reader.GetString(3),
                                statusName = reader.GetString(4),
                            };

                            response.Add(result);
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
            return response;
        }

        public static List<ProjectManagementTenantRequest> GetPMTenantList(Adapter ad)
        {
            var response = new List<ProjectManagementTenantRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjectTenantList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementTenantRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                tenantName = reader.GetString(1),
                            };

                            response.Add(result);
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
            return response;
        }
        /*
        public static List<ProjectManagementUserRequest> GetPMUserListByTenant(Adapter ad, int tenantId, string searchKey, int taskId)
        {
            var response = new List<ProjectManagementUserRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetUserListByTenant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    if (tenantId != 0)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    }
                    
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });
                    command.Parameters.Add(new SqlParameter() { Value = taskId, ParameterName = "@TaskId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementUserRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                userName = reader.GetString(1),
                                userEmail = reader.GetString(2),
                            };

                            response.Add(result);
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
            return response;
        }
        */


        public static (List<ProjectManagementUserRequest>, PageInfo)   GetPMUserListByTenant(Adapter ad, int tenantId, string searchKey, int taskId, Pager pager = null)
        {
            var response = new List<ProjectManagementUserRequest>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetUserListByTenant", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    if (tenantId != 0)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    }

                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });
                    command.Parameters.Add(new SqlParameter() { Value = taskId, ParameterName = "@TaskId" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementUserRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                userName = reader.GetString(1),
                                userEmail = reader.GetString(2),
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

        public static ProjectManagementRequest GetPMProjectDetails(Adapter ad, int projectManagementId)
        {
            var response = new ProjectManagementRequest();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjectDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    //test commit

                    command.Parameters.Add(new SqlParameter() { Value = projectManagementId, ParameterName = "@ProjectManagementId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.id = Convert.ToInt32(reader.GetValue(0));
                            response.name = reader.GetString(1);
                            response.startDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(2)).ToString("dd MMM yyyy"));
                            response.endDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy"));
                            response.description = reader.GetString(4);
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
            return response;
        }


        public static ProjectManagementTaskRequest GetPMProjectTaskDetails(Adapter ad, int projectTaskId, int userId)
        {
            var response = new ProjectManagementTaskRequest();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjectTaskDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    
                    command.Parameters.Add(new SqlParameter() { Value = projectTaskId, ParameterName = "@ProjectManagementTaskId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.id = Convert.ToInt32(reader.GetValue(0));
                            response.projectManagementId = Convert.ToInt32(reader.GetValue(1));
                            response.taskName = reader.GetString(2);
                            response.userName = reader.GetString(3);
                            response.tenantName = reader.GetString(4);
                            response.parentId = (reader.GetValue(5) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(5));
                                //Convert.ToInt32(reader.GetValue(5));
                            response.order = Convert.ToInt32(reader.GetValue(6));
                            response.description = reader.GetString(7);
                            response.startDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(8)).ToString("dd MMM yyyy"));
                            response.endDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(9)).ToString("dd MMM yyyy"));
                            response.projectName = reader.GetString(10);
                            response.CreatorUserId = Convert.ToInt32(reader.GetValue(11));                            
                            response.flagCanEdit = (Convert.ToInt32(reader.GetValue(11)) == userId) ? 1 : 0;


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
            return response;
        }


        public static ProjectManagementTaskRequest GetPMTBProjectTaskDetails_byLogin(Adapter ad, int projectTaskPeopleId)
        {
            var response = new ProjectManagementTaskRequest();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjectTaskDetails_byLogin", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = projectTaskPeopleId, ParameterName = "@ProjectManagementTaskPeopleId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.id = Convert.ToInt32(reader.GetValue(0));
                            response.projectManagementId = Convert.ToInt32(reader.GetValue(1));
                            response.taskName = reader.GetString(2);
                            response.userName = reader.GetString(3);
                            response.tenantName = reader.GetString(4);
                            response.parentId = (reader.GetValue(5) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(5));
                            //Convert.ToInt32(reader.GetValue(5));
                            response.order = Convert.ToInt32(reader.GetValue(6));
                            response.description = reader.GetString(7);
                            response.startDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(8)).ToString("dd MMM yyyy"));
                            response.endDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(9)).ToString("dd MMM yyyy"));
                            response.projectName = reader.GetString(10);
                            response.statusName = reader.GetString(11);

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
            return response;
        }


        public static List<ProjectManagementTaskRequest> GetPMProjeckTask1stLayerList(Adapter ad, int projectManagementId)
        {
            var response = new List<ProjectManagementTaskRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjectMainTaskList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = projectManagementId, ParameterName = "@ProjectManagementId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementTaskRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                taskName = reader.GetString(1),
                                startDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(2)).ToString("dd MMM yyyy")),
                                endDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
                                description = reader.GetString(4),
                                userName = reader.GetString(5),
                                tenantName = reader.GetString(6),
                                order = Convert.ToInt32(reader.GetValue(7)),
                                totalSub = Convert.ToInt32(reader.GetValue(8)),
                            };

                            response.Add(result);
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
            return response;
        }

        public static List<ProjectManagementTaskRequest> GetPMTBProjeckTask1stLayerList(Adapter ad, int projectManagementTaskPeopleId, int userId)
        {
            var response = new List<ProjectManagementTaskRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_TB_GetProjectMainTaskList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = projectManagementTaskPeopleId, ParameterName = "@ProjectManagementTaskPeopleId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementTaskRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                taskName = reader.GetString(1),
                                startDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(2)).ToString("dd MMM yyyy")),
                                endDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
                                description = reader.GetString(4),
                                userName = reader.GetString(5),
                                tenantName = reader.GetString(6),
                                order = Convert.ToInt32(reader.GetValue(7)),
                                flagCanDelete = Convert.ToInt32(reader.GetValue(8)),
                                parentId = 0,
                                totalSub = Convert.ToInt32(reader.GetValue(9)),
                            };

                            response.Add(result);
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
            return response;
        }

        public static List<ProjectManagementTaskRequest> GetPMProjeckSubTaskList(Adapter ad, int parentTaskId)
        {
            var response = new List<ProjectManagementTaskRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_GetProjectSubTaskList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = parentTaskId, ParameterName = "@ProjectManagementTaskId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementTaskRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                taskName = reader.GetString(1),
                                startDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(2)).ToString("dd MMM yyyy")),
                                endDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
                                description = reader.GetString(4),
                                userName = reader.GetString(5),
                                tenantName = reader.GetString(6),
                                order = Convert.ToInt32(reader.GetValue(7)),
                                parentId = parentTaskId,
                                totalSub = Convert.ToInt32(reader.GetValue(8)),
                            };

                            response.Add(result);
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
            return response;
        }


        public static List<ProjectManagementTaskRequest> GetPMTBProjeckSubTaskList(Adapter ad, int parentTaskId, int userId)
        {
            var response = new List<ProjectManagementTaskRequest>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_TB_GetProjectSubTaskList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = parentTaskId, ParameterName = "@ProjectManagementTaskId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProjectManagementTaskRequest
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                taskName = reader.GetString(1),
                                startDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(2)).ToString("dd MMM yyyy")),
                                endDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(3)).ToString("dd MMM yyyy")),
                                description = reader.GetString(4),
                                userName = reader.GetString(5),
                                tenantName = reader.GetString(6),
                                order = Convert.ToInt32(reader.GetValue(7)),
                                flagCanDelete = Convert.ToInt32(reader.GetValue(8)),
                            };

                            response.Add(result);
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
            return response;
        }


        //--------------PUT Method--------------

        public static BasicApiResponse UpdateProject(Adapter ad, ProjectManagementUpsert request)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_UpdateProject", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.id, ParameterName = "@ProjectManagementId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.name, ParameterName = "@ProjectName" });
                    command.Parameters.Add(new SqlParameter() { Value = request.description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = request.startDate, ParameterName = "@StartDate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.endDate, ParameterName = "@EndDate" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse UpdateProjectTask(Adapter ad, ProjectManagementTaskUpsert request)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_UpdateProjectTask", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.id, ParameterName = "@ProjectManagementTaskId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.taskName, ParameterName = "@TaskName" });
                    command.Parameters.Add(new SqlParameter() { Value = request.description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = request.startDate, ParameterName = "@StartDate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.endDate, ParameterName = "@EndDate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.order, ParameterName = "@Order" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse UpdateProjectTaskPeopleStatus(Adapter ad, int peopleId, int statusId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_UpdateProjectTaskPeopleStatus", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = peopleId, ParameterName = "@TaskPeopleId" });
                    command.Parameters.Add(new SqlParameter() { Value = statusId, ParameterName = "@StatusId" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        //--------------POST Method--------------

        public static PostApiResponse InsertPMInsertProject(Adapter ad, int tenantId, int userId, ProjectManagementUpsert request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_InsertProject", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.name, ParameterName = "@ProjectName" });
                    command.Parameters.Add(new SqlParameter() { Value = request.description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = request.startDate, ParameterName = "@StartDate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.endDate, ParameterName = "@EndDate" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static PostApiResponse InsertPMInsertProjectTask(Adapter ad, int projectId, int parentTaskId, int userId, ProjectManagementTaskUpsert request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_InsertProjectTask", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = projectId, ParameterName = "@ProjectManagementId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.taskName, ParameterName = "@TaskName" });
                    command.Parameters.Add(new SqlParameter() { Value = request.description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = request.startDate, ParameterName = "@StartDate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.endDate, ParameterName = "@EndDate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.order, ParameterName = "@Order" });
                    if (parentTaskId != 0)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = parentTaskId, ParameterName = "@ParentId" });
                    }
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static PostApiResponse InsertPMInsertProjectDocument(Adapter ad, ProjectManagementDocumentUpsert request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_InsertProjectDocument", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.projectManagementId, ParameterName = "@ProjectManagementId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.attachmentURL, ParameterName = "@AttachmentURL" });
                    command.Parameters.Add(new SqlParameter() { Value = request.description, ParameterName = "@Description" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static PostApiResponse InsertPMInsertProjectTaskDocument(Adapter ad, int userId, ProjectManagementTaskDocumentUpsert request)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_InsertProjectTaskDocument", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.projectManagementTaskId, ParameterName = "@ProjectManagementTaskId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.attachmentURL, ParameterName = "@AttachmentURL" });
                    command.Parameters.Add(new SqlParameter() { Value = request.description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = request.flagShare, ParameterName = "@FlagShare" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static PostApiResponse InsertPMInsertProjectTaskPeople(Adapter ad, int projectManagementTaskId, int creatorUserId, int peopleUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_InsertProjectTaskPeople", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = projectManagementTaskId, ParameterName = "@ProjectManagementTaskId" });
                    command.Parameters.Add(new SqlParameter() { Value = peopleUserId, ParameterName = "@UserId" });
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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        //--------------DELETE Method--------------

        public static BasicApiResponse DeletePMProject(Adapter ad, string inIds)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_DeleteProject", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = inIds, ParameterName = "@ProjectManagementId" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse DeletePMProjectTask(Adapter ad, int projectManagementTaskId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_DeleteTask", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = projectManagementTaskId, ParameterName = "@TaskId" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse DeletePMProjectDocument(Adapter ad, string documentId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_DeleteProjectDocument", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = documentId, ParameterName = "@DocumentId" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse DeletePMProjectTaskDocument(Adapter ad, string documentId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_DeleteProjectTaskDocument", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = documentId, ParameterName = "@DocumentId" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse DeletePMProjectTaskPeople(Adapter ad, string peopleId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_PM_DeleteTaskPeople", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = peopleId, ParameterName = "@TaskPeopleId" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

    }
}
