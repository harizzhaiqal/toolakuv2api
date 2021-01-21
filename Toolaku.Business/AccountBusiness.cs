using System;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models.Account;
using Toolaku.Models.DTO;

namespace Toolaku.Business
{
    public class AccountBusiness
    {
        public static AuthenticateResult Authenticate (Adapter ad, string lowercaseLogin, string encryptedPassword)
        {
            var authenticateResult = new AuthenticateResult();

            try
            {
                authenticateResult = AccountDAL.Authenticate(ad, lowercaseLogin, encryptedPassword);
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return authenticateResult;

        }


        public static AuthenticateResult AuthenticateRelogin(Adapter ad, string Username)
        {
            var authenticateResult = new AuthenticateResult();

            try
            {
                authenticateResult = AccountDAL.AuthenticateRelogin(ad, Username);
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return authenticateResult;

        }

        //public static SignUpResponse Register(Adapter ad, SignUpRequest signUp, string encryptedPassword)
        //{
        //    var signUpResponse = new SignUpResponse();

        //    try
        //    {
        //        signUpResponse = AccountDAL.Register(ad, signUp, encryptedPassword);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //        //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
        //        //clsErrorLog.ErrorLog(context, e);
        //    }

        //    return signUpResponse;
        //}

        public static RegisterResponse Register(Adapter ad, SignUpRequest signUp, string encryptedPassword)
        {
            var signUpResponse = new RegisterResponse();

            try
            {
                var result = AccountDAL.Register(ad, signUp, encryptedPassword);

                if (result.UserId != 0)
                {
                    signUpResponse.UserId = result.UserId;
                    signUpResponse.ReturnCode = 200;
                    signUpResponse.ResponseMessage = result.ResponseMessage;

                }
                else
                {
                    signUpResponse.UserId = result.UserId;
                    signUpResponse.ReturnCode = 400;
                    signUpResponse.ResponseMessage = result.ResponseMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return signUpResponse;
        }

        public static LoginDetail GetLoginDetail(Adapter ad, int userIdClaim)
        {
            var response = new LoginDetail();

            try
            {
                response = AccountDAL.GetLoginDetail(ad, userIdClaim);

                if (response != null)
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

        public static UserModules GetUserModules(Adapter ad, Int32 userId)
        {
            var response = new UserModules();

            try
            {
                var result = AccountDAL.GetUserModules(ad, userId);

                if (response != null)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
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

        public static BasicApiResponse ChangePassword(Adapter ad, int userId, string encryptedPassword)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = AccountDAL.ChangePassword(ad, userId, encryptedPassword);

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

    }
}
