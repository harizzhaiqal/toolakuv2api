using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models;
using Toolaku.Models.DTO;
using Toolaku.Models.WF;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Business
{
    public class WFBusiness
    {
        //--------------GET Method--------------
        public static GroupProcessListDT GetGroupProcessList(Adapter ad, string searchKey, Pager pager = null)
        {
            var response = new GroupProcessListDT();
            try
            {
                var result = WFDAL.GetGroupProcessList(ad, searchKey, pager);
                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static ProcessListDT GetProcessByModuleList(Adapter ad, int moduleId, string searchKey, Pager pager = null)
        {
            var response = new ProcessListDT();
            try
            {
                var result = WFDAL.GetProcessByModuleList(ad, moduleId, searchKey, pager);
                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static ProcessListDT GetProcessByParentList(Adapter ad, int parentId, string searchKey, Pager pager = null)
        {
            var response = new ProcessListDT();
            try
            {
                var result = WFDAL.GetProcessByParentList(ad, parentId, searchKey, pager);
                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static ModuleStateListDT GetModuleStateList(Adapter ad, int moduleId, string searchKey, Pager pager = null)
        {
            var response = new ModuleStateListDT();
            try
            {
                var result = WFDAL.GetModuleStateList(ad, moduleId, searchKey, pager);
                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static ProcessStateListDT GetProcessStateList(Adapter ad, int processId, int statePoint, string searchKey, Pager pager = null)
        {
            var response = new ProcessStateListDT();
            try
            {
                var result = WFDAL.GetProcessStateList(ad, processId, statePoint, searchKey, pager);
                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static TenantGroupProcessListDT GetTenantGroupProcessList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new TenantGroupProcessListDT();
            try
            {
                var result = WFDAL.GetTenantGroupProcessList(ad, tenantId, searchKey, pager);
                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static ProcessDepartmentRoleListDT GetProcessDepartmentRoleList(Adapter ad, int processId, string searchKey, Pager pager = null)
        {
            var response = new ProcessDepartmentRoleListDT();
            try
            {
                var result = WFDAL.GetProcessDepartmentRoleList(ad, processId, searchKey, pager);
                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static PreProcessListDT GetPreProcessList(Adapter ad, int processId, int groupProcessId, string searchKey, Pager pager = null)
        {
            var response = new PreProcessListDT();
            try
            {
                var result = WFDAL.GetPreProcessList(ad, processId, groupProcessId, searchKey, pager);
                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static GroupProcessDetail GetGroupProcessDetails(Adapter ad, int id)
        {
            var response = new GroupProcessDetail();
            try
            {
                response = WFDAL.GetGroupProcessDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static ProcessDetails GetProcessDetails(Adapter ad, int id)
        {
            var response = new ProcessDetails();
            try
            {
                response = WFDAL.GetProcessDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static ModuleStateDetails GetModuleStateDetails(Adapter ad, int id)
        {
            var response = new ModuleStateDetails();
            try
            {
                response = WFDAL.GetModuleStateDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static ProcessStateDetails GetProcessStateDetails(Adapter ad, int id)
        {
            var response = new ProcessStateDetails();
            try
            {
                response = WFDAL.GetProcessStateDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static TenantGroupProcessDetails GetTenantGroupProcessDetails(Adapter ad, int id)
        {
            var response = new TenantGroupProcessDetails();
            try
            {
                response = WFDAL.GetTenantGroupProcessDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static ProcessDepartmentRoleDetails GetProcessDepartmentRoleDetails(Adapter ad, int id)
        {
            var response = new ProcessDepartmentRoleDetails();
            try
            {
                response = WFDAL.GetProcessDepartmentRoleDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static PreProcessDetails GetPreProcessDetails(Adapter ad, int id)
        {
            var response = new PreProcessDetails();
            try
            {
                response = WFDAL.GetPreProcessDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        //--------------POST Method--------------

        public static PostApiResponse InsertGroupProcess(Adapter ad, InsertGroupProcess request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = WFDAL.InsertGroupProcess(ad, request, creatorUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.InsertProcess(ad, request, creatorUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.InsertModuleState(ad, request, creatorUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.InsertProcessState(ad, request, creatorUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.InsertTenantGroupProcess(ad, request, creatorUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.InsertProcessDepartmentRole(ad, request, creatorUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.InsertPreProcess(ad, request, creatorUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                    response.Id = result.Id;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.UpdateGroupProcess(ad, request, updatorUserId);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.UpdateProcess(ad, request, updatorUserId);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.UpdateModuleState(ad, request, updatorUserId);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.UpdateProcessState(ad, request, updatorUserId);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.UpdateTenantGroupProcess(ad, request, updatorUserId);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.UpdateProcessDepartmentRole(ad, request, updatorUserId);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
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
                var result = WFDAL.UpdatePreProcess(ad, request, updatorUserId);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        //--------------DELETE Method--------------

        public static BasicApiResponse DeleteGroupProcess(Adapter ad, List<WFListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = WFDAL.DeleteGroupProcess(ad, inIds, deleteUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static BasicApiResponse DeleteProcess(Adapter ad, List<WFListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = WFDAL.DeleteProcess(ad, inIds, deleteUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static BasicApiResponse DeleteModuleState(Adapter ad, List<WFListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = WFDAL.DeleteModuleState(ad, inIds, deleteUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static BasicApiResponse DeleteProcessState(Adapter ad, List<WFListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = WFDAL.DeleteProcessState(ad, inIds, deleteUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static BasicApiResponse DeleteTenantGroupProcess(Adapter ad, List<WFListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = WFDAL.DeleteTenantGroupProcess(ad, inIds, deleteUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static BasicApiResponse DeleteProcessDepartmentRole(Adapter ad, List<WFListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = WFDAL.DeleteProcessDepartmentRole(ad, inIds, deleteUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static BasicApiResponse DeletePreProcess(Adapter ad, List<WFListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = WFDAL.DeletePreProcess(ad, inIds, deleteUserId);
                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = result.ResponseMessage;
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
