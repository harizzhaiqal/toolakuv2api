using System;
using Toolaku.Models;
using Toolaku.Library;
using Toolaku.Models.Account;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using Toolaku.Models.Reference;
using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.DataAccess
{
    
    public class AccountDAL
    {
        public static AuthenticateResult Authenticate(Adapter ad, string email, string encryptedPassword)
        {
            var authenticateResult = new AuthenticateResult();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Account_Authenticate", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = email, ParameterName = "@Email" });
                    command.Parameters.Add(new SqlParameter() { Value = encryptedPassword, ParameterName = "@Password" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            authenticateResult.Status = reader.GetString(0);
                            authenticateResult.ReturnCode = reader.GetInt32(1);
                            authenticateResult.UserId = Convert.ToString(reader.GetValue(2));
                            authenticateResult.TenantId = Convert.ToString(reader.GetValue(3));
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
            return authenticateResult;
        }

        public static AuthenticateResult AuthenticateRelogin(Adapter ad, string UserName)
        {
            var authenticateResult = new AuthenticateResult();

            

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Account_AuthenticateRelogin", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = UserName, ParameterName = "@UserName" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            authenticateResult.Status = reader.GetString(0);
                            authenticateResult.ReturnCode = reader.GetInt32(1);
                            authenticateResult.UserId = Convert.ToString(reader.GetValue(2));
                            authenticateResult.TenantId = Convert.ToString(reader.GetValue(3));
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
            return authenticateResult;
        }

        public static RegisterResponse Register(Adapter ad, SignUpRequest signUp, string encryptedPassword)
        {
            var signUpResponse = new RegisterResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Account_Register2", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = signUp.Email, ParameterName = "@Email" });
                    command.Parameters.Add(new SqlParameter() { Value = signUp.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = signUp.MobileNo, ParameterName = "@MobileNo" });
                    command.Parameters.Add(new SqlParameter() { Value = encryptedPassword, ParameterName = "@Password" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //signUpResponse.IsSuccessful = reader.GetBoolean(0);
                            signUpResponse.UserId = reader.GetInt32(0);
                            signUpResponse.ReturnCode = reader.GetInt32(1);
                            signUpResponse.ResponseMessage = reader.GetString(2);

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
            return signUpResponse;
        }

        public static BasicApiResponse ChangePassword(Adapter ad, int userId, string encryptedPassword)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Account_ForgotPassword", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = encryptedPassword, ParameterName = "@EncryptedPassword" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

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

        public static BasicApiResponse ForgetPassword(Adapter ad, string username, string encryptedPassword)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Account_ForgotPassword2", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = encryptedPassword, ParameterName = "@EncryptedPassword" });
                    command.Parameters.Add(new SqlParameter() { Value = username, ParameterName = "@Username" });

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

        public static LoginDetail GetLoginDetail(Adapter ad, int userIdClaim)
        {
            var response = new LoginDetail();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Account_GetLoginDetail", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userIdClaim, ParameterName = "@UserIdRequest" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.UserId = reader.GetInt32(0);
                            response.Name = reader.GetString(1);
                            response.Username = reader.GetString(2);
                            if (reader.GetString(3) != null)
                            {                                
                                response.ImageURL = reader.GetString(3);
                            }
                            else
                            {
                                response.ImageURL = "no image";
                            }
                            response.Email = reader.GetString(6);
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

        public static List<Module> GetUserModules(Adapter ad, Int32 userId)
        {
            var userModule = new List<Module>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Account_GetModuleList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var module = new Module
                            {
                                Id = reader.GetInt32(1),
                                ModuleName = reader.GetString(2)
                            };

                            userModule.Add(module);

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
            return userModule;
        }

    }
}


