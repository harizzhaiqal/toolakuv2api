using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;


namespace Toolaku.Library
{
    public class Common
    {
        #region "Converter and format"
        /// <summary>
        /// Return integer value if obj contains numeric value
        /// else return 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int ToInt(object obj)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(obj);
            }
            catch
            {
                return 0;
            }

            return result;
        }
        /// <summary>
        /// Return Long value if obj contains numeric value
        /// else return 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static long ToLong(object obj)
        {
            long result = 0;
            try
            {
                result = Convert.ToInt64(obj);
            }
            catch
            {
                return 0;
            }

            return result;
        }
        /// <summary>
        /// Return double value if obj contains numeric value
        /// else return 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static double ToDbl(object obj)
        {
            double result = 0;
            try
            {
                if (obj != null)
                {
                    result = Convert.ToDouble(obj);
                }

            }
            catch
            {
                return 0;
            }

            return result;
        }

        public static string ToDecimal0(object obj)
        {
            string result = null;

            try
            {
                //result = string.Format(Convert.ToDouble(obj), "#,##0");
                result = string.Format("{0:#,##0}", Convert.ToDouble(obj));
            }
            catch
            {
                result = "0";
            }

            return result;
        }

        public static string ToDecimal1(object obj)
        {
            string result = null;

            try
            {
                //result = string.Format(Convert.ToDouble(obj), "#,##0.0");
                result = string.Format("{0:#,##0.0}", Convert.ToDouble(obj));
            }
            catch
            {
                result = "0.0";
            }

            return result;
        }

        public static string ToDecimal2(object obj)
        {
            string result = null;

            try
            {
                //result = string.FormatConvert.ToDouble(obj), "#,##0.00");
                result = string.Format("{0:#,##0.00}", Convert.ToDouble(obj));
            }
            catch
            {
                result = "0.00";
            }

            return result;
        }

        public static string ToDecimal3(object obj)
        {
            string result = null;

            try
            {
                //result = string.Format(Convert.ToDouble(obj), "#,##0.000");
                result = string.Format("{0:#,##0.000}", Convert.ToDouble(obj));
            }
            catch
            {
                result = "0.000";
            }

            return result;
        }

        public static string ToDecimal4(object obj)
        {
            string result = null;

            try
            {
                //result = string.Format(Convert.ToDouble(obj), "#,##0.0000");
                result = string.Format("{0:#,##0.0000}", Convert.ToDouble(obj));
            }
            catch
            {

                result = "0.0000";
            }

            return result;
        }

        public static string ToDecimal5(object obj)
        {
            string result = null;

            try
            {
                //result = string.Format(Convert.ToDouble(obj), "#,##0.0000");
                result = string.Format("{0:#,##0.00000}", Convert.ToDouble(obj));
            }
            catch
            {

                result = "0.0000";
            }

            return result;
        }

        public static string ToDate(object obj, string fmt)
        {
            string result = string.Format(Const.constDate_MinDate, fmt);
            DateTime dt = default(DateTime);
            int intYear = DateTime.Today.Year;
            int intMonth = DateTime.Today.Month;
            int intDay = DateTime.Today.Day;

            string strYear = string.Format("0000", intYear);
            string strMonth = string.Format("00", intMonth);
            string strDay = string.Format("00", intDay);

            try
            {
                dt = Convert.ToDateTime(obj);
            }
            catch
            {
                return result;
            }

            try
            {
                intYear = dt.Year;
                intMonth = dt.Month;
                intDay = dt.Day;

                //strDt = string.Format("{0}-{1}-{2}", intYear.ToString(), intMonth.ToString(), intDay.ToString());
                ////If Not IsDate(obj) Then
                ////    result = Format(clsConst.constDate_MinDate, fmt)
                ////End If

                //dt = Convert.ToDateTime(strDt);

                result = string.Format(fmt, dt);
                return result;
            }
            catch
            {

                return result;
            }
        }
        /// <summary>
        /// Format date with the default format ()
        /// </summary>
        /// <param name="obj">date obj</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ToDate(object obj)
        {
            string result = null;

            result = ToDate(obj, Const.constDate_DateFmt);

            return result;
        }

        /// <summary>
        /// Format date time with the default format ()
        /// </summary>
        /// <param name="obj">date time obj</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime ToDateTime(object obj)
        {
            DateTime result = DateTime.MinValue;

            result = ToDateTime(obj, Const.constDate_DateTimeFmt);

            return result;
        }

        private static DateTime ToDateTime(object obj, string fmt)
        {
            //string result = string.Format(clsConst.constDate_MinDateTime, fmt);
            DateTime result = DateTime.MinValue;
            System.DateTime dt = default(System.DateTime);
            string strDt = "";
            int intYear = System.DateTime.Today.Year;
            int intMonth = System.DateTime.Today.Month;
            int intDay = System.DateTime.Today.Day;
            int intHour = System.DateTime.Today.Hour;
            int intMinute = System.DateTime.Today.Minute;
            int intSecond = System.DateTime.Today.Second;

            //string strYear = intYear.ToString("0000");
            //string strMonth = intMonth.ToString("00");
            //string strDay = intDay.ToString("00");
            //string strHour = intHour.ToString("00");
            //string strMinute = intMinute.ToString("00");
            //string strSecond = intSecond.ToString("00"); 

            try
            {
                dt = Convert.ToDateTime(obj);
            }
            catch
            {
                return result;
            }

            try
            {
                intYear = dt.Year;
                intMonth = dt.Month;
                intDay = dt.Day;
                intHour = dt.Hour;
                intMinute = dt.Minute;
                intSecond = dt.Second;

                strDt = string.Format("{0}-{1}-{2} {3}:{4}:{5}", intYear.ToString(), intMonth.ToString(), intDay.ToString(), intHour.ToString(), intMinute.ToString(), intSecond.ToString());
                //If Not IsDate(obj) Then
                //    result = Format(clsConst.constDate_MinDate, fmt)
                //End If

                result = Convert.ToDateTime(strDt);

                //result = string.Format(fmt, dt);
                //result = dt.ToString (fmt );
                return result;
            }
            catch
            {
                return result;
            }
        }

        public static string ToDateTime2(object obj)
        {
            string result = "";

            result = ToDateTime2(obj, Const.constDate_yyyy_MM_DD_time);

            return result;
        }

        private static string ToDateTime2(object obj, string fmt)
        {
            string result = string.Format(Const.constDate_MinDateTime, fmt);
            System.DateTime dt = default(System.DateTime);

            string strDt = "";
            int intYear = System.DateTime.Today.Year;
            int intMonth = System.DateTime.Today.Month;
            int intDay = System.DateTime.Today.Day;
            int intHour = System.DateTime.Today.Hour;
            int intMinute = System.DateTime.Today.Minute;
            int intSecond = System.DateTime.Today.Second;

            try
            {
                dt = Convert.ToDateTime(obj);
            }
            catch
            {
                return result;
            }

            try
            {
                intYear = dt.Year;
                intMonth = dt.Month;
                intDay = dt.Day;
                intHour = dt.Hour;
                intMinute = dt.Minute;
                intSecond = dt.Second;

                // Will use intMonth >= 10 ? intMonth.ToString() : "0" + intMonth.ToString()
                // Means if month less than 10 will append 0 in front, e.g. 1 -> 01
                strDt = string.Format("{0}-{1}-{2} {3}:{4}:{5}", intYear.ToString(), intMonth >= 10 ? intMonth.ToString() : "0" + intMonth.ToString(), intDay >= 10 ? intDay.ToString() : "0" + intDay.ToString(), intHour >= 10 ? intHour.ToString() : "0" + intHour.ToString(), intMinute >= 10 ? intMinute.ToString() : "0" + intMinute.ToString(), intSecond >= 10 ? intSecond.ToString() : "0" + intSecond.ToString());

                return strDt;
            }
            catch
            {
                return result;
            }
        }

        /// <summary>
        /// If obj contains valid date, will return date value (yyyy-mm-dd HH:mm:ss) in string format
        /// </summary>
        /// <param name="obj">date obj</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ToSQLDate(object obj)
        {
            string result = null;
            string sdt = null;
            System.DateTime dt = default(System.DateTime);

            try
            {
                sdt = obj.ToString();

                if (IsEmpty(obj))
                {
                    sdt = Const.constDate_MinDate;
                }
                else if (!IsDate(sdt))
                {
                    sdt = Const.constDate_MinDate;
                }

                dt = Convert.ToDateTime(sdt);

                result = fmtDate(dt, Const.constDate_SQLDateTimeFmt);

                return result;
            }
            catch
            {
                return fmtDate(Const.constDate_MinDate, Const.constDate_SQLDateFmt);
            }
        }

        public static bool ToBool(object obj)
        {
            bool result = false;

            try
            {
                if (IsEmpty(obj))
                {
                    result = false;
                }
                else
                {
                    if (obj.ToString() == "1" || obj.ToString() == "0")
                    {
                        if (obj.ToString() == "1")
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = Convert.ToBoolean(obj.ToString());
                    }
                }

                return result;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Format date into string, based on the given format (fmt)
        /// </summary>
        /// <param name="obj">date obj</param>
        /// <param name="fmt">date format</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string fmtDate(object obj, string fmt)
        {
            string result = Const.constDate_MinDate;


            try
            {
                if (IsEmpty(obj))
                {
                    result = Const.constDate_MinDate;
                }
                else if (!IsDate(obj))
                {
                    result = Const.constDate_MinDate;
                }
                else
                {
                    //result = string.Format(fmt, obj);
                    result = Convert.ToDateTime(obj).ToString(fmt);
                }

            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// Convert parameter into string value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ToStr(object obj)
        {
            string result = "";

            try
            {
                //result = Convert.ToString(obj);
                result = ToStrWithTrim(obj);
            }
            catch
            {
                result = "";
            }
            return result;
        }

        /// <summary>
        /// Convert parameter into guid value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Guid ToGUID(object obj)
        {
            Guid result = Guid.Empty;

            try
            {
                string tempString = obj.ToString();
                result = new System.Guid(tempString);
            }
            catch
            {
                result = Guid.Empty;
            }
            return result;
        }

        public static string ToStrWithTrim(object obj)
        {
            string result = "";

            try
            {
                result = Convert.ToString(obj).TrimStart().TrimEnd();
            }
            catch
            {
                result = "";
            }
            return result;
        }

        /// <summary>
        /// Fill the left side of the value with padding char and with the max length
        /// example :
        /// value = "1"
        /// PaddingChar = "0"
        /// MaxLength = 7
        /// Result = "0000001"
        /// </summary>
        /// <param name="value"></param>
        /// <param name="PaddingChar"></param>
        /// <param name="MaxLength"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string PadNumberLeft(object value, char PaddingChar, int MaxLength)
        {
            string result = "";

            result = Convert.ToString(value);

            result = result.PadLeft(MaxLength, PaddingChar);

            return result;
        }

        /// <summary>
        /// Fill the right side of the value with padding char and with the max length
        /// example :
        /// value = "1"
        /// PaddingChar = "0"
        /// MaxLength = 7
        /// Result = "10000000"
        /// </summary>
        /// <param name="value"></param>
        /// <param name="PaddingChar"></param>
        /// <param name="MaxLength"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string PadNumberRight(object value, char PaddingChar, int MaxLength)
        {
            string result = "";

            result = Convert.ToString(value);

            result.PadRight(MaxLength, PaddingChar);

            return result;
        }

        public static string GetStringLeft(String value, int length)
        {
            if (length <= value.Length)
                return value.Substring(0, length);
            else
                return value;
        }

        public static string GetStringRight(String value, int length)
        {
            if (length <= value.Length)
                return value.Substring(value.Length - length);
            else
                return value;
        }

        #endregion

        #region "Common validator"
        public static bool IsEmpty(object obj)
        {
            bool result = false;

            try
            {
                if (obj == null)
                {
                    return true;
                }

                if (Convert.IsDBNull(obj))
                {
                    return true;
                }

                if (string.IsNullOrEmpty(ToStr(obj)))
                {
                    return true;
                }

                result = false;


            }
            catch
            {
            }

            return result;
        }

        public static bool IsNumber(object obj)
        {
            bool result = false;

            try
            {
                if (obj == null)
                {
                    return true;
                }

                if (Convert.IsDBNull(obj))
                {
                    return true;
                }

                //if (!Information.IsNumeric(obj))
                //{
                //    return false;
                //}

                result = true;


            }
            catch
            {
            }

            return result;
        }

        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt;
                DateTime.TryParse(strDate, out dt);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region "Common DB Function "
        public static string FmtConnectionStr()
        {
            return string.Format("");
        }

        public static string GetConnString(string ConnStringName)
        {
            string result = "";
            try
            {
                result = ConfigurationManager.ConnectionStrings[ConnStringName].ConnectionString;

            }
            catch
            {

                result = "";
            }
            return result;
        }

        public static SqlConnection CreateConnection(string ConnStringName)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString(ConnStringName)))
                {
                    if ((connection != null))
                    {
                        conn = connection;
                    }

                }
            }
            catch
            {
                //write into log file.
            }

            return conn;
        }

        public static string GetAppSettingString(string KeyId)
        {
            string result = "";
            try
            {
                result = ConfigurationManager.AppSettings[KeyId].ToString();
            }
            catch
            {
                result = "";
            }
            return result;
        }

        #endregion

        public static void WriteToFile(string FilePath, string FileName, string Content)
        {
            try
            {
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }

                int len;

                len = FilePath.Length;

                if (FilePath.Substring(FilePath.Length - len, len) != "\\")
                {
                    FilePath = FilePath + "\\";
                }

                FileName = FilePath + FileName;

                File.WriteAllText(FileName, Content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string[] SplitStr(string input, string[] Seperator)
        {
            string[] result;

            result = input.Split(Seperator, StringSplitOptions.None);

            return result;
        }

        public static string GenerateRandomAlphaNumeric(int WordCount)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[WordCount];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        public static string TimeAgo(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;

            if (span.Days == 1)
                return String.Format("Yesterday");
            if (span.Days > 0)
                return String.Format(dt.ToString("yyyy-MM-dd"));
            if (span.Hours > 0)
                return String.Format("{0} {1} ago",
                span.Hours, span.Hours == 1 ? "hour" : "hours");
            if (span.Minutes > 0)
                return String.Format("{0} {1} ago",
                span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
            if (span.Seconds > 5)
                return String.Format("{0} seconds ago", span.Seconds);
            if (span.Seconds <= 5)
                return "just now";
            return string.Empty;
        }

        public static string TimeAgo2(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return String.Format("{0} {1} ago",
                years, years == 1 ? "year" : "years");
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return String.Format("{0} {1} ago",
                months, months == 1 ? "month" : "months");
            }

            if (span.Days == 1)
                return String.Format("Yesterday");
            if (span.Days > 0)
                return String.Format("{0} {1} ago",
                span.Days, span.Days == 1 ? "day" : "days");
            if (span.Hours > 0)
                return String.Format("{0} {1} ago",
                span.Hours, span.Hours == 1 ? "hour" : "hours");
            if (span.Minutes > 0)
                return String.Format("{0} {1} ago",
                span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
            if (span.Seconds > 5)
                return String.Format("{0} seconds ago", span.Seconds);
            if (span.Seconds <= 5)
                return "just now";
            return string.Empty;
        }

        public static List<Dictionary<string, string>> ConvertDataTableToResultList(DataTable dt)
        {
            List<Dictionary<string, string>> Result = new List<Dictionary<string, string>>();
            Dictionary<string, string> temp = new Dictionary<string, string>();

            try
            {
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

                for (int intCtr = 0; intCtr < dt.Rows.Count; intCtr++)
                {
                    temp = new Dictionary<string, string>();
                    for (int intCtr2 = 0; intCtr2 < columnNames.Length; intCtr2++)
                    {
                        temp.Add(Language.PopulateLanguage(columnNames[intCtr2]), Common.ToStrWithTrim(dt.Rows[intCtr][columnNames[intCtr2]]));
                    }
                    Result.Add(temp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Result;
        }


    }
}
