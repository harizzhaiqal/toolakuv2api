using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.HR;
using Toolaku.Models.Pagingnation;

namespace Toolaku.DataAccess
{
    public class HRDAL
    {
        //--------------GET Method--------------

        public static List<LeaveType> GetLeaveTypeByStaff(Adapter ad, int tenantStaffId, int leaveEntitlementId)
        {
            var LeaveTypes = new List<LeaveType>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetLeaveTypeByStaff", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();                    

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = tenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = leaveEntitlementId, ParameterName = "@LeaveEntitlementId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var LeaveType = new LeaveType
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            LeaveTypes.Add(LeaveType);
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
            return LeaveTypes;
        }


        public static List<RenumerationType> GetRenumerationTypeByStaff(Adapter ad, int tenantStaffId, int recurringId)
        {
            var RenumerationTypes = new List<RenumerationType>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetRenumerationTypeByStaff", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = tenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = recurringId, ParameterName = "@RecurringId" });

                    

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var RenumerationType = new RenumerationType
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            RenumerationTypes.Add(RenumerationType);
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
            return RenumerationTypes;
        }

        public static (List<TenantStaffTimesheetList>, PageInfo) GetTenantStaffTimesheetList(Adapter ad, int tenantId, string startDate, string endDate, string searchKey, Pager pager = null)
        {
            var response = new List<TenantStaffTimesheetList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffTimesheetList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = startDate, ParameterName = "@StartDate" });
                    command.Parameters.Add(new SqlParameter() { Value = endDate, ParameterName = "@EndDate" });
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
                    int FullName = reader.GetOrdinal("FullName");
                    int Mon = reader.GetOrdinal("Mon");
                    int MonWH = reader.GetOrdinal("MonWH");
                    int MonOTNormal = reader.GetOrdinal("MonOTNormal");
                    int MonOTPublic = reader.GetOrdinal("MonOTPublic");
                    int MonOTRest = reader.GetOrdinal("MonOTRest");
                    int Tue = reader.GetOrdinal("Tue");
                    int TueWH = reader.GetOrdinal("TueWH");
                    int TueOTNormal = reader.GetOrdinal("TueOTNormal");
                    int TueOTPublic = reader.GetOrdinal("TueOTPublic");
                    int TueOTRest = reader.GetOrdinal("TueOTRest");
                    int Wed = reader.GetOrdinal("Wed");
                    int WedWH = reader.GetOrdinal("WedWH");
                    int WedOTNormal = reader.GetOrdinal("WedOTNormal");
                    int WedOTPublic = reader.GetOrdinal("WedOTPublic");
                    int WedOTRest = reader.GetOrdinal("WedOTRest");
                    int Thu = reader.GetOrdinal("Thu");
                    int ThuWH = reader.GetOrdinal("ThuWH");
                    int ThuOTNormal = reader.GetOrdinal("ThuOTNormal");
                    int ThuOTPublic = reader.GetOrdinal("ThuOTPublic");
                    int ThuOTRest = reader.GetOrdinal("ThuOTRest");
                    int Fri = reader.GetOrdinal("Fri");
                    int FriWH = reader.GetOrdinal("FriWH");
                    int FriOTNormal = reader.GetOrdinal("FriOTNormal");
                    int FriOTPublic = reader.GetOrdinal("FriOTPublic");
                    int FriOTRest = reader.GetOrdinal("FriOTRest");
                    int Sat = reader.GetOrdinal("Sat");
                    int SatWH = reader.GetOrdinal("SatWH");
                    int SatOTNormal = reader.GetOrdinal("SatOTNormal");
                    int SatOTPublic = reader.GetOrdinal("SatOTPublic");
                    int SatOTRest = reader.GetOrdinal("SatOTRest");
                    int Sun = reader.GetOrdinal("Sun");
                    int SunWH = reader.GetOrdinal("SunWH");
                    int SunOTNormal = reader.GetOrdinal("SunOTNormal");
                    int SunOTPublic = reader.GetOrdinal("SunOTPublic");
                    int SunOTRest = reader.GetOrdinal("SunOTRest");
                    int MonTimesheetId = reader.GetOrdinal("MonTimesheetId");
                    int TueTimesheetId = reader.GetOrdinal("TueTimesheetId");
                    int WedTimesheetId = reader.GetOrdinal("WedTimesheetId");
                    int ThuTimesheetId = reader.GetOrdinal("ThuTimesheetId");
                    int FriTimesheetId = reader.GetOrdinal("FriTimesheetId");
                    int SatTimesheetId = reader.GetOrdinal("SatTimesheetId");
                    int SunTimesheetId = reader.GetOrdinal("SunTimesheetId");
                    int MonLeave = reader.GetOrdinal("MonLeave");
                    int TueLeave = reader.GetOrdinal("TueLeave");
                    int WedLeave = reader.GetOrdinal("WedLeave");
                    int ThuLeave = reader.GetOrdinal("ThuLeave");
                    int FriLeave = reader.GetOrdinal("FriLeave");
                    int SatLeave = reader.GetOrdinal("SatLeave");
                    int SunLeave = reader.GetOrdinal("SunLeave");



