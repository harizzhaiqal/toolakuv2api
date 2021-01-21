using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.Profile;
using Toolaku.Models.Pagingnation;


namespace Toolaku.DataAccess
{
    public class ProfileDAL
    {
        //--------------GET Method--------------
        public static GeneralInfoResponse GetProfileGeneralInfo(Adapter ad, string userId)
        {
            var response = new GeneralInfoResponse();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetGeneralInfo", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.CoverImgUrl = reader.GetString(3);
                            response.LogoImgUrl = reader.GetString(4);
                            response.CompanyName = reader.GetString(5);
                            response.BRNo = reader.GetString(1);
                            //response.DateIncorporated = reader.GetDateTime(6);
                            response.DateIncorporated = (reader.GetValue(6) == DBNull.Value) ? "" : Convert.ToString(Convert.ToDateTime(reader.GetValue(6)).ToString("dd MMM yyyy"));

                            response.Form9URL = reader.GetString(7);
                            response.Form13URL = reader.GetString(8);
                            response.CountryId = reader.GetInt32(14);
                            response.Address1 = reader.GetString(9);
                            response.Address2 = reader.GetString(10);
                            response.Postcode = reader.GetString(11);
                            response.CityId = reader.GetInt32(12);
                            response.StateId = reader.GetInt32(13);
                            response.Username = reader.GetString(15);
                            response.City = reader.GetString(16);

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


        public static TenantEditionInfoResponse GetTenantEditionInfo(Adapter ad, int tenantId)
        {
            var response = new TenantEditionInfoResponse();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantEdition ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.TenantId = Convert.ToInt32(reader.GetValue(0)); 
                            response.TenantName = reader.GetString(1);
                            response.EditionId = Convert.ToInt32(reader.GetValue(2));
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

        public static List<ProfileContact> GetProfileContact(Adapter ad, string userId)
        {
            var response = new List<ProfileContact>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetContact", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProfileContact();
                            result.TenantId = Convert.ToInt32(reader.GetValue(0));
                            result.OfficialEmail = Convert.ToString(reader.GetValue(1));
                            result.OfficePhone = Convert.ToString(reader.GetValue(2));
                            result.OfficePhone2 = Convert.ToString(reader.GetValue(3));
                            result.OfficeFax = Convert.ToString(reader.GetValue(4));
                            result.PICName = Convert.ToString(reader.GetValue(5));
                            result.PICDesignation = Convert.ToString(reader.GetValue(6));
                            result.MobileNo = Convert.ToString(reader.GetValue(7));
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

        public static List<ProfileShareholder> GetProfileShareHolder(Adapter ad, string userId)
        {
            var result = new List<ProfileShareholder>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetShareholder", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var response = new ProfileShareholder();

                            if (reader.GetValue(0).ToString() != "") { response.AuthorizeCapital = Convert.ToDouble(reader.GetValue(0)); } else { response.AuthorizeCapital = 0; }
                            if (reader.GetValue(1).ToString() != "") { response.PreferenceShares = Convert.ToDouble(reader.GetValue(1)); } else { response.PreferenceShares = 0; }
                            if (reader.GetValue(2).ToString() != "") { response.ValuePreferenceShares = Convert.ToDouble(reader.GetValue(2)); } else { response.ValuePreferenceShares = 0; }
                            if (reader.GetValue(3).ToString() != "") { response.OrdinaryShares = Convert.ToDouble(reader.GetValue(3)); } else { response.OrdinaryShares = 0; }
                            if (reader.GetValue(4).ToString() != "") { response.ValueOrdinaryShares = Convert.ToDouble(reader.GetValue(4)); } else { response.ValueOrdinaryShares = 0; }
                            result.Add(response);
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
            return result;
        }

        public static (List<ProfileEmployee>, PageInfo) GetProfileEmployee(Adapter ad, string tenantId, string searchKey, Pager pager = null)
        {
            var result = new List<ProfileEmployee>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetEmployeeSummary", ad.SQLConn, ad.SQLTran))
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
                            var response = new ProfileEmployee();
                            response.TenantEmployeeId = Convert.ToInt32(reader.GetValue(0));
                            response.DepartmentName = Convert.ToString(reader.GetValue(1));
                            response.NoPermanentStaff = Convert.ToInt32(reader.GetValue(2));
                            response.NoContractStaff = Convert.ToInt32(reader.GetValue(3));

                            result.Add(response);
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
            return (result, response2);
        }

        //before pagingnation
        /*
        public static List<ProfileEmployee> GetProfileEmployee(Adapter ad, string userId)
        {
            var result = new List<ProfileEmployee>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetEmployeeSummary", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var response = new ProfileEmployee();
                            response.TenantEmployeeId = Convert.ToInt32(reader.GetValue(0));
                            response.DepartmentName = Convert.ToString(reader.GetValue(1));
                            response.NoPermanentStaff = Convert.ToInt32(reader.GetValue(2));
                            response.NoContractStaff = Convert.ToInt32(reader.GetValue(3));

                            result.Add(response);
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
            return result;
        }
        */

        public static List<TenantBranchList> GetBranchList(Adapter ad, string tenantId)
        {
            var result = new List<TenantBranchList>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetBranchList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var response = new TenantBranchList();
                            response.TenantBranchId = Convert.ToInt32(reader.GetValue(0));
                            response.ImageURL = Convert.ToString(reader.GetValue(1));
                            response.Name = Convert.ToString(reader.GetValue(2));
                            response.LocationTypeName = Convert.ToString(reader.GetValue(3));
                            response.Address = Convert.ToString(reader.GetValue(4));
                            response.PhoneNo = Convert.ToString(reader.GetValue(5));
                            response.FaxNo = Convert.ToString(reader.GetValue(6));
                            result.Add(response);
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
            return result;
        }

        public static List<TenantBranch> GetBranchDetail(Adapter ad, int branchId)
        {
            var result = new List<TenantBranch>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetBranchDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = branchId, ParameterName = "@TenantBranchId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var response = new TenantBranch();
                            response.TenantBranchId = Convert.ToInt32(reader.GetValue(0));
                            response.ImageURL = Convert.ToString(reader.GetValue(1));
                            response.Name = Convert.ToString(reader.GetValue(2));
                            response.LocationTypeId = Convert.ToString(reader.GetValue(3));
                            response.CountryId = Convert.ToInt32(reader.GetValue(4));
                            response.Address1 = Convert.ToString(reader.GetValue(5));
                            response.Address2 = Convert.ToString(reader.GetValue(6));
                            response.Poscode = Convert.ToString(reader.GetValue(7));
                            response.CityId = Convert.ToInt32(reader.GetValue(8));
                            response.StateId = Convert.ToInt32(reader.GetValue(9));
                            response.PhoneNo = Convert.ToString(reader.GetValue(10));
                            response.FaxNo = Convert.ToString(reader.GetValue(11));
                            response.City = Convert.ToString(reader.GetValue(12));
                            result.Add(response);
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
            return result;
        }

        public static List<TenantCorporateReg> GetCorporateList(Adapter ad, int tenantId)
        {
            var result = new List<TenantCorporateReg>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetCorporateList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var response = new TenantCorporateReg();
                            response.TenantAgencyId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                response.ImageURL = reader.GetString(1);
                            }
                            else
                            {
                                response.ImageURL = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg";
                            }
                            response.OrgName = Convert.ToString(reader.GetValue(2));
                            response.ValidFrom = Convert.ToString(reader.GetValue(3));
                            response.ValidTill = Convert.ToString(reader.GetValue(4));
                            result.Add(response);
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
            return result;
        }

        public static TenantAgencyDetail GetCorporateDetail(Adapter ad, int tenantAgencyId)
        {
            var response = new TenantAgencyDetail();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetCorporateDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantAgencyId, ParameterName = "@TenantAgencyId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            response.TenantAgencyId = Convert.ToInt32(reader.GetValue(0));
                            response.AgencyId = Convert.ToInt32(reader.GetValue(1));
                            if (reader.GetValue(2).ToString() != "")
                            {
                                response.TenantAgencyGradeId = Convert.ToInt32(reader.GetValue(2));
                            }
                            else
                            {
                                response.TenantAgencyGradeId = 0;
                            }
                            response.ValidFrom = Convert.ToString(reader.GetValue(3));
                            response.ValidTill = Convert.ToString(reader.GetValue(4));

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

        public static List<TenantAgencyCode> GetAgencyCode(Adapter ad, int tenantAgencyId)
        {
            var response = new List<TenantAgencyCode>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetAgencyCode", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantAgencyId, ParameterName = "@TenantAgencyId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantAgencyCode();
                            result.TenantAgencyCodeId = Convert.ToInt32(reader.GetValue(0));
                            result.Code = Convert.ToString(reader.GetValue(1));
                            result.Description = Convert.ToString(reader.GetValue(2));
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

        public static List<TenantCertificate> GetTenantCertificate(Adapter ad, int tenantId)
        {
            var response = new List<TenantCertificate>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantCertificate", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantCertificate();
                            result.TenantCertificateId = Convert.ToInt32(reader.GetValue(0));
                            result.LogoURL = Convert.ToString(reader.GetValue(1));
                            result.CertificateName = Convert.ToString(reader.GetValue(2));
                            result.CertNo = Convert.ToString(reader.GetValue(3));
                            result.IssuedBy = Convert.ToString(reader.GetValue(4));
                            result.DateIssued = Convert.ToString(reader.GetValue(5));
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

        public static List<TenantAward> GetTenantAward(Adapter ad, int tenantId)
        {
            var response = new List<TenantAward>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantAward", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantAward();
                            result.TenantAwardId = Convert.ToInt32(reader.GetValue(0));
                            result.LogoURL = Convert.ToString(reader.GetValue(1));
                            result.AwardName = Convert.ToString(reader.GetValue(2));
                            result.Description = Convert.ToString(reader.GetValue(3));
                            result.AwardedBy = Convert.ToString(reader.GetValue(4));
                            result.DateAwarded = Convert.ToString(reader.GetValue(5));
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

        public static TenantCertificate GetTenantCertificateDetail(Adapter ad, int tenantCertificationId)
        {
            var response = new TenantCertificate();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantCertificateDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificationId, ParameterName = "@TenantCertificationId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.TenantCertificateId = Convert.ToInt32(reader.GetValue(0));
                            response.LogoURL = Convert.ToString(reader.GetValue(1));
                            response.CertificateName = Convert.ToString(reader.GetValue(2));
                            response.CertNo = Convert.ToString(reader.GetValue(3));
                            response.IssuedBy = Convert.ToString(reader.GetValue(4));
                            response.DateIssued = Convert.ToString(reader.GetValue(5));
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

        public static TenantAward GetTenantAwardDetail(Adapter ad, int tenantAwardId)
        {
            var response = new TenantAward();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantAwardDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardId, ParameterName = "@TenantAwardId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.TenantAwardId = Convert.ToInt32(reader.GetValue(0));
                            response.LogoURL = Convert.ToString(reader.GetValue(1));
                            response.AwardName = Convert.ToString(reader.GetValue(2));
                            response.Description = Convert.ToString(reader.GetValue(3));
                            response.AwardedBy = Convert.ToString(reader.GetValue(4));
                            response.DateAwarded = Convert.ToString(reader.GetValue(5));
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
        //before pagingnation
        /*
        public static List<UserDetailList> GetTenantUserList(Adapter ad, int tenantId)
        {
            var response = new List<UserDetailList>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantUserList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new UserDetailList();
                            result.UserId = Convert.ToInt32(reader.GetValue(0));
                            result.Name = Convert.ToString(reader.GetValue(1));
                            result.Username = Convert.ToString(reader.GetValue(2));
                            result.MobileNo = Convert.ToString(reader.GetValue(3));
                            result.ActiveStatus = Convert.ToBoolean(reader.GetValue(4));
                            result.RoleName = Convert.ToString(reader.GetValue(5));

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

        public static (List<UserDetailList>, PageInfo)  GetTenantUserList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<UserDetailList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantUserList", ad.SQLConn, ad.SQLTran))
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
                            var result = new UserDetailList();
                            result.UserId = Convert.ToInt32(reader.GetValue(0));
                            result.Name = Convert.ToString(reader.GetValue(1));
                            result.Username = Convert.ToString(reader.GetValue(2));
                            result.MobileNo = Convert.ToString(reader.GetValue(3));
                            result.ActiveStatus = Convert.ToBoolean(reader.GetValue(4));
                            result.RoleName = Convert.ToString(reader.GetValue(5));

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

        public static (List<TenantRoleList>, PageInfo)   GetTenantRoleList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantRoleList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantRoleList", ad.SQLConn, ad.SQLTran))
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
                            var result = new TenantRoleList();
                            result.RoleId = Convert.ToInt32(reader.GetValue(0));
                            result.Name = Convert.ToString(reader.GetValue(1));
                            result.ActiveStatus = Convert.ToBoolean(reader.GetValue(2));

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

        public static UserDetail GetTenantUserDetail(Adapter ad, int userId)
        {
            var response = new UserDetail();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantUserDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.UserId = Convert.ToInt32(reader.GetValue(0));
                            response.ImageUrl = Convert.ToString(reader.GetValue(1));
                            response.Name = Convert.ToString(reader.GetValue(2));
                            response.Username = Convert.ToString(reader.GetValue(3));
                            response.Password = Convert.ToString(reader.GetValue(4));
                            response.MobileNo = Convert.ToString(reader.GetValue(5));
                            response.ActiveStatus = Convert.ToBoolean(reader.GetValue(6));
                            response.RoleId = Convert.ToInt32(reader.GetValue(7));
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

        public static TenantRole GetTenantRoleDetail(Adapter ad, int roleId)
        {
            var response = new TenantRole();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantRoleDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = roleId, ParameterName = "@RoleId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.RoleId = Convert.ToInt32(reader.GetValue(0));
                            response.Name = Convert.ToString(reader.GetValue(1));
                            response.ActiveStatus = Convert.ToBoolean(reader.GetValue(2));

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

        public static List<TenantModule> GetTenantRoleDetailModule(Adapter ad, int roleId)
        {
            var response = new List<TenantModule>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantRoleDetailModule", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = roleId, ParameterName = "@RoleId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantModule();
                            result.ModuleId = Convert.ToInt32(reader.GetValue(0));
                            result.ModuleName = Convert.ToString(reader.GetValue(1));

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

        public static List<TenantRoleReference> GetTenantRoleReference(Adapter ad, int tenantId)
        {
            var response = new List<TenantRoleReference>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantRoleReference", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantRoleReference();
                            result.RoleId = Convert.ToInt32(reader.GetValue(0));
                            result.RoleName = Convert.ToString(reader.GetValue(1));
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

        public static List<TenantModule> GetTenantModuleReference(Adapter ad, int tenantId)
        {
            var response = new List<TenantModule>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetTenantModuleReference", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TenantModule();
                            result.ModuleId = Convert.ToInt32(reader.GetValue(0));
                            result.ModuleName = Convert.ToString(reader.GetValue(1));
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

        public static UserSettingInfo GetUserSetting(Adapter ad, string userId)
        {
            var result = new UserSettingInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Profile_GetUserSetting", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.ProfileImage = Convert.ToString(reader.GetValue(0));
                            result.Fullname = Convert.ToString(reader.GetValue(1));
                            result.Email = Convert.ToString(reader.GetValue(2));
                            result.PhoneNo = Convert.ToString(reader.GetValue(3));
                            result.UserRole = Convert.ToInt32(reader.GetValue(4));
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
            return result;
        }


        public static (List<UserDepartmentRoleList>, PageInfo) GetUserDepartmentRoleList(Adapter ad, int userRoleId, string searchKey, Pager pager = null)
        {
            var response = new List<UserDepartmentRoleList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_GetUserDepartmentRoleList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userRoleId, ParameterName = "@UserRoleId" });
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
                        int UserRoleId = reader.GetOrdinal("UserRoleId");
                        int DepartmentRoleName = reader.GetOrdinal("DepartmentRoleName");
                        int DepartmentRoleId = reader.GetOrdinal("DepartmentRoleId");
                        int IsDeleted = reader.GetOrdinal("IsDeleted");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            var result = new UserDepartmentRoleList
                            {
                                Id = (reader.GetValue(Id) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(Id)),
                                UserRoleId = (reader.GetValue(UserRoleId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(UserRoleId)),
                                DepartmentRoleId = (reader.GetValue(DepartmentRoleId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(DepartmentRoleId)),
                                DepartmentRoleName = (reader.GetValue(DepartmentRoleName) == DBNull.Value) ? "" : reader.GetString(DepartmentRoleName),
                                IsDeleted = (reader.GetValue(IsDeleted) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(IsDeleted)),
                                IsEnable = (reader.GetValue(IsEnable) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(IsEnable)),
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

        public static UserDepartmentRoleDetails GetUserDepartmentRoleDetails(Adapter ad, int id)
        {
            var response = new UserDepartmentRoleDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_GetUserDepartmentRoleDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int UserRoleId = reader.GetOrdinal("UserRoleId");
                        int DepartmentRoleId = reader.GetOrdinal("DepartmentRoleId");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.UserRoleId = (reader.GetValue(UserRoleId) == DBNull.Value) ? 0 : Convert.ToInt32(reader.GetValue(UserRoleId));
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

        //--------------PUT Method--------------
        public static BasicApiResponse UpdateGeneralInfo(Adapter ad, string userId, GeneralInfoRequest generalInfo)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateGeneralInfo ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    if (generalInfo.CoverImgUrl != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = generalInfo.CoverImgUrl, ParameterName = "@CoverImgUrl" });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter() { Value = "https://toolakufiles.blob.core.windows.net/mytenantimage/NoBannerimage.jpg", ParameterName = "@CoverImgUrl" });
                    }
                    if (generalInfo.LogoImgUrl != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = generalInfo.LogoImgUrl, ParameterName = "@LogoImgUrl" });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter() { Value = "https://toolakufiles.blob.core.windows.net/mytenantimage/nologoimage.jpg", ParameterName = "@LogoImgUrl" });
                    }
                    command.Parameters.Add(new SqlParameter() { Value = generalInfo.CompanyName, ParameterName = "@CompanyName" });
                    command.Parameters.Add(new SqlParameter() { Value = generalInfo.BRNo, ParameterName = "@BRNo" });
                    command.Parameters.Add(new SqlParameter() { Value = generalInfo.DateIncorporated, ParameterName = "@DateIncorporated" });

                    if (generalInfo.Form9URL != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = generalInfo.Form9URL, ParameterName = "@Form9URL" });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter() { Value = "", ParameterName = "@Form9URL" });
                    }
                    if (generalInfo.Form13URL != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = generalInfo.Form13URL, ParameterName = "@Form13URL" });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter() { Value = "", ParameterName = "@Form13URL" });
                    }
                    command.Parameters.Add(new SqlParameter() { Value = generalInfo.CountryId, ParameterName = "@CountryId" });
                    command.Parameters.Add(new SqlParameter() { Value = generalInfo.Address1, ParameterName = "@Address1" });
                    if (generalInfo.Address2 != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = generalInfo.Address2, ParameterName = "@Address2" });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter() { Value = " ", ParameterName = "@Address2" });
                    }
                    
                    command.Parameters.Add(new SqlParameter() { Value = generalInfo.Postcode, ParameterName = "@Postcode" });
                    command.Parameters.Add(new SqlParameter() { Value = generalInfo.CityId, ParameterName = "@CityId" });
                    command.Parameters.Add(new SqlParameter() { Value = generalInfo.StateId, ParameterName = "@StateId" });
                    command.Parameters.Add(new SqlParameter() { Value = generalInfo.City, ParameterName = "@City" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse UpdateContactInfo(Adapter ad, string userId, ProfileContactRequest profileContact)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateContact", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = profileContact.OfficialEmail, ParameterName = "@OfficialEmail" });
                    command.Parameters.Add(new SqlParameter() { Value = profileContact.OfficePhone, ParameterName = "@OfficePhone" });
                    command.Parameters.Add(new SqlParameter() { Value = profileContact.OfficePhone2, ParameterName = "@OfficePhone2" });
                    command.Parameters.Add(new SqlParameter() { Value = profileContact.OfficeFax, ParameterName = "@OfficeFax" });
                    command.Parameters.Add(new SqlParameter() { Value = profileContact.PICName, ParameterName = "@PICName" });
                    command.Parameters.Add(new SqlParameter() { Value = profileContact.PICDesignation, ParameterName = "@PICDesignation" });
                    command.Parameters.Add(new SqlParameter() { Value = profileContact.MobileNo, ParameterName = "@MobileNo" });

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


        public static BasicApiResponse UpdateTenantEdition(Adapter ad, TenantEditionInfoUpsert edition)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateTenantEdition", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = edition.TenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = edition.EditionId, ParameterName = "@EditionId" });
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static BasicApiResponse UpdateProfileShareholder(Adapter ad, string userId, ProfileShareholder profileShareholder)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateShareHolder", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = profileShareholder.AuthorizeCapital, ParameterName = "@AuthorizeCapital" });
                    command.Parameters.Add(new SqlParameter() { Value = profileShareholder.PreferenceShares, ParameterName = "@PreferenceShares" });
                    command.Parameters.Add(new SqlParameter() { Value = profileShareholder.ValuePreferenceShares, ParameterName = "@ValuePreferenceShares" });
                    command.Parameters.Add(new SqlParameter() { Value = profileShareholder.OrdinaryShares, ParameterName = "@OrdinaryShares" });
                    command.Parameters.Add(new SqlParameter() { Value = profileShareholder.ValueOrdinaryShares, ParameterName = "@ValueOrdinaryShares" });

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

        public static BasicApiResponse UpdateProfileEmployee(Adapter ad, string userId, ProfileEmployee profileEmployee)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateEmployeeSummary", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = profileEmployee.TenantEmployeeId, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = profileEmployee.DepartmentName, ParameterName = "@DepartmentName" });
                    command.Parameters.Add(new SqlParameter() { Value = profileEmployee.NoPermanentStaff, ParameterName = "@NoPermanentStaff" });
                    command.Parameters.Add(new SqlParameter() { Value = profileEmployee.NoContractStaff, ParameterName = "@NoContractStaff" });

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

        public static BasicApiResponse UpdateTenantBranch(Adapter ad, string userId, TenantBranch tenantBranch)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateTenantBranch", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.TenantBranchId, ParameterName = "@TenantBranchId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.ImageURL, ParameterName = "@ImageURL" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.LocationTypeId, ParameterName = "@LocationTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.CountryId, ParameterName = "@CountryId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.Address1, ParameterName = "@Address1" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.Address2, ParameterName = "@Address2" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.Poscode, ParameterName = "@Poscode" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.CityId, ParameterName = "@CityId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.StateId, ParameterName = "@StateId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.PhoneNo, ParameterName = "@PhoneNo" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.FaxNo, ParameterName = "@FaxNo" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.City, ParameterName = "@City" });

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

        public static BasicApiResponse DeleteAgencyCode(Adapter ad, int tenantAgencyCodeId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_DeleteAgencyCode ", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantAgencyCodeId, ParameterName = "@TenantAgencyCodeId" });

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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse UpdateTenantCertificateDetail(Adapter ad, TenantCertificateUpdate tenantCertificateUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateTenantCertificate", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificateUpdate.TenantCertificateId, ParameterName = "@TenantCertificateId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificateUpdate.LogoURL, ParameterName = "@LogoURL" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificateUpdate.CertificateName, ParameterName = "@CertificateName" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificateUpdate.CertNo, ParameterName = "@CertNo" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificateUpdate.IssuedBy, ParameterName = "@IssuedBy" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificateUpdate.DateIssued, ParameterName = "@DateIssued" });

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

        public static BasicApiResponse UpdateTenantAwardDetail(Adapter ad, TenantAwardUpdate tenantAwardUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateTenantAward", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardUpdate.TenantAwardId, ParameterName = "@TenantAwardId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardUpdate.LogoURL, ParameterName = "@LogoURL" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardUpdate.AwardName, ParameterName = "@AwardName" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardUpdate.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardUpdate.AwardedBy, ParameterName = "@AwardedBy" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardUpdate.DateAwarded, ParameterName = "@DateAwarded" });

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

        public static BasicApiResponse DeleteTenantUserDetail(Adapter ad, int userId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_DeleteTenantUserDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static BasicApiResponse DeleteTenantRoleDetail(Adapter ad, int roleId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_DeleteTenantRoleDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = roleId, ParameterName = "@RoleId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static BasicApiResponse UpdateTenantUser(Adapter ad, int tenantId, string encryptedPassword, UserDetail userDetail)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateTenantUser", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userDetail.UserId, ParameterName = "@UserId" });
                    if (userDetail.ImageUrl != "")
                    {
                        command.Parameters.Add(new SqlParameter() { Value = userDetail.ImageUrl, ParameterName = "@ImageUrl" });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter() { Value = "https://toolakufiles.blob.core.windows.net/mytenantimage/586ba3c0-c90e-432a-85f2-415b5adc5cbf", ParameterName = "@ImageUrl" });
                    }
                    command.Parameters.Add(new SqlParameter() { Value = userDetail.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = userDetail.Username, ParameterName = "@Username" });
                    command.Parameters.Add(new SqlParameter() { Value = encryptedPassword, ParameterName = "@Password" });
                    command.Parameters.Add(new SqlParameter() { Value = userDetail.MobileNo, ParameterName = "@MobileNo" });
                    command.Parameters.Add(new SqlParameter() { Value = userDetail.ActiveStatus, ParameterName = "@ActiveStatus" });
                    command.Parameters.Add(new SqlParameter() { Value = userDetail.RoleId, ParameterName = "@RoleId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static PostApiResponse UpdateTenantRole(Adapter ad, int tenantId, TenantRole tenantRole)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateTenantRole", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantRole.RoleId, ParameterName = "@RoleId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantRole.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantRole.ActiveStatus, ParameterName = "@ActiveStatus" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static BasicApiResponse UpdateCorporateDetailParent(Adapter ad, CorporateRegistrationUpdate corporateDetail)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateCorporateDetailParent", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = corporateDetail.TenantAgencyId, ParameterName = "@TenantAgencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = corporateDetail.ValidFrom, ParameterName = "@ValidFrom" });
                    command.Parameters.Add(new SqlParameter() { Value = corporateDetail.ValidTill, ParameterName = "@ValidTill" });
                    command.Parameters.Add(new SqlParameter() { Value = corporateDetail.AgencyGradeId, ParameterName = "@AgencyGradeId" });

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

        public static BasicApiResponse RemoveCorporateCode(Adapter ad, int tenantAgencyId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_RemoveCorporateCode", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantAgencyId, ParameterName = "@TenantAgencyId" });

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

        public static BasicApiResponse UpdateUserSetting(Adapter ad, int userId, UserSetting userSetting)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateUserSetting", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    if (userSetting.ImageUrl != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = userSetting.ImageUrl, ParameterName = "@ImageUrl" });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter() { Value = "https://toolakufiles.blob.core.windows.net/mytenantimage/586ba3c0-c90e-432a-85f2-415b5adc5cbf", ParameterName = "@ImageUrl" });
                    }
                    command.Parameters.Add(new SqlParameter() { Value = userSetting.Fullname, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = userSetting.PhoneNo, ParameterName = "@MobileNo" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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



        public static BasicApiResponse UpdateUserDepartmentRole(Adapter ad, UpdateUserDepartmentRole request, int updatorUserId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_UpdateUserDepartmentRole", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.UserRoleId, ParameterName = "@UserRoleId" });
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

        //--------------POST Method--------------
        public static BasicApiResponse InsertProfileEmployee(Adapter ad, string userId, ProfileEmployeeNew profileEmployee)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertEmployeeSummary", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = profileEmployee.DepartmentName, ParameterName = "@DepartmentName" });
                    command.Parameters.Add(new SqlParameter() { Value = profileEmployee.NoPermanentStaff, ParameterName = "@NoPermanentStaff" });
                    command.Parameters.Add(new SqlParameter() { Value = profileEmployee.NoContractStaff, ParameterName = "@NoContractStaff" });

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

        public static BasicApiResponse InsertTenantBranch(Adapter ad, string userId, string tenantId, TenantBranchRequest tenantBranch)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertTenantBranch", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.ImageURL, ParameterName = "@ImageURL" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.LocationTypeId, ParameterName = "@LocationTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.CountryId, ParameterName = "@CountryId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.Address1, ParameterName = "@Address1" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.Address2, ParameterName = "@Address2" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.Poscode, ParameterName = "@Poscode" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.CityId, ParameterName = "@CityId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.StateId, ParameterName = "@StateId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.PhoneNo, ParameterName = "@PhoneNo" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.FaxNo, ParameterName = "@FaxNo" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranch.City, ParameterName = "@City" });

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

        public static PostApiResponse InsertCorporateDetailParent(Adapter ad, string tenantId, CorporateRegistration corporateDetail)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertCorporateDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = corporateDetail.AgencyId, ParameterName = "@AgencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = corporateDetail.ValidFrom, ParameterName = "@ValidFrom" });
                    command.Parameters.Add(new SqlParameter() { Value = corporateDetail.ValidTill, ParameterName = "@ValidTill" });
                    command.Parameters.Add(new SqlParameter() { Value = corporateDetail.AgencyGradeId, ParameterName = "@AgencyGradeId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                            response.Id = reader.GetInt32(2);
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

        public static BasicApiResponse InsertCorporateGrade(Adapter ad, int tenantAgencyId, int agencyGradeId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertCorporateGrade", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantAgencyId, ParameterName = "@TenantAgencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = agencyGradeId, ParameterName = "@AgencyGradeId" });

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

        public static BasicApiResponse InsertCorporateCode(Adapter ad, int tenantAgencyId, int agencyCodeId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertCorporateCode", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantAgencyId, ParameterName = "@TenantAgencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = agencyCodeId, ParameterName = "@AgencyCodeId" });

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

        public static BasicApiResponse InsertCorporateCodeAll(Adapter ad, AgencyCodeInsert agencyCodeInsert)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertCorporateCodeAll", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = agencyCodeInsert.TenantAgencyId, ParameterName = "@TenantAgencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = agencyCodeInsert.ParentCodeId, ParameterName = "@ParentCodeId" });
                    command.Parameters.Add(new SqlParameter() { Value = agencyCodeInsert.ChildCodeId, ParameterName = "@ChildCodeId" });
                    command.Parameters.Add(new SqlParameter() { Value = agencyCodeInsert.CodeId, ParameterName = "@CodeId" });

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

        public static BasicApiResponse InsertCertificateDetail(Adapter ad, int tenantId, TenantCertificateNew tenantCertificateNew)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertTenantCertificate", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    if (tenantCertificateNew.LogoURL != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = tenantCertificateNew.LogoURL, ParameterName = "@LogoURL" });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter() { Value = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg", ParameterName = "@LogoURL" });
                    }
                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificateNew.CertificateName, ParameterName = "@CertificateName" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificateNew.CertNo, ParameterName = "@CertNo" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificateNew.IssuedBy, ParameterName = "@IssuedBy" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificateNew.DateIssued, ParameterName = "@DateIssued" });

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

        public static BasicApiResponse InsertAwardDetail(Adapter ad, int tenantId, TenantAwardNew tenantAwardNew)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertTenantAward", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    if (tenantAwardNew.LogoURL != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = tenantAwardNew.LogoURL, ParameterName = "@LogoURL" });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter() { Value = "https://toolakufiles.blob.core.windows.net/mytenantimage/noimage.jpg", ParameterName = "@LogoURL" });
                    }
                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardNew.AwardName, ParameterName = "@AwardName" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardNew.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardNew.AwardedBy, ParameterName = "@AwardedBy" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardNew.DateAwarded, ParameterName = "@DateAwarded" });

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

        public static BasicApiResponse InsertTenantUser(Adapter ad, int tenantId, string encryptedPassword, UserDetailNew userDetailNew)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertTenantUser", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    if (userDetailNew.ImageUrl != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = userDetailNew.ImageUrl, ParameterName = "@ImageUrl" });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter() { Value = "https://toolakufiles.blob.core.windows.net/mytenantimage/586ba3c0-c90e-432a-85f2-415b5adc5cbf", ParameterName = "@ImageUrl" });
                    }
                    command.Parameters.Add(new SqlParameter() { Value = userDetailNew.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = userDetailNew.Username, ParameterName = "@Username" });
                    command.Parameters.Add(new SqlParameter() { Value = encryptedPassword, ParameterName = "@Password" });
                    command.Parameters.Add(new SqlParameter() { Value = userDetailNew.MobileNo, ParameterName = "@MobileNo" });
                    command.Parameters.Add(new SqlParameter() { Value = userDetailNew.ActiveStatus, ParameterName = "@ActiveStatus" });
                    command.Parameters.Add(new SqlParameter() { Value = userDetailNew.RoleId, ParameterName = "@RoleId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static PostApiResponse InsertTenantRole(Adapter ad, int tenantId, TenantRoleNew tenantRoleNew)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertTenantRole", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantRoleNew.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantRoleNew.ActiveStatus, ParameterName = "@ActiveStatus" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
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

        public static BasicApiResponse InsertTenantRoleModule(Adapter ad, int roleId, int moduleId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertTenantRoleModule", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = roleId, ParameterName = "@RoleId" });
                    command.Parameters.Add(new SqlParameter() { Value = moduleId, ParameterName = "@ModuleId" });

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


        public static PostApiResponse InsertUserDepartmentRole(Adapter ad, InsertUserDepartmentRole request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_InsertUserDepartmentRole", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.UserRoleId, ParameterName = "@UserRoleId" });
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


        //--------------DELETE Method--------------
        public static BasicApiResponse DeleteProfileEmployee(Adapter ad, string userId, int tenantEmployeeId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_DeleteEmployeeSummary", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantEmployeeId, ParameterName = "@Id" });

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

        public static BasicApiResponse DeleteTenantBranch(Adapter ad, string userId, int tenantBranchId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_DeleteTenantBranch", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantBranchId, ParameterName = "@Id" });

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

        public static BasicApiResponse DeleteCorporateRegistration(Adapter ad, string userId, int tenantAgencyId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_DeleteCorporateList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantAgencyId, ParameterName = "@TenantAgencyId" });

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

        public static BasicApiResponse DeleteTenantCertification(Adapter ad, int tenantCertificationId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_DeleteTenantCertification", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantCertificationId, ParameterName = "@TenantCertificationId" });

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

        public static BasicApiResponse DeleteTenantAward(Adapter ad, int tenantAwardId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_DeleteTenantAward", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantAwardId, ParameterName = "@TenantAwardId" });

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

        public static BasicApiResponse DeleteTenantModuleAll(Adapter ad, int roleId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_DeleteTenantModuleAll", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = roleId, ParameterName = "@RoleId" });

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


        public static BasicApiResponse DeleteUserDepartmentRole(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Profile_DeleteUserDepartmentRole", ad.SQLConn, ad.SQLTran))
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
