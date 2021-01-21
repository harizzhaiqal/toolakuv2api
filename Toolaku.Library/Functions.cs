using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Toolaku.Library
{
    public class Functions
    {
        //private static string _PageName = "Functions";

        public static string GetCurrentProjectCode()
        {
            string lstrProjectCode = Common.GetAppSettingString(Const.constWebConfig_ProjectCode);
            return lstrProjectCode;
        }

        public static string GetCurrentHost()
        {
            string lstrHost = Common.GetAppSettingString(Const.constWebConfig_Host);
            return lstrHost;
        }

        public static string GetParameterValue(string KeyType)
        {
            string result = "";
            try
            {
                using (Adapter ad = new Adapter())
                {
                    //result = Common.ToStr(clsMParameter.GetColumn_KeyValue_ByPK(ad, KeyType));
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //clsErrorLog.ErrorLog(_PageName, ex);
            }
            return result;
        }

        public static bool DataTableIsNotNothing(DataTable dt)
        {
            try
            {
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //clsErrorLog.ErrorLog(_PageName, ex);
            }
            return false;
        }

        public static string GetCalenderDefaultStartDate()
        {
            return Common.ToSQLDate("2012-01-01");
        }

        public static string GetCurrentDate()
        {
            return Common.ToSQLDate(DateTime.Today);
        }

        public static string GetCurrentDateTime()
        {
            return Common.ToSQLDate(DateTime.Now);
        }

        public static System.DateTime GetMonth_FirstDay(int pYear, int pMonth)
        {

            DateTime lResult = new DateTime(pYear, pMonth, 1);
            return lResult;

        }

        public static System.DateTime GetMonth_LastDay(int pYear, int pMonth)
        {

            DateTime lCurrentMonth = new DateTime(pYear, pMonth, 1);
            DateTime lNextMonthFirstDay = lCurrentMonth.AddMonths(1);
            System.DateTime lResult = lNextMonthFirstDay.AddDays(-1);
            return lResult;

        }

        public static string GetDataTableColumeValueByRow(DataTable pDataTable, int RowIndex, string ColumnName)
        {
            string result = "";
            try
            {
                if (DataTableIsNotNothing(pDataTable))
                {
                    if (Common.IsEmpty(pDataTable.Rows[RowIndex][ColumnName]))
                    {
                        result = "";
                    }
                    else
                    {
                        result = Common.ToStr(pDataTable.Rows[RowIndex][ColumnName]).Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //clsErrorLog.ErrorLog(_PageName, ex);
            }
            return result;
        }

        public static Guid GetDataTableGUIDColumeValueByRow(DataTable pDataTable, int RowIndex, string ColumnName)
        {
            Guid result = Guid.Empty;
            try
            {
                if (DataTableIsNotNothing(pDataTable))
                {
                    result = Common.ToGUID(pDataTable.Rows[RowIndex][ColumnName]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //clsErrorLog.ErrorLog(_PageName, ex);
            }
            return result;
        }

    }
}