                        while (reader.Read())
                        {
                            var result = new TenantStaffTimesheetList
                            {


                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                FullName = reader.GetString(FullName),

                                Mon = Convert.ToString(Convert.ToDateTime(reader.GetString(Mon)).ToString("dd MMM yyyy")),
                                MonWH = Convert.ToInt32(reader.GetValue(MonWH)),
                                MonOTNormal = Convert.ToInt32(reader.GetValue(MonOTNormal)),
                                MonOTPublic = Convert.ToInt32(reader.GetValue(MonOTPublic)),
                                MonOTRest = Convert.ToInt32(reader.GetValue(MonOTRest)),

                                Tue = Convert.ToString(Convert.ToDateTime(reader.GetString(Tue)).ToString("dd MMM yyyy")),
                                TueWH = Convert.ToInt32(reader.GetValue(TueWH)),
                                TueOTNormal = Convert.ToInt32(reader.GetValue(TueOTNormal)),
                                TueOTPublic = Convert.ToInt32(reader.GetValue(TueOTPublic)),
                                TueOTRest = Convert.ToInt32(reader.GetValue(TueOTRest)),

                                Wed = Convert.ToString(Convert.ToDateTime(reader.GetString(Wed)).ToString("dd MMM yyyy")),
                                WedWH = Convert.ToInt32(reader.GetValue(WedWH)),
                                WedOTNormal = Convert.ToInt32(reader.GetValue(WedOTNormal)),
                                WedOTPublic = Convert.ToInt32(reader.GetValue(WedOTPublic)),
                                WedOTRest = Convert.ToInt32(reader.GetValue(WedOTRest)),

                                Thu = Convert.ToString(Convert.ToDateTime(reader.GetString(Thu)).ToString("dd MMM yyyy")),
                                ThuWH = Convert.ToInt32(reader.GetValue(ThuWH)),
                                ThuOTNormal = Convert.ToInt32(reader.GetValue(ThuOTNormal)),
                                ThuOTPublic = Convert.ToInt32(reader.GetValue(ThuOTPublic)),
                                ThuOTRest = Convert.ToInt32(reader.GetValue(ThuOTRest)),

                                Fri = Convert.ToString(Convert.ToDateTime(reader.GetString(Fri)).ToString("dd MMM yyyy")),
                                FriWH = Convert.ToInt32(reader.GetValue(FriWH)),
                                FriOTNormal = Convert.ToInt32(reader.GetValue(FriOTNormal)),
                                FriOTPublic = Convert.ToInt32(reader.GetValue(FriOTPublic)),
                                FriOTRest = Convert.ToInt32(reader.GetValue(FriOTRest)),

                                Sat = Convert.ToString(Convert.ToDateTime(reader.GetString(Sat)).ToString("dd MMM yyyy")),
                                SatWH = Convert.ToInt32(reader.GetValue(SatWH)),
                                SatOTNormal = Convert.ToInt32(reader.GetValue(SatOTNormal)),
                                SatOTPublic = Convert.ToInt32(reader.GetValue(SatOTPublic)),
                                SatOTRest = Convert.ToInt32(reader.GetValue(SatOTRest)),

                                Sun = Convert.ToString(Convert.ToDateTime(reader.GetString(Sun)).ToString("dd MMM yyyy")),
                                SunWH = Convert.ToInt32(reader.GetValue(SunWH)),
                                SunOTNormal = Convert.ToInt32(reader.GetValue(SunOTNormal)),
                                SunOTPublic = Convert.ToInt32(reader.GetValue(SunOTPublic)),
                                SunOTRest = Convert.ToInt32(reader.GetValue(SunOTRest)),

                                TotalWH = Convert.ToInt32(reader.GetValue(MonWH)) + Convert.ToInt32(reader.GetValue(TueWH)) + Convert.ToInt32(reader.GetValue(WedWH)) + Convert.ToInt32(reader.GetValue(ThuWH)) + Convert.ToInt32(reader.GetValue(FriWH)) + Convert.ToInt32(reader.GetValue(SatWH)) + Convert.ToInt32(reader.GetValue(SunWH)),
                                TotalOTNormal = Convert.ToInt32(reader.GetValue(MonOTNormal)) + Convert.ToInt32(reader.GetValue(TueOTNormal)) + Convert.ToInt32(reader.GetValue(WedOTNormal)) + Convert.ToInt32(reader.GetValue(ThuOTNormal)) + Convert.ToInt32(reader.GetValue(FriOTNormal)) + Convert.ToInt32(reader.GetValue(SatOTNormal)) + Convert.ToInt32(reader.GetValue(SunOTNormal)),
                                TotalOTPublic = Convert.ToInt32(reader.GetValue(MonOTPublic)) + Convert.ToInt32(reader.GetValue(TueOTPublic)) + Convert.ToInt32(reader.GetValue(WedOTPublic)) + Convert.ToInt32(reader.GetValue(ThuOTPublic)) + Convert.ToInt32(reader.GetValue(FriOTPublic)) + Convert.ToInt32(reader.GetValue(SatOTPublic)) + Convert.ToInt32(reader.GetValue(SunOTPublic)),
                                TotalOTRest = Convert.ToInt32(reader.GetValue(MonOTRest)) + Convert.ToInt32(reader.GetValue(TueOTRest)) + Convert.ToInt32(reader.GetValue(WedOTRest)) + Convert.ToInt32(reader.GetValue(ThuOTRest)) + Convert.ToInt32(reader.GetValue(FriOTRest)) + Convert.ToInt32(reader.GetValue(SatOTRest)) + Convert.ToInt32(reader.GetValue(SunOTRest)),


                                MonTimesheetId = Convert.ToInt32(reader.GetValue(MonTimesheetId)),
                                TueTimesheetId = Convert.ToInt32(reader.GetValue(TueTimesheetId)),
                                WedTimesheetId = Convert.ToInt32(reader.GetValue(WedTimesheetId)),
                                ThuTimesheetId = Convert.ToInt32(reader.GetValue(ThuTimesheetId)),
                                FriTimesheetId = Convert.ToInt32(reader.GetValue(FriTimesheetId)),
                                SatTimesheetId = Convert.ToInt32(reader.GetValue(SatTimesheetId)),
                                SunTimesheetId = Convert.ToInt32(reader.GetValue(SunTimesheetId)),

                                MonLeave = Convert.ToInt32(reader.GetValue(MonLeave)),
                                TueLeave = Convert.ToInt32(reader.GetValue(TueLeave)),
                                WedLeave = Convert.ToInt32(reader.GetValue(WedLeave)),
                                ThuLeave = Convert.ToInt32(reader.GetValue(ThuLeave)),
                                FriLeave = Convert.ToInt32(reader.GetValue(FriLeave)),
                                SatLeave = Convert.ToInt32(reader.GetValue(SatLeave)),
                                SunLeave = Convert.ToInt32(reader.GetValue(SunLeave)),

                                TotalLeave = Convert.ToInt32(reader.GetValue(MonLeave)) +
                                Convert.ToInt32(reader.GetValue(TueLeave)) +
                                Convert.ToInt32(reader.GetValue(WedLeave)) +
                                Convert.ToInt32(reader.GetValue(ThuLeave)) +
                                Convert.ToInt32(reader.GetValue(FriLeave)) +
                                Convert.ToInt32(reader.GetValue(SatLeave)) +
                                Convert.ToInt32(reader.GetValue(SunLeave)),


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

        public static TenantStaffTimesheetDetails GetTenantStaffTimesheetDetails(Adapter ad, int timesheetId)
        {
            var response = new TenantStaffTimesheetDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffTimesheetDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = timesheetId, ParameterName = "@TimesheetId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int TenantStaffId = reader.GetOrdinal("TenantStaffId");
                        int Date = reader.GetOrdinal("Date");
                        int TimeIn = reader.GetOrdinal("TimeIn");
                        int TimeOut = reader.GetOrdinal("TimeOut");
                        int OTIn = reader.GetOrdinal("OTIn");
                        int OTOut = reader.GetOrdinal("OTOut");
                        int IsEnable = reader.GetOrdinal("IsEnable");
                        int DayTypeId = reader.GetOrdinal("DayTypeId");
                        int LeaveTypeId = reader.GetOrdinal("LeaveTypeId");
                        int LeaveDateFrom = reader.GetOrdinal("LeaveDateFrom");
                        int LeaveFromDurationTypeId = reader.GetOrdinal("LeaveFromDurationTypeId");
                        int LeaveDateTo = reader.GetOrdinal("LeaveDateTo");
                        int LeaveToDurationTypeId = reader.GetOrdinal("LeaveToDurationTypeId");
                        int Reason = reader.GetOrdinal("Reason");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.TenantStaffId = Convert.ToInt32(reader.GetValue(TenantStaffId));
                            //response.Date = "";
                            response.Date = (reader.GetValue(Date) == DBNull.Value) ? "" : Convert.ToString(Convert.ToDateTime(reader.GetValue(Date)).ToString("dd MMM yyyy"));
                            //response.TimeIn = "";
                            response.TimeIn = (reader.GetValue(TimeIn) == DBNull.Value) ? "" : Convert.ToString(Convert.ToDateTime(reader.GetValue(TimeIn)).ToString("HH:mm"));
                            //response.TimeIn = reader.GetString(TimeIn);
                            //response.TimeOut = "";
                            response.TimeOut = (reader.GetValue(TimeOut) == DBNull.Value) ? "" : Convert.ToString(Convert.ToDateTime(reader.GetValue(TimeOut)).ToString("HH:mm"));
                            //response.TimeOut = reader.GetString(TimeOut);
                            //response.OTIn = "";
                            response.OTIn = (reader.GetValue(OTIn) == DBNull.Value) ? "" :  Convert.ToString(Convert.ToDateTime(reader.GetValue(OTIn)).ToString("HH:mm"));
                            //response.OTIn = reader.GetString(OTIn);
                            //response.OTOut = "";
                            response.OTOut = (reader.GetValue(OTOut) == DBNull.Value) ? "" : Convert.ToString(Convert.ToDateTime(reader.GetValue(OTOut)).ToString("HH:mm"));
                            //response.OTOut = reader.GetString(OTOut);
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                            response.DayTypeId = Convert.ToInt32(reader.GetValue(DayTypeId));
                            response.LeaveTypeId = Convert.ToInt32(reader.GetValue(LeaveTypeId));
                            //response.LeaveDateFrom = "";
                            response.LeaveDateFrom = (reader.GetValue(LeaveDateFrom) == DBNull.Value) ? "" : Convert.ToString(Convert.ToDateTime(reader.GetValue(LeaveDateFrom)).ToString("dd MMM yyyy"));
                            response.LeaveFromDurationTypeId = Convert.ToInt32(reader.GetValue(LeaveFromDurationTypeId));
                            //response.LeaveDateFrom = "";
                            response.LeaveDateTo = (reader.GetValue(LeaveDateTo) == DBNull.Value) ? "" : Convert.ToString(Convert.ToDateTime(reader.GetValue(LeaveDateTo)).ToString("dd MMM yyyy"));
                            response.LeaveToDurationTypeId = Convert.ToInt32(reader.GetValue(LeaveToDurationTypeId));
                            response.Reason = reader.GetString(Reason);        
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
        public static TenantStaffRequirementDetails GetTenantStaffRequirementDetails(Adapter ad, int tenantStaffId)
        {
            var response = new TenantStaffRequirementDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffRequirementDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantStaffId, ParameterName = "@TenantStaffId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int TenantStaffId = reader.GetOrdinal("TenantStaffId");
                        int EPFCotribute = reader.GetOrdinal("EPFCotribute");
                        int EPFNo = reader.GetOrdinal("EPFNo");
                        int EPFEmployeePercentage = reader.GetOrdinal("EPFEmployeePercentage");
                        int EPFEmployerPercentage = reader.GetOrdinal("EPFEmployerPercentage");
                        int PCBNo = reader.GetOrdinal("PCBNo");
                        int SocsoNo = reader.GetOrdinal("SocsoNo");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.TenantStaffId = Convert.ToInt32(reader.GetValue(TenantStaffId));
                            response.EPFCotribute = Convert.ToInt32(reader.GetValue(EPFCotribute));
                            response.EPFNo = reader.GetString(EPFNo);
                            response.EPFEmployeePercentage = Convert.ToDouble(reader.GetValue(EPFEmployeePercentage));
                            response.EPFEmployerPercentage = Convert.ToDouble(reader.GetValue(EPFEmployerPercentage));
                            response.PCBNo = reader.GetString(PCBNo);
                            response.SocsoNo = reader.GetString(SocsoNo);
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
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



        public static DashboardEmploymentStatus GetDashboardEmploymentStatus(Adapter ad, int tenantId)
        {
            var response = new DashboardEmploymentStatus();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DashboardEmploymentStatus", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int TenantName = reader.GetOrdinal("TenantName");
                        int CountPermanent = reader.GetOrdinal("CountPermanent");
                        int CountContract = reader.GetOrdinal("CountContract");
                        int CountParttime = reader.GetOrdinal("CountParttime");
                        int CountIntern = reader.GetOrdinal("CountIntern");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.TenantName = reader.GetString(TenantName);
                            response.CountPermanent = Convert.ToInt32(reader.GetValue(CountPermanent));
                            response.CountContract = Convert.ToInt32(reader.GetValue(CountContract));
                            response.CountParttime = Convert.ToInt32(reader.GetValue(CountParttime));
                            response.CountIntern = Convert.ToInt32(reader.GetValue(CountIntern));
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



        public static (List<TenantStaffReportMontlyStaff>, TenantStaffReportMontlyStaffHeader) GetTenantStaffReportMontlyStaff(Adapter ad, int tenantStaffId, int month, int year)
        {
            var response = new List<TenantStaffReportMontlyStaff>();
            var response2 = new TenantStaffReportMontlyStaffHeader();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffReportMontlyStaff", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = month, ParameterName = "@Month" });
                    command.Parameters.Add(new SqlParameter() { Value = year, ParameterName = "@Year" });

                    

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Day = reader.GetOrdinal("Day");
                        int DateDisplay = reader.GetOrdinal("DateDisplay");
                        int DayType = reader.GetOrdinal("DayType");
                        int TimeIn = reader.GetOrdinal("TimeIn");
                        int TimeOut = reader.GetOrdinal("TimeOut");
                        int WorkingHours = reader.GetOrdinal("WorkingHours");
                        int OTTimeIn = reader.GetOrdinal("OTTimeIn");
                        int OTTimeOut = reader.GetOrdinal("OTTimeOut");
                        int OTHours = reader.GetOrdinal("OTHours");
                        int PaidLeave = reader.GetOrdinal("PaidLeave");
                        int UnpaidLeave = reader.GetOrdinal("UnpaidLeave");

                        while (reader.Read())
                        {
                            var result = new TenantStaffReportMontlyStaff
                            {
                                Day = Convert.ToInt32(reader.GetValue(Day)),
                                DateDisplay = Convert.ToString(Convert.ToDateTime(reader.GetValue(DateDisplay)).ToString("dd MMM yyyy")),
                                DayType = (reader.GetValue(DayType) == DBNull.Value) ? "" : reader.GetString(DayType),
                               // DayTypeId = (reader.GetValue(DayType) == DBNull.Value) ? 0 :  Convert.ToInt32(reader.GetValue(DayTypeId)),
                                TimeIn = (reader.GetValue(TimeIn) == DBNull.Value) ? "--:--" : Convert.ToString(Convert.ToDateTime(reader.GetValue(TimeIn)).ToString("HH:mm")),
                                TimeOut = (reader.GetValue(TimeOut) == DBNull.Value) ? "--:--" : Convert.ToString(Convert.ToDateTime(reader.GetValue(TimeOut)).ToString("HH:mm")),
                                WorkingHours = Convert.ToInt32(reader.GetValue(WorkingHours)),
                                OTTimeIn = (reader.GetValue(OTTimeIn) == DBNull.Value) ? "--:--" : Convert.ToString(Convert.ToDateTime(reader.GetValue(OTTimeIn)).ToString("HH:mm")),
                                OTTimeOut = (reader.GetValue(OTTimeOut) == DBNull.Value) ? "--:--" : Convert.ToString(Convert.ToDateTime(reader.GetValue(OTTimeOut)).ToString("HH:mm")),
                                OTHours = Convert.ToInt32(reader.GetValue(OTHours)),
                                PaidLeave = Convert.ToDouble(reader.GetValue(PaidLeave)),
                                UnpaidLeave = Convert.ToDouble(reader.GetValue(UnpaidLeave)),
                            };
                            response.Add(result);
                        }

                        reader.NextResult();

                        while (reader.Read())
                        {
                            response2.Id = Convert.ToInt32(reader.GetValue(0));
                            response2.FullName = reader.GetString(1);
                            response2.EmployeeNo = reader.GetString(2);
                            response2.Position = reader.GetString(3);
                            response2.TenantName = reader.GetString(4);
                            response2.LogoUrl = reader.GetString(5);
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





        public static (List<TenantStaffReportMontlyDetails>, TenantStaffReportMontlyStaffHeader) GetTenantStaffReportMontlyDetails(Adapter ad, int tenantId, int month, int year)
        {
            var response = new List<TenantStaffReportMontlyDetails>();
            var response2 = new TenantStaffReportMontlyStaffHeader();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffReportMontlyDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = month, ParameterName = "@Month" });
                    command.Parameters.Add(new SqlParameter() { Value = year, ParameterName = "@Year" });



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int FullName = reader.GetOrdinal("FullName");
                        int EmployeeNo = reader.GetOrdinal("EmployeeNo");
                        int Position = reader.GetOrdinal("Position");
                        int Salary = reader.GetOrdinal("Salary");
                        int WorkingHours = reader.GetOrdinal("WorkingHours");
                        int OTHoursNormal = reader.GetOrdinal("OTHoursNormal");
                        int OTHoursPublic = reader.GetOrdinal("OTHoursPublic");
                        int OTHoursRest = reader.GetOrdinal("OTHoursRest");
                        int PaidLeave = reader.GetOrdinal("PaidLeave");
                        int UnpaidLeave = reader.GetOrdinal("UnpaidLeave");

                        while (reader.Read())
                        {
                            var result = new TenantStaffReportMontlyDetails
                            {

                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                FullName = (reader.GetValue(FullName) == DBNull.Value) ? "" : reader.GetString(FullName),
                                EmployeeNo = (reader.GetValue(EmployeeNo) == DBNull.Value) ? "" : reader.GetString(EmployeeNo),
                                Position = (reader.GetValue(Position) == DBNull.Value) ? "" : reader.GetString(Position),
                                Salary = (reader.GetValue(Salary) == DBNull.Value) ? 0 : Convert.ToDouble(reader.GetValue(Salary)),
                                WorkingHours = Convert.ToInt32(reader.GetValue(WorkingHours)),
                                OTHoursNormal = Convert.ToInt32(reader.GetValue(OTHoursNormal)),
                                OTHoursPublic = Convert.ToInt32(reader.GetValue(OTHoursPublic)),
                                OTHoursRest = Convert.ToInt32(reader.GetValue(OTHoursRest)),
                                PaidLeave = Convert.ToDouble(reader.GetValue(PaidLeave)),
                                UnpaidLeave = Convert.ToDouble(reader.GetValue(UnpaidLeave)),
                            };
                            response.Add(result);
                        }

                        reader.NextResult();

                        while (reader.Read())
                        {
                            response2.TenantName = reader.GetString(0);
                            response2.LogoUrl = reader.GetString(1);
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


        
        public static TenantStaffReportMontlyDetails GetTenantStaffReportMontlyDetails_OLD(Adapter ad, int tenantId, int month, int year)
        {
            var response = new TenantStaffReportMontlyDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffReportMontlyDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = month, ParameterName = "@Month" });
                    command.Parameters.Add(new SqlParameter() { Value = year, ParameterName = "@Year" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int DayTypeId = reader.GetOrdinal("DayTypeId");
                        int DayType = reader.GetOrdinal("DayType");
                        int FullName = reader.GetOrdinal("FullName");
                        int EmployeeNo = reader.GetOrdinal("EmployeeNo");
                        int Position = reader.GetOrdinal("Position");
                        int Salary = reader.GetOrdinal("Salary");
                        int WorkingHours = reader.GetOrdinal("WorkingHours");
                        int OTHoursNormal = reader.GetOrdinal("OTHoursNormal");
                        int OTHoursPublic = reader.GetOrdinal("OTHoursPublic");
                        int OTHoursRest = reader.GetOrdinal("OTHoursRest");
                        int PaidLeave = reader.GetOrdinal("PaidLeave");
                        int UnpaidLeave = reader.GetOrdinal("UnpaidLeave");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.FullName = reader.GetString(FullName);
                            response.EmployeeNo = reader.GetString(EmployeeNo);
                            response.Position = reader.GetString(Position);
                            response.Salary = Convert.ToDouble(reader.GetValue(Salary));
                            response.WorkingHours = Convert.ToInt32(reader.GetValue(WorkingHours));
                            response.OTHoursNormal = Convert.ToInt32(reader.GetValue(OTHoursNormal));
                            response.OTHoursPublic = Convert.ToInt32(reader.GetValue(OTHoursPublic));
                            response.OTHoursRest = Convert.ToInt32(reader.GetValue(OTHoursRest));
                            response.PaidLeave = Convert.ToDouble(reader.GetValue(PaidLeave));
                            response.UnpaidLeave = Convert.ToDouble(reader.GetValue(UnpaidLeave));
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
        public static (List<TenantStaffReportList>, PageInfo) GetTenantStaffReportList(Adapter ad, int tenantId, int month, int year, string searchKey, Pager pager = null)
        {
            var response = new List<TenantStaffReportList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffReportList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = month, ParameterName = "@Month" });
                    command.Parameters.Add(new SqlParameter() { Value = year, ParameterName = "@Year" });
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
                        int FullName = reader.GetOrdinal("FullName");
                        int EmployeeNo = reader.GetOrdinal("EmployeeNo");
                        int Position = reader.GetOrdinal("Position");
                        int Salary = reader.GetOrdinal("Salary");
                        int WorkingHours = reader.GetOrdinal("WorkingHours");
                        int OTNormal = reader.GetOrdinal("OTNormal");
                        int OTPublic = reader.GetOrdinal("OTPublic");
                        int OTRest = reader.GetOrdinal("OTRest");
                        int LeaveDuration = reader.GetOrdinal("LeaveDuration");

                        while (reader.Read())
                        {   
                            var result = new TenantStaffReportList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                FullName = reader.GetString(FullName),
                                EmployeeNo = (reader.GetValue(EmployeeNo) == DBNull.Value) ? "" : reader.GetString(EmployeeNo),
                                Position = (reader.GetValue(EmployeeNo) == DBNull.Value) ? "" : reader.GetString(Position),
                                Salary = (reader.GetValue(Salary) == DBNull.Value) ? 0: Convert.ToDouble(reader.GetValue(Salary)),
                                WorkingHours = Convert.ToInt32(reader.GetValue(WorkingHours)),
                                OTNormal = Convert.ToInt32(reader.GetValue(OTNormal)),
                                OTPublic = Convert.ToInt32(reader.GetValue(OTPublic)),
                                OTRest = Convert.ToInt32(reader.GetValue(OTRest)),
                                LeaveDuration = Convert.ToDouble(reader.GetValue(LeaveDuration)),
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
        public static TenantStaffRenumerationDetails GetTenantStaffRenumerationDetails(Adapter ad, int tenantStaffId)
        {
            var response = new TenantStaffRenumerationDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffRenumerationDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = tenantStaffId, ParameterName = "@TenantStaffId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {         
                        int Id = reader.GetOrdinal("Id");
                        int TenantStaffId = reader.GetOrdinal("TenantStaffId");
                        int Overtime = reader.GetOrdinal("Overtime");
                        int OTRateNormal = reader.GetOrdinal("OTRateNormal");
                        int OTRateRest = reader.GetOrdinal("OTRateRest");
                        int OTRatePublic = reader.GetOrdinal("OTRatePublic");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.TenantStaffId = Convert.ToInt32(reader.GetValue(TenantStaffId));
                            response.Overtime = Convert.ToInt32(reader.GetValue(Overtime));
                            response.OTRateNormal = Convert.ToDouble(reader.GetValue(OTRateNormal));
                            response.OTRateRest = Convert.ToDouble(reader.GetValue(OTRateRest));
                            response.OTRatePublic = Convert.ToDouble(reader.GetValue(OTRatePublic));
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
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

        public static (List<TenantStaffRecurringList>, PageInfo) GetTenantStaffRecurringList(Adapter ad, int tenantStaffId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantStaffRecurringList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffRecurringList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantStaffId, ParameterName = "@TenantStaffId" });
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
                        int RecurringName = reader.GetOrdinal("RecurringName");
                        int Amount = reader.GetOrdinal("Amount");
                        int FrequencyName = reader.GetOrdinal("FrequencyName");

                        while (reader.Read())
                        {
                            var result = new TenantStaffRecurringList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                RecurringName = reader.GetString(RecurringName),
                                FrequencyName = reader.GetString(FrequencyName),
                                Amount = Convert.ToDouble(reader.GetValue(Amount)),
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

        public static TenantStaffRecurringDetails GetTenantStaffRecurringDetails(Adapter ad, int id)
        {
            var response = new TenantStaffRecurringDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffRecurringDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int TenantStaffId = reader.GetOrdinal("TenantStaffId");
                        int RenumerationId = reader.GetOrdinal("RenumerationId");
                        int Amount = reader.GetOrdinal("Amount");
                        int FrequencyId = reader.GetOrdinal("FrequencyId");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.TenantStaffId = Convert.ToInt32(reader.GetValue(TenantStaffId));
                            response.RenumerationId = Convert.ToInt32(reader.GetValue(RenumerationId));
                            response.Amount = Convert.ToDouble(reader.GetValue(Amount));
                            response.FrequencyId = Convert.ToInt32(reader.GetValue(FrequencyId));
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
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
        public static List<TenantStaffMontlyDetails> GetTenantStaffMontlyDetails(Adapter ad, int tenantStaffId, int month, int year)
        {
            var response = new List<TenantStaffMontlyDetails>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffMontlyDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = tenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = month, ParameterName = "@Month" });
                    command.Parameters.Add(new SqlParameter() { Value = year, ParameterName = "@Year" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Day = reader.GetOrdinal("Day");
                        int DateDisplay = reader.GetOrdinal("DateDisplay");
                        int TimesheetId = reader.GetOrdinal("TimesheetId");
                        int WorkingHours = reader.GetOrdinal("WorkingHours");
                        int OTNormal = reader.GetOrdinal("OTNormal");
                        int OTPublic = reader.GetOrdinal("OTPublic");
                        int OTRest = reader.GetOrdinal("OTRest");
                        int LeaveDuration = reader.GetOrdinal("LeaveDuration");

                        while (reader.Read())
                        {
                            var result = new TenantStaffMontlyDetails
                            {
                                Day = Convert.ToInt32(reader.GetValue(Day)),
                                TimesheetId = Convert.ToInt32(reader.GetValue(TimesheetId)),
                                DateDisplay = Convert.ToString(Convert.ToDateTime(reader.GetValue(DateDisplay)).ToString("yyyy-MM-dd")),
                                WorkingHours = Convert.ToInt32(reader.GetValue(WorkingHours)),
                                OTNormal = Convert.ToInt32(reader.GetValue(OTNormal)),
                                OTPublic = Convert.ToInt32(reader.GetValue(OTPublic)),
                                OTRest = Convert.ToInt32(reader.GetValue(OTRest)),
                                LeaveDuration = Convert.ToDouble(reader.GetValue(LeaveDuration)),
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

        
        

        public static (List<TenantStaffLeaveEntitlementList>, PageInfo) GetTenantStaffLeaveEntitlementList(Adapter ad, int tenantStaffId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantStaffLeaveEntitlementList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffLeaveEntitlementList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantStaffId, ParameterName = "@TenantStaffId" });
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
                        int LeaveTypeName = reader.GetOrdinal("LeaveTypeName");
                        int Entitle = reader.GetOrdinal("Entitle");
                        int CarryForward = reader.GetOrdinal("CarryForward");
                        int DaysTaken = reader.GetOrdinal("DaysTaken");
                        int Balance = reader.GetOrdinal("Balance");

                        while (reader.Read())
                        {
                            var result = new TenantStaffLeaveEntitlementList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                LeaveTypeName = reader.GetString(LeaveTypeName),
                                Entitle = Convert.ToInt32(reader.GetValue(Entitle)),
                                CarryForward = Convert.ToInt32(reader.GetValue(CarryForward)),
                                DaysTaken = Convert.ToInt32(reader.GetValue(DaysTaken)),
                                Balance = Convert.ToInt32(reader.GetValue(Balance)),
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

        public static TenantStaffLeaveEntitlementDetails GetTenantStaffLeaveEntitlementDetails(Adapter ad, int id)
        {
            var response = new TenantStaffLeaveEntitlementDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffLeaveEntitlementDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int TenantStaffId = reader.GetOrdinal("TenantStaffId");
                        int LeaveTypeId = reader.GetOrdinal("LeaveTypeId");
                        int Entitle = reader.GetOrdinal("Entitle");
                        int IsEnable = reader.GetOrdinal("IsEnable");
                        int CarryForward = reader.GetOrdinal("CarryForward");                        

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.TenantStaffId = Convert.ToInt32(reader.GetValue(TenantStaffId));
                            response.LeaveTypeId = Convert.ToInt32(reader.GetValue(LeaveTypeId));
                            response.Entitle = Convert.ToInt32(reader.GetValue(Entitle));
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                            response.CarryForward = Convert.ToInt32(reader.GetValue(CarryForward));
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

        public static TenantStaffLeaveDetails GetTenantStaffLeaveDetails(Adapter ad, int id)
        {
            var response = new TenantStaffLeaveDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffLeaveDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int TenantStaffId = reader.GetOrdinal("TenantStaffId");
                        int LeaveTypeId = reader.GetOrdinal("LeaveTypeId");
                        int LeaveDate = reader.GetOrdinal("LeaveDate");
                        int LeaveDurationTypeId = reader.GetOrdinal("LeaveDurationTypeId");
                        int Reason = reader.GetOrdinal("Reason");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id)); ;
                            response.TenantStaffId = Convert.ToInt32(reader.GetValue(TenantStaffId));
                            response.LeaveTypeId = Convert.ToInt32(reader.GetValue(LeaveTypeId));
                            response.LeaveDate = reader.GetString(LeaveDate);
                            response.LeaveDurationTypeId = Convert.ToInt32(reader.GetValue(LeaveDurationTypeId));
                            response.Reason = reader.GetString(Reason);
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
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

        public static TenantStaffEmploymentDetails GetTenantStaffEmploymentDetails(Adapter ad, int tenantStaffId)
        {
            var response = new TenantStaffEmploymentDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffEmploymentDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = tenantStaffId, ParameterName = "@TenantStaffId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int TenantStaffId = reader.GetOrdinal("TenantStaffId");
                        int JoinDate = reader.GetOrdinal("JoinDate");
                        int Position = reader.GetOrdinal("Position");
                        int EmploymentStatusId = reader.GetOrdinal("EmploymentStatusId");
                        int Salary = reader.GetOrdinal("Salary");
                        int FrequencyId = reader.GetOrdinal("FrequencyId");
                        int IsEnable = reader.GetOrdinal("IsEnable");
                        int EmployeeNo = reader.GetOrdinal("EmployeeNo");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.TenantStaffId = Convert.ToInt32(reader.GetValue(TenantStaffId));
                            response.JoinDate = Convert.ToString(Convert.ToDateTime(reader.GetValue(JoinDate)).ToString("dd MMM yyyy"));
                            response.Position = reader.GetString(Position);
                            response.EmploymentStatusId = Convert.ToInt32(reader.GetValue(EmploymentStatusId));
                            response.Salary = Convert.ToDouble(reader.GetValue(Salary));
                            response.FrequencyId = Convert.ToInt32(reader.GetValue(FrequencyId));
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                            response.EmployeeNo = reader.GetString(EmployeeNo);
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

        public static TenantStaffDetails GetTenantStaffDetails(Adapter ad, int id)
        {
            var response = new TenantStaffDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int TenantId = reader.GetOrdinal("TenantId");
                        int UserId = reader.GetOrdinal("UserId");
                        int FullName = reader.GetOrdinal("FullName");
                        int Email = reader.GetOrdinal("Email");
                        int MobileNo = reader.GetOrdinal("MobileNo");
                        int DocumentTypeId = reader.GetOrdinal("DocumentTypeId");
                        int DocumentNo = reader.GetOrdinal("DocumentNo");
                        int GenderId = reader.GetOrdinal("GenderId");
                        int DOB = reader.GetOrdinal("DOB");
                        int NationalityId = reader.GetOrdinal("NationalityId");
                        int MaritalStatusId = reader.GetOrdinal("MaritalStatusId");
                        int Address = reader.GetOrdinal("Address");
                        int Address2 = reader.GetOrdinal("Address2");
                        int City = reader.GetOrdinal("City");
                        int Poscode = reader.GetOrdinal("Poscode");
                        int CountryId = reader.GetOrdinal("CountryId");
                        int StateId = reader.GetOrdinal("StateId");
                        int EmergencyContact = reader.GetOrdinal("EmergencyContact");
                        int EmergencyContactNo = reader.GetOrdinal("EmergencyContactNo");
                        int IsEnable = reader.GetOrdinal("IsEnable");
                        int ImageUrl = reader.GetOrdinal("ImageUrl");                       


                        while (reader.Read())
                        {
                            response.Id =  Convert.ToInt32(reader.GetValue(Id));
                            response.TenantId =  Convert.ToInt32(reader.GetValue(TenantId));
                            response.UserId =  Convert.ToInt32(reader.GetValue(UserId));
                            response.FullName = reader.GetString(FullName);
                            response.Email = reader.GetString(Email);
                            response.MobileNo = reader.GetString(MobileNo);
                            response.DocumentTypeId =  Convert.ToInt32(reader.GetValue(DocumentTypeId));
                            response.DocumentNo = reader.GetString(DocumentNo);
                            response.GenderId =  Convert.ToInt32(reader.GetValue(GenderId));
                            response.DOB = Convert.ToString(Convert.ToDateTime(reader.GetValue(DOB)).ToString("dd MMM yyyy"));
                            response.NationalityId =  Convert.ToInt32(reader.GetValue(NationalityId));
                            response.MaritalStatusId = Convert.ToInt32(reader.GetValue(MaritalStatusId));
                            response.Address = reader.GetString(Address);
                            response.Address2 = reader.GetString(Address2);
                            response.City = reader.GetString(City);
                            response.Poscode = reader.GetString(Poscode);
                            response.CountryId =  Convert.ToInt32(reader.GetValue(CountryId));
                            response.StateId =  Convert.ToInt32(reader.GetValue(StateId));
                            response.EmergencyContact = reader.GetString(EmergencyContact);
                            response.EmergencyContactNo = reader.GetString(EmergencyContactNo);
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                            response.ImageUrl = reader.GetString(ImageUrl);                            
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

        public static (List<TenantStaffList>, PageInfo) GetTenantStaffList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new List<TenantStaffList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetTenantStaffList", ad.SQLConn, ad.SQLTran))
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
                        int EmployeeNo = reader.GetOrdinal("EmployeeNo");
                        int FullName = reader.GetOrdinal("FullName");
                        int Email = reader.GetOrdinal("Email");
                        int MobileNo = reader.GetOrdinal("MobileNo");


                        while (reader.Read())
                        {
                            var result = new TenantStaffList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                EmployeeNo = reader.GetString(EmployeeNo),
                                FullName = reader.GetString(FullName),
                                Email = reader.GetString(Email),
                                MobileNo = reader.GetString(MobileNo),
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




        //--------------PUT Method--------------
        public static BasicApiResponse UpdateTenantStaffTimesheet(Adapter ad, UpdateTenantStaffTimesheet request, int creatorUserId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateTenantStaffTimesheet", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    /*
                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TimeIn, ParameterName = "@TimeIn" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TimeOut, ParameterName = "@TimeOut" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTIn, ParameterName = "@OTIn" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTOut, ParameterName = "@OTOut" });
                    command.Parameters.Add(new SqlParameter() { Value = request.DayTypeId, ParameterName = "@DayTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveTypeId, ParameterName = "@LeaveTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveDateFrom, ParameterName = "@LeaveDateFrom" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveFromDurationTypeId, ParameterName = "@LeaveFromDurationTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveDateTo, ParameterName = "@LeaveDateTo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveToDurationTypeId, ParameterName = "@LeaveToDurationTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Reason, ParameterName = "@Reason" });
                    command.Parameters.Add(new SqlParameter() { Value = request.IsEnable, ParameterName = "@IsEnable" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId " });
                    */
                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date == "" ? null : request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TimeIn == "" ? null : request.TimeIn, ParameterName = "@TimeIn" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TimeOut == "" ? null : request.TimeOut, ParameterName = "@TimeOut" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTIn == "" ? null : request.OTIn, ParameterName = "@OTIn" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTOut == "" ? null : request.OTOut, ParameterName = "@OTOut" });
                    command.Parameters.Add(new SqlParameter() { Value = request.DayTypeId, ParameterName = "@DayTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveTypeId, ParameterName = "@LeaveTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveDateFrom == "" ? null : request.LeaveDateFrom, ParameterName = "@LeaveDateFrom" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveFromDurationTypeId, ParameterName = "@LeaveFromDurationTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveDateTo == "" ? null : request.LeaveDateTo, ParameterName = "@LeaveDateTo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveToDurationTypeId, ParameterName = "@LeaveToDurationTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Reason, ParameterName = "@Reason" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });
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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }
        public static BasicApiResponse UpdateTenantStaffRequirement(Adapter ad, UpdateTenantStaffRequirement request)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateTenantStaffRequirement", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EPFCotribute, ParameterName = "@EPFCotribute" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EPFNo, ParameterName = "@EPFNo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EPFEmployeePercentage, ParameterName = "@EPFEmployeePercentage" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EPFEmployerPercentage, ParameterName = "@EPFEmployerPercentage" });
                    command.Parameters.Add(new SqlParameter() { Value = request.PCBNo, ParameterName = "@PCBNo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.SocsoNo, ParameterName = "@SocsoNo" });
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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }
        public static BasicApiResponse UpdateTenantStaffRenumeration(Adapter ad, UpdateTenantStaffRenumeration request)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateTenantStaffRenumeration", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Overtime, ParameterName = "@Overtime" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTRateNormal, ParameterName = "@OTRateNormal" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTRateRest, ParameterName = "@OTRateRest" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTRatePublic, ParameterName = "@OTRatePublic" });
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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }
        public static BasicApiResponse UpdateTenantStaffRecurring(Adapter ad, UpdateTenantStaffRecurring request)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateTenantStaffRecurring", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.RenumerationId, ParameterName = "@RenumerationId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.FrequencyId, ParameterName = "@FrequencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Amount, ParameterName = "@Amount" });
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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }
        public static BasicApiResponse UpdateTenantStaffLeaveEntitlement(Adapter ad, UpdateTenantStaffLeaveEntitlement request)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateTenantStaffLeaveEntitlement", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveTypeId, ParameterName = "@LeaveTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Entitle, ParameterName = "@Entitle" });
                    command.Parameters.Add(new SqlParameter() { Value = request.IsEnable, ParameterName = "@IsEnable" });
                    command.Parameters.Add(new SqlParameter() { Value = request.CarryForward, ParameterName = "@CarryForward" });

                    

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
        public static BasicApiResponse UpdateTenantStaffLeaveApplication(Adapter ad, UpdateTenantStaffLeaveApplication request)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateTenantStaffLeaveApplication", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveTypeId, ParameterName = "@LeaveTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveDate, ParameterName = "@LeaveDate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveDurationTypeId, ParameterName = "@LeaveDurationTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Reason, ParameterName = "@Reason" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TimeSheetId, ParameterName = "@TimeSheetId" });
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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse UpdateTenantStaffEmployment(Adapter ad, UpdateTenantStaffEmployment request)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateTenantStaffEmployment", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.JoinDate, ParameterName = "@JoinDate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Position, ParameterName = "@Position" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EmploymentStatusId, ParameterName = "@EmploymentStatusId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Salary, ParameterName = "@Salary" });
                    command.Parameters.Add(new SqlParameter() { Value = request.FrequencyId, ParameterName = "@FrequencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EmployeeNo, ParameterName = "@EmployeeNo" });
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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }
        public static BasicApiResponse UpdateTenantStaff(Adapter ad, UpdateTenantStaff request)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateTenantStaff", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.UserId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.FullName, ParameterName = "@FullName" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Email, ParameterName = "@Email" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MobileNo, ParameterName = "@MobileNo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.DocumentTypeId, ParameterName = "@DocumentTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.DocumentNo, ParameterName = "@DocumentNo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.GenderId, ParameterName = "@GenderId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.DOB, ParameterName = "@DOB" });
                    command.Parameters.Add(new SqlParameter() { Value = request.NationalityId, ParameterName = "@NationalityId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MaritalStatusId, ParameterName = "@MaritalStatusId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Address, ParameterName = "@Address" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Address2, ParameterName = "@Address2" });
                    command.Parameters.Add(new SqlParameter() { Value = request.City, ParameterName = "@City" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Poscode, ParameterName = "@Poscode" });
                    command.Parameters.Add(new SqlParameter() { Value = request.CountryId, ParameterName = "@CountryId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.StateId, ParameterName = "@StateId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EmergencyContact, ParameterName = "@EmergencyContact" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EmergencyContactNo, ParameterName = "@EmergencyContactNo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.IsEnable, ParameterName = "@IsEnable" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ImageUrl, ParameterName = "@ImageUrl" });
                    
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


        //--------------POST Method--------------
        public static PostApiResponse InsertTenantStaffTimesheet(Adapter ad, InsertTenantStaffTimesheet request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertTenantStaffTimesheet", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date == "" ? null : request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TimeIn == "" ? null : request.TimeIn, ParameterName = "@TimeIn" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TimeOut == "" ? null : request.TimeOut, ParameterName = "@TimeOut" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTIn == "" ? null : request.OTIn, ParameterName = "@OTIn" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTOut == "" ? null : request.OTOut, ParameterName = "@OTOut" });
                    command.Parameters.Add(new SqlParameter() { Value = request.DayTypeId, ParameterName = "@DayTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveTypeId, ParameterName = "@LeaveTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveDateFrom == "" ? null : request.LeaveDateFrom, ParameterName = "@LeaveDateFrom" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveFromDurationTypeId, ParameterName = "@LeaveFromDurationTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveDateTo == "" ? null : request.LeaveDateTo, ParameterName = "@LeaveDateTo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveToDurationTypeId, ParameterName = "@LeaveToDurationTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Reason, ParameterName = "@Reason" });
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
        public static PostApiResponse InsertTenantStaffRequirement(Adapter ad, InsertTenantStaffRequirement request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertTenantStaffRequirement", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EPFCotribute, ParameterName = "@EPFCotribute" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EPFNo, ParameterName = "@EPFNo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EPFEmployeePercentage, ParameterName = "@EPFEmployeePercentage" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EPFEmployerPercentage, ParameterName = "@EPFEmployerPercentage" });
                    command.Parameters.Add(new SqlParameter() { Value = request.PCBNo, ParameterName = "@PCBNo" });
                    command.Parameters.Add(new SqlParameter() { Value = request.SocsoNo, ParameterName = "@SocsoNo" });
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
        public static PostApiResponse InsertTenantStaffRenumeration(Adapter ad, InsertTenantStaffRenumeration request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertTenantStaffRenumeration", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Overtime, ParameterName = "@Overtime" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTRateNormal, ParameterName = "@OTRateNormal" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTRateRest, ParameterName = "@OTRateRest" });
                    command.Parameters.Add(new SqlParameter() { Value = request.OTRatePublic, ParameterName = "@OTRatePublic" });
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

        public static PostApiResponse InsertTenantStaffRecurring(Adapter ad, InsertTenantStaffRecurring request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertTenantStaffRecurring", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.RenumerationId, ParameterName = "@RenumerationId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.FrequencyId, ParameterName = "@FrequencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Amount, ParameterName = "@Amount" });
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

        public static PostApiResponse InsertTenantStaffLeaveEntitlement(Adapter ad, InsertTenantStaffLeaveEntitlement request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertTenantStaffLeaveEntitlement", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveTypeId, ParameterName = "@LeaveTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Entitle, ParameterName = "@Entitle" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.CarryForward, ParameterName = "@CarryForward" });

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


        public static PostApiResponse InsertTenantStaffLeaveApplication(Adapter ad, InsertTenantStaffLeaveApplication request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertTenantStaffLeaveApplication", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveTypeId, ParameterName = "@LeaveTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveDate, ParameterName = "@LeaveDate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.LeaveDurationTypeId, ParameterName = "@LeaveDurationTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Reason, ParameterName = "@Reason" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TimeSheetId, ParameterName = "@TimeSheetId" });
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

        public static PostApiResponse InsertTenantStaffEmployment(Adapter ad, InsertTenantStaffEmployment request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertTenantStaffEmployment", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.TenantStaffId, ParameterName = "@TenantStaffId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.JoinDate, ParameterName = "@JoinDate" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Position, ParameterName = "@Position" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EmploymentStatusId, ParameterName = "@EmploymentStatusId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Salary, ParameterName = "@Salary" });
                    command.Parameters.Add(new SqlParameter() { Value = request.FrequencyId, ParameterName = "@FrequencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.EmployeeNo, ParameterName = "@EmployeeNo" });
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

        public static PostApiResponse InsertTenantStaff(Adapter ad, InsertTenantStaff request, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertTenantStaff", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                   command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                   command.Parameters.Add(new SqlParameter() { Value = request.UserId, ParameterName = "@UserId" });
                   command.Parameters.Add(new SqlParameter() { Value = request.FullName, ParameterName = "@FullName" });
                   command.Parameters.Add(new SqlParameter() { Value = request.Email, ParameterName = "@Email" });
                   command.Parameters.Add(new SqlParameter() { Value = request.MobileNo, ParameterName = "@MobileNo" });
                   command.Parameters.Add(new SqlParameter() { Value = request.DocumentTypeId, ParameterName = "@DocumentTypeId" });
                   command.Parameters.Add(new SqlParameter() { Value = request.DocumentNo, ParameterName = "@DocumentNo" });
                   command.Parameters.Add(new SqlParameter() { Value = request.GenderId, ParameterName = "@GenderId" });
                   command.Parameters.Add(new SqlParameter() { Value = request.DOB, ParameterName = "@DOB" });
                   command.Parameters.Add(new SqlParameter() { Value = request.NationalityId, ParameterName = "@NationalityId" });
                   command.Parameters.Add(new SqlParameter() { Value = request.MaritalStatusId, ParameterName = "@MaritalStatusId" });
                   command.Parameters.Add(new SqlParameter() { Value = request.Address, ParameterName = "@Address" });
                   command.Parameters.Add(new SqlParameter() { Value = request.Address2, ParameterName = "@Address2" });
                   command.Parameters.Add(new SqlParameter() { Value = request.City, ParameterName = "@City" });
                   command.Parameters.Add(new SqlParameter() { Value = request.Poscode, ParameterName = "@Poscode" });
                   command.Parameters.Add(new SqlParameter() { Value = request.CountryId, ParameterName = "@CountryId" });
                   command.Parameters.Add(new SqlParameter() { Value = request.StateId, ParameterName = "@StateId" });
                   command.Parameters.Add(new SqlParameter() { Value = request.EmergencyContact, ParameterName = "@EmergencyContact" });
                   command.Parameters.Add(new SqlParameter() { Value = request.EmergencyContactNo, ParameterName = "@EmergencyContactNo" });
                   command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });
                   command.Parameters.Add(new SqlParameter() { Value = request.ImageUrl, ParameterName = "@ImageUrl" });

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

        public static BasicApiResponse DeleteTenantStaffLeaveEntitlement(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteTenantStaffLeaveEntitlement", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = ids, ParameterName = "@LeaveEntitlementId" });
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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse DeleteTenantStaffRequirement(Adapter ad, int RequirementId, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteTenantStaffRequirement", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = RequirementId, ParameterName = "@RequirementId" });
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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse DeleteTenantStaffRecurring(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteTenantStaffRecurring", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = ids, ParameterName = "@RecurringId" });
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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }
        public static BasicApiResponse DeleteTenantStaff(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteTenantStaff", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ids, ParameterName = "@TenantStaffId" });
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
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse DeleteLeaveApplicationByTimeSheet(Adapter ad, int id)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteLeaveApplicationByTimeSheet", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@TimeSheetId" });

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
