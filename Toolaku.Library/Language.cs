using System;
using System.Web;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Library
{
    public class Language
    {
        //private static string _PageName = "Language";

        public static string PopulateLanguage(string FieldCode)
        {
            string result = "";

            try
            {
                string lstrProjectCode = Functions.GetCurrentProjectCode();
                //string lstrLanguageCode = GetCurrentUserLoginLanguageCode();
                //result = PopulateLanguage(lstrProjectCode, lstrLanguageCode, FieldCode);
            }
            catch (Exception e)
            {
                //string context = Common.ToStr(HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
                throw e;
            }

            return result;
        }

        public static string PopulateLanguage(string LanguageCode, string FieldCode)
        {
            string result = "";

            try
            {
                string lstrProjectCode = Functions.GetCurrentProjectCode();
                result = PopulateLanguage(lstrProjectCode, LanguageCode, FieldCode);
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return result;
        }

        private static string PopulateLanguage(string ProjectCode, string LanguageCode, string FieldCode)
        {
            string result = "";

            try
            {
                //result = clsMMultiLanguage.GetLanguage(ProjectCode, LanguageCode, FieldCode);
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return result;
        }

    }
}
