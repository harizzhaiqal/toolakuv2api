using System;
using System.Collections.Generic;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.Profile;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Business
{
    public class ProfileBusiness
    {
        //--------------GET Method--------------
        public static GeneralInfoResponse GetProfileGeneralInfo(Adapter ad, string userId)
        {
            var response = new GeneralInfoResponse();

            try
            {
                response = ProfileDAL.GetProfileGeneralInfo(ad, userId);

                if (response.BRNo != null)
                {
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantEditionInfoResponse GetTenantEditionInfo(Adapter ad, int tenantId)
        {
            var response = new TenantEditionInfoResponse();

            try
            {
                response = ProfileDAL.GetTenantEditionInfo(ad, tenantId);               
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ProfileContacts GetProfileContact(Adapter ad, string userId)
        {
            var response = new ProfileContacts();

            try
            {
                var result = ProfileDAL.GetProfileContact(ad, userId);

                if (result.Count != 0)
                {
                    response.Result = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Please Fill in General Info before proceeding to this page";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ProfileShareholders GetProfileShareHolder(Adapter ad, string userId)
        {
            var response = new ProfileShareholders();

            try
            {
                var result = ProfileDAL.GetProfileShareHolder(ad, userId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
                    response.Result = result;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Please Fill in General Info before proceeding to this page";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }
        //after pagingnation
        public static ProfileEmployees GetProfileEmployee(Adapter ad, string tenantId, string searchKey, Pager pager = null)
        {
            var response = new ProfileEmployees();

            try
            {
                var result = ProfileDAL.GetProfileEmployee(ad, tenantId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;    
                    response.Result = result.Item1;
                    response.pageInfo = result.Item2;

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        //before pagingnation
        /*
        public static ProfileEmployees GetProfileEmployee(Adapter ad, string userId)
        {
            var response = new ProfileEmployees();

            try
            {
                var result = ProfileDAL.GetProfileEmployee(ad, userId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
                    response.Result = result;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }
        */

        public static TenantBranchLists GetBranchList(Adapter ad, string tenantId)
        {
            var response = new TenantBranchLists();

            try
            {
                var result = ProfileDAL.GetBranchList(ad, tenantId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
                    response.Result = result;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantBranches GetBranchDetail(Adapter ad, int tenantId)
        {
            var response = new TenantBranches();

            try
            {
                var result = ProfileDAL.GetBranchDetail(ad, tenantId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
                    response.Result = result;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantCorporateRegs GetCorporateList(Adapter ad, int tenantId)
        {
            var response = new TenantCorporateRegs();
            var code = string.Empty;
            try
            {
                var result = ProfileDAL.GetCorporateList(ad, tenantId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
                    response.Result = result;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantAgencyDetail GetCorporateDetail(Adapter ad, int tenantAgencyId)
        {
            var response = new TenantAgencyDetail();

            try
            {
                response = ProfileDAL.GetCorporateDetail(ad, tenantAgencyId);

                if (response.AgencyId != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantAgencyCodes GetAgencyCode(Adapter ad, int tenantAgencyId)
        {
            var response = new TenantAgencyCodes();

            try
            {
                var result = ProfileDAL.GetAgencyCode(ad, tenantAgencyId);

                if (result.Count != 0)
                {
                    response.Result = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantCertificates GetTenantCertificate(Adapter ad, int tenantId)
        {
            var response = new TenantCertificates();

            try
            {
                var result = ProfileDAL.GetTenantCertificate(ad, tenantId);

                if (result.Count != 0)
                {
                    response.Result = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantAwards GetTenantAward(Adapter ad, int tenantId)
        {
            var response = new TenantAwards();

            try
            {
                var result = ProfileDAL.GetTenantAward(ad, tenantId);

                if (result.Count != 0)
                {
                    response.Result = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantCertificate GetTenantCertificateDetail(Adapter ad, int tenantCertificationId)
        {
            var response = new TenantCertificate();

            try
            {
                response = ProfileDAL.GetTenantCertificateDetail(ad, tenantCertificationId);

                if (response.TenantCertificateId != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantAward GetTenantAwardDetail(Adapter ad, int tenantAwardId)
        {
            var response = new TenantAward();

            try
            {
                response = ProfileDAL.GetTenantAwardDetail(ad, tenantAwardId);

                if (response.TenantAwardId != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static UserDetailLists GetTenantUserList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new UserDetailLists();

            try
            {
                var result = ProfileDAL.GetTenantUserList(ad, tenantId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.UserList = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantRoleLists GetTenantRoleList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new TenantRoleLists();

            try
            {
                var result = ProfileDAL.GetTenantRoleList(ad, tenantId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.roleList = result.Item1;
                    response.pageInfo = result.Item2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        /*
        public static TenantRoleLists GetTenantRoleList(Adapter ad, int tenantId)
        {
            var response = new TenantRoleLists();

            try
            {
                var result = ProfileDAL.GetTenantRoleList(ad, tenantId);

                if (result.Count != 0)
                {
                    response.roleList = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }
        */

        public static UserDetail GetTenantUserDetail(Adapter ad, int userId)
        {
            var response = new UserDetail();

            try
            {
                response = ProfileDAL.GetTenantUserDetail(ad, userId);

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantRole GetTenantRoleDetail(Adapter ad, int roleId)
        {
            var response = new TenantRole();

            try
            {
                response = ProfileDAL.GetTenantRoleDetail(ad, roleId);

                if (response.RoleId != 0)
                {
                    var result = ProfileDAL.GetTenantRoleDetailModule(ad, roleId);
                    response.moduleIds = result;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantRoleReferences GetTenantRoleReference(Adapter ad, int tenantId)
        {
            var response = new TenantRoleReferences();

            try
            {
                var result = ProfileDAL.GetTenantRoleReference(ad, tenantId);

                if (result.Count != 0)
                {
                    response.Result = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Success";
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static TenantModules GetTenantModuleReference(Adapter ad, int tenantId)
        {
            var response = new TenantModules();

            try
            {
                var result = ProfileDAL.GetTenantModuleReference(ad, tenantId);

                if (result.Count != 0)
                {
                    response.Result = result;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Success";
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static UserSettingInfo GetUserSetting(Adapter ad, string userId)
        {
            var response = new UserSettingInfo();

            try
            {
                response = ProfileDAL.GetUserSetting(ad, userId);

                if (string.IsNullOrEmpty(response.Email) == false)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = string.Empty;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Please Fill in General Info before proceeding to this page";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static UserDepartmentRoleListDT GetUserDepartmentRoleList(Adapter ad, int userRoleId,  string searchKey, Pager pager = null)
        {
            var response = new UserDepartmentRoleListDT();
            try
            {
                var result = ProfileDAL.GetUserDepartmentRoleList(ad, userRoleId, searchKey, pager);
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

        public static UserDepartmentRoleDetails GetUserDepartmentRoleDetails(Adapter ad, int id)
        {
            var response = new UserDepartmentRoleDetails();
            try
            {
                response = ProfileDAL.GetUserDepartmentRoleDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        //--------------PUT Method--------------
        public static BasicApiResponse UpdateGeneralInfo(Adapter ad, string userId, GeneralInfoRequest generalInfo)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.UpdateGeneralInfo(ad, userId, generalInfo);

                if (result.ReturnCode == 1)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = result.ResponseMessage;
                }
                else if (result.ReturnCode == 2)
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateContactInfo(Adapter ad, string userId, ProfileContactRequest profileContact)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.UpdateContactInfo(ad, userId, profileContact);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateTenantEdition(Adapter ad, TenantEditionInfoUpsert edition)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.UpdateTenantEdition(ad,  edition);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateProfileShareholder(Adapter ad, string userId, ProfileShareholder profileShareholder)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.UpdateProfileShareholder(ad, userId, profileShareholder);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateProfileEmployee(Adapter ad, string userId, ProfileEmployee profileEmployee)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.UpdateProfileEmployee(ad, userId, profileEmployee);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateTenantBranch(Adapter ad, string userId, TenantBranch tenantBranch)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.UpdateTenantBranch(ad, userId, tenantBranch);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteAgencyCode(Adapter ad, string userId, CodeToRemoves codeToRemoves)
        {
            var response = new BasicApiResponse();

            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in codeToRemoves.removeIds)
                {
                    var result = ProfileDAL.DeleteAgencyCode(ad, id.TenantAgencyCodeId);
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Agency Code are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Delete Operation Fail";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateTenantCertificateDetail(Adapter ad, TenantCertificateUpdate tenantCertificateUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.UpdateTenantCertificateDetail(ad, tenantCertificateUpdate);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateTenantAwardDetail(Adapter ad, TenantAwardUpdate tenantAwardUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.UpdateTenantAwardDetail(ad, tenantAwardUpdate);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteTenantUserDetail(Adapter ad, List<UserIdToRemove> userIdToRemove)
        {
            var response = new BasicApiResponse();
            var returnCode = 0;
            var responseMessage = string.Empty;

            try
            {
                for (var i = 0; i < userIdToRemove.Count; i++)
                {
                    var result = ProfileDAL.DeleteTenantUserDetail(ad, userIdToRemove[i].UserId);
                    if (result.ReturnCode != 0) { returnCode = result.ReturnCode; responseMessage = result.ResponseMessage; }
                }


                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = responseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = responseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteTenantRoleDetail(Adapter ad, List<RoleToRemove> roleToRemove)
        {
            var response = new BasicApiResponse();
            var returnCode = 0;
            var responseMessage = string.Empty;

            try
            {
                for (var i = 0; i < roleToRemove.Count; i++)
                {
                    var result = ProfileDAL.DeleteTenantRoleDetail(ad, roleToRemove[i].RoleId);
                    if (result.ReturnCode != 0) { returnCode = result.ReturnCode; responseMessage = result.ResponseMessage; }
                }


                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = responseMessage;
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = responseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateTenantUser(Adapter ad, int tenantId, string encryptedPassword, UserDetail userDetail)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.UpdateTenantUser(ad, tenantId, encryptedPassword, userDetail);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "User Successfully Registered";
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateTenantRole(Adapter ad, int tenantId, TenantRole tenantRole)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.UpdateTenantRole(ad, tenantId, tenantRole);
                var roleId = tenantRole.RoleId;

                var moduleDeleteAll = ProfileDAL.DeleteTenantModuleAll(ad, roleId);

                if (roleId != 0)
                {
                    //loop to insert moduleid
                    for (var i = 0; i < tenantRole.moduleIds.Count; i++)
                    {
                        var moduleInsert = ProfileDAL.InsertTenantRoleModule(ad, roleId, tenantRole.moduleIds[i].ModuleId);
                    }
                }


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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateCorporateDetail(Adapter ad, CorporateRegistrationUpdate corporateDetail)
        {
            var response = new BasicApiResponse();

            var returnCode = 0;
            var responseMessage = string.Empty;

            try
            {
                var result = ProfileDAL.UpdateCorporateDetailParent(ad, corporateDetail);
                if (result.ReturnCode != 0) { returnCode = result.ReturnCode; responseMessage = result.ResponseMessage; }

                //Remove All Code under TenantAgencyId

                //var removeCode = ProfileDAL.RemoveCorporateCode(ad, corporateDetail.TenantAgencyId);
                //if (removeCode.ReturnCode != 0) { returnCode = removeCode.ReturnCode; responseMessage = removeCode.ResponseMessage; }


                //if (corporateDetail.Code.Count != 0)
                //{
                //    //loop to insert agencycode
                //    for (var i = 0; i < corporateDetail.Code.Count; i++)
                //    {
                //        var codeInsert = ProfileDAL.InsertCorporateCode(ad, corporateDetail.TenantAgencyId, corporateDetail.Code[i].AgencyCodeId);

                //        if (codeInsert.ReturnCode != 0) { returnCode = codeInsert.ReturnCode; responseMessage = codeInsert.ResponseMessage; }
                //    }
                //}

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Corporate Successfully Update";
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = responseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateUserSetting(Adapter ad, int userId, UserSetting userSetting)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.UpdateUserSetting(ad, userId, userSetting);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "User Successfully Update";
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse UpdateUserDepartmentRole(Adapter ad, UpdateUserDepartmentRole request, int updatorUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = ProfileDAL.UpdateUserDepartmentRole(ad, request, updatorUserId);

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

        //--------------POST Method--------------
        public static BasicApiResponse InsertProfileEmployee(Adapter ad, string userId, ProfileEmployeeNew profileEmployee)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.InsertProfileEmployee(ad, userId, profileEmployee);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse InsertTenantBranch(Adapter ad, string userId, string tenantId, TenantBranchRequest tenantBranch)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.InsertTenantBranch(ad, userId, tenantId, tenantBranch);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static PostApiResponse InsertCorporateDetail(Adapter ad, string tenantId, CorporateRegistration corporateDetail)
        {
            var response = new PostApiResponse();

            var returnCode = 0;
            var responseMessage = string.Empty;

            try
            {
                var result = ProfileDAL.InsertCorporateDetailParent(ad, tenantId, corporateDetail);
                var tenantAgencyId = result.Id;
                response.Id = result.Id;
                if (tenantAgencyId == 0) { returnCode = result.ReturnCode; responseMessage = result.ResponseMessage; }


                //if grade exist then insert agencygrade
                if (corporateDetail.AgencyGradeId != 0 && tenantAgencyId != 0)
                {
                    var insertGrade = ProfileDAL.InsertCorporateGrade(ad, tenantAgencyId, corporateDetail.AgencyGradeId);

                    if (insertGrade.ReturnCode != 0) { returnCode = insertGrade.ReturnCode; responseMessage = insertGrade.ResponseMessage; }
                }

                //if (corporateDetail.Code.Count != 0 && tenantAgencyId != 0)
                //{
                //    //loop to insert agencycode
                //    for (var i = 0; i < corporateDetail.Code.Count; i++)
                //    {
                //        var codeInsert = ProfileDAL.InsertCorporateCode(ad, tenantAgencyId, corporateDetail.Code[i].AgencyCodeId);

                //        if (codeInsert.ReturnCode != 0) { returnCode = codeInsert.ReturnCode; responseMessage = codeInsert.ResponseMessage; }

                //    }
                //}

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Corporate Successfully Registered";
                }
                else
                {
                    response.ReturnCode = 401;
                    response.ResponseMessage = responseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse InsertCorporateCode(Adapter ad, string tenantId, AgencyCodeInsert agencyCodeInsert)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.InsertCorporateCodeAll(ad, agencyCodeInsert);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Corporate Successfully Registered";
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse InsertCertificateDetail(Adapter ad, int tenantId, TenantCertificateNew tenantCertificateNew)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.InsertCertificateDetail(ad, tenantId, tenantCertificateNew);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Certificate Successfully Registered";
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse InsertAwardDetail(Adapter ad, int tenantId, TenantAwardNew tenantAwardNew)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.InsertAwardDetail(ad, tenantId, tenantAwardNew);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Award Successfully Registered";
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse InsertTenantUser(Adapter ad, int tenantId, string encryptedPassword, UserDetailNew userDetailNew)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.InsertTenantUser(ad, tenantId, encryptedPassword, userDetailNew);

                if (result.ReturnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "User Successfully Registered";
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse InsertTenantRole(Adapter ad, int tenantId, TenantRoleNew tenantRoleNew)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.InsertTenantRole(ad, tenantId, tenantRoleNew);
                var roleId = result.Id;

                //var moduleDeleteAll = ProfileDAL.DeleteTenantModuleAll(ad, roleId);

                if (roleId != 0)
                {
                    //loop to insert moduleid
                    for (var i = 0; i < tenantRoleNew.moduleIds.Count; i++)
                    {
                        var moduleInsert = ProfileDAL.InsertTenantRoleModule(ad, roleId, tenantRoleNew.moduleIds[i].ModuleId);
                    }
                }


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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }


        public static PostApiResponse InsertUserDepartmentRole(Adapter ad, InsertUserDepartmentRole request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ProfileDAL.InsertUserDepartmentRole(ad, request, creatorUserId);
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



        //--------------DELETE Method--------------
        public static BasicApiResponse DeleteProfileEmployee(Adapter ad, string userId, int tenantEmployeeId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.DeleteProfileEmployee(ad, userId, tenantEmployeeId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteTenantBranch(Adapter ad, string userId, int tenantBranchId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.DeleteTenantBranch(ad, userId, tenantBranchId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteCorporateRegistration(Adapter ad, string userId, int tenantAgencyId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.DeleteCorporateRegistration(ad, userId, tenantAgencyId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteTenantCertification(Adapter ad, int tenantCertificationId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.DeleteTenantCertification(ad, tenantCertificationId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteTenantAward(Adapter ad, int tenantAwardId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ProfileDAL.DeleteTenantAward(ad, tenantAwardId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }


        public static BasicApiResponse DeleteUserDepartmentRole(Adapter ad, List<ProfileListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = ProfileDAL.DeleteUserDepartmentRole(ad, inIds, deleteUserId);
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
