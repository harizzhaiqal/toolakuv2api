using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.HR;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.HR
{

    public class TenantStaffDetails
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentNo { get; set; }
        public int GenderId { get; set; }
        public string DOB { get; set; }
        public int NationalityId { get; set; }
        public int MaritalStatusId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Poscode { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyContactNo { get; set; }
        public int IsEnable { get; set; }
        public string ImageUrl { get; set; }
        
    }


    public class TenantStaffEmploymentDetails
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public string JoinDate { get; set; }
        public string Position { get; set; }
        public int EmploymentStatusId { get; set; }
        public double Salary { get; set; }
        public int FrequencyId { get; set; }
        public int IsEnable { get; set; }
        public string EmployeeNo { get; set; }
    }

    public class TenantStaffLeaveDetails
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveDate { get; set; }
        public int LeaveDurationTypeId { get; set; }
        public string Reason { get; set; }
        public int IsEnable { get; set; }
    }

    public class TenantStaffLeaveEntitlementDetails
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public int LeaveTypeId { get; set; }
        public int Entitle { get; set; }
        public int IsEnable { get; set; }
        public int CarryForward { get; set; }
        
    }

    public class TenantStaffLeaveEntitlementList
    {
        public int Id { get; set; }
        public string LeaveTypeName { get; set; }
        public int Entitle { get; set; }
        public int CarryForward { get; set; }
        public int DaysTaken { get; set; }
        public int Balance { get; set; }
    }

    public class TenantStaffLeaveEntitlementListDT : ResponseBase
    {
        public List<TenantStaffLeaveEntitlementList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class TenantStaffList
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }

    public class TenantStaffListDT : ResponseBase
    {
        public List<TenantStaffList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class TenantStaffMontlyDetailsDT : ResponseBase
    {
        public List<TenantStaffMontlyDetails> list { get; set; }
    }

    public class TenantStaffMontlyDetails
    {
        public int Day { get; set; }
        public string DateDisplay { get; set; }
        public int TimesheetId { get; set; }        
        public int WorkingHours { get; set; }
        public int OTNormal { get; set; }
        public int OTPublic { get; set; }
        public int OTRest { get; set; }
        public double LeaveDuration { get; set; }
    }

    public class TenantStaffRecurringDetails
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public int RenumerationId { get; set; }
        public double Amount { get; set; }
        public int FrequencyId { get; set; }
        public int IsEnable { get; set; }
    }

    public class TenantStaffRecurringList
    {
        public int Id { get; set; }
        public string RecurringName { get; set; }
        public double Amount { get; set; }
        public string FrequencyName { get; set; }
    }

    public class TenantStaffRecurringListDT : ResponseBase
    {
        public List<TenantStaffRecurringList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class TenantStaffRenumerationDetails
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public int Overtime { get; set; }
        public double OTRateNormal { get; set; }
        public double OTRateRest { get; set; }
        public double OTRatePublic { get; set; }
        public int IsEnable { get; set; }
    }

    public class TenantStaffReportList
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmployeeNo { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public int WorkingHours { get; set; }
        public int OTNormal { get; set; }
        public int OTPublic { get; set; }
        public int OTRest { get; set; }
        public double LeaveDuration { get; set; }
    }

    public class TenantStaffReportListDT : ResponseBase
    {
        public List<TenantStaffReportList> list { get; set; }

        public PageInfo pageInfo { get; set; }
    }


    public class TenantStaffReportMontlyDetails
    {
        public int Id { get; set; }
        public int DayTypeId { get; set; }
        public string DayType { get; set; }
        public string FullName { get; set; }
        public string EmployeeNo { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public int WorkingHours { get; set; }
        public int OTHoursNormal { get; set; }
        public int OTHoursPublic { get; set; }
        public int OTHoursRest { get; set; }
        public double PaidLeave { get; set; }
        public double UnpaidLeave { get; set; }
    }

    public class TenantStaffReportMontlyStaff
    {
        public int Day { get; set; }
        public string DateDisplay { get; set; }
        public string DayType { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public int WorkingHours { get; set; }
        public string OTTimeIn { get; set; }
        public string OTTimeOut { get; set; }
        public int OTHours { get; set; }
        public double PaidLeave { get; set; }
        public double UnpaidLeave { get; set; }
    }

    public class TenantStaffReportMontlyStaffHeader
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmployeeNo { get; set; }
        public string Position { get; set; }
        public string TenantName { get; set; }
        public string LogoUrl { get; set; }
    }

    public class TenantStaffReportMontlyStaffDT : ResponseBase
    {
        public List<TenantStaffReportMontlyStaff> list { get; set; }

        public TenantStaffReportMontlyStaffHeader header { get; set; }
    }

    public class TenantStaffReportMontlyDetailsDT : ResponseBase
    {
        public List<TenantStaffReportMontlyDetails> list { get; set; }

        public TenantStaffReportMontlyStaffHeader header { get; set; }
    }



    public class TenantStaffRequirementDetails
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public int EPFCotribute { get; set; }
        public string EPFNo { get; set; }
        public double EPFEmployeePercentage { get; set; }
        public double EPFEmployerPercentage { get; set; }
        public string PCBNo { get; set; }
        public string SocsoNo { get; set; }
        public int IsEnable { get; set; }
    }


    public class DashboardEmploymentStatus
    {
        public int Id { get; set; }
        public string TenantName { get; set; }
        public int CountPermanent { get; set; }
        public int CountContract { get; set; }
        public int CountParttime { get; set; }
        public int CountIntern { get; set; }
    }

    public class TenantStaffTimesheetDetails
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public string Date { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string OTIn { get; set; }
        public string OTOut { get; set; }
        public int IsEnable { get; set; }
        public int DayTypeId { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveDateFrom { get; set; }
        public int LeaveFromDurationTypeId { get; set; }
        public string LeaveDateTo { get; set; }
        public int LeaveToDurationTypeId { get; set; }
        public string Reason { get; set; }
    }

    public class TenantStaffTimesheetList
    {        
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Mon { get; set; }
        public int MonWH { get; set; }
        public int MonOTNormal { get; set; }
        public int MonOTPublic { get; set; }
        public int MonOTRest { get; set; }
        public string Tue { get; set; }
        public int TueWH { get; set; }
        public int TueOTNormal { get; set; }
        public int TueOTPublic { get; set; }
        public int TueOTRest { get; set; }
        public string Wed { get; set; }
        public int WedWH { get; set; }
        public int WedOTNormal { get; set; }
        public int WedOTPublic { get; set; }
        public int WedOTRest { get; set; }
        public string Thu { get; set; }
        public int ThuWH { get; set; }
        public int ThuOTNormal { get; set; }
        public int ThuOTPublic { get; set; }
        public int ThuOTRest { get; set; }
        public string Fri { get; set; }
        public int FriWH { get; set; }
        public int FriOTNormal { get; set; }
        public int FriOTPublic { get; set; }
        public int FriOTRest { get; set; }
        public string Sat { get; set; }
        public int SatWH { get; set; }
        public int SatOTNormal { get; set; }
        public int SatOTPublic { get; set; }
        public int SatOTRest { get; set; }
        public string Sun { get; set; }
        public int SunWH { get; set; }
        public int SunOTNormal { get; set; }
        public int SunOTPublic { get; set; }
        public int SunOTRest { get; set; }
        public int TotalWH { get; set; }
        public int TotalOTNormal { get; set; }
        public int TotalOTPublic { get; set; }
        public int TotalOTRest { get; set; }

        public int MonTimesheetId { get; set; }
        public int TueTimesheetId { get; set; }
        public int WedTimesheetId { get; set; }
        public int ThuTimesheetId { get; set; }
        public int FriTimesheetId { get; set; }
        public int SatTimesheetId { get; set; }
        public int SunTimesheetId { get; set; }
        public int MonLeave { get; set; }
        public int TueLeave { get; set; }
        public int WedLeave { get; set; }
        public int ThuLeave { get; set; }
        public int FriLeave { get; set; }
        public int SatLeave { get; set; }
        public int SunLeave { get; set; }
        public int TotalLeave { get; set; }

    }

    public class TenantStaffTimesheetListDT : ResponseBase
    {
        public List<TenantStaffTimesheetList> list { get; set; }
        public PageInfo pageInfo { get; set; }
    }

    public class InsertTenantStaff
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentNo { get; set; }
        public int GenderId { get; set; }
        public string DOB { get; set; }
        public int NationalityId { get; set; }
        public string MaritalStatusId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Poscode { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyContactNo { get; set; }
        public string ImageUrl { get; set; }
    }

    public class InsertTenantStaffEmployment
    {
        public int TenantStaffId { get; set; }
        public string JoinDate { get; set; }
        public string Position { get; set; }
        public int EmploymentStatusId { get; set; }
        public string Salary { get; set; }
        public int FrequencyId { get; set; }
        public string EmployeeNo { get; set; }
    }

    public class InsertTenantStaffLeaveApplication
    {
        public int TenantStaffId { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveDate { get; set; }
        public int LeaveDurationTypeId { get; set; }
        public string Reason { get; set; }
        public int TimeSheetId { get; set; }
    }
    public class InsertTenantStaffLeaveEntitlement
    {
        public int TenantStaffId { get; set; }
        public int LeaveTypeId { get; set; }
        public int Entitle { get; set; }
        public int CarryForward { get; set; }
    }

    public class InsertTenantStaffRecurring
    {
        public int TenantStaffId { get; set; }
        public int RenumerationId { get; set; }
        public int FrequencyId { get; set; }
        public double Amount { get; set; }
    }


    public class InsertTenantStaffRenumeration
    {
        public int TenantStaffId { get; set; }
        public int Overtime { get; set; }
        public double OTRateNormal { get; set; }
        public double OTRateRest { get; set; }
        public double OTRatePublic { get; set; }
    }

    public class InsertTenantStaffRequirement
    {
        public int TenantStaffId { get; set; }
        public int EPFCotribute { get; set; }
        public string EPFNo { get; set; }
        public double EPFEmployeePercentage { get; set; }
        public double EPFEmployerPercentage { get; set; }
        public string PCBNo { get; set; }
        public string SocsoNo { get; set; }
    }


    public class InsertTenantStaffTimesheet
    {
        public int TenantStaffId { get; set; }
        public string Date { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string OTIn { get; set; }
        public string OTOut { get; set; }
        public int DayTypeId { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveDateFrom { get; set; }
        public int LeaveFromDurationTypeId { get; set; }
        public string LeaveDateTo { get; set; }
        public int LeaveToDurationTypeId { get; set; }
        public string Reason { get; set; }
    }


    public class UpdateTenantStaff
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentNo { get; set; }
        public int GenderId { get; set; }
        public string DOB { get; set; }
        public int NationalityId { get; set; }
        public string MaritalStatusId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Poscode { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyContactNo { get; set; }
        public int IsEnable { get; set; }
        public string ImageUrl { get; set; }
    }



    public class UpdateTenantStaffEmployment
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public string JoinDate { get; set; }
        public string Position { get; set; }
        public int EmploymentStatusId { get; set; }
        public string Salary { get; set; }
        public int FrequencyId { get; set; }
        public string EmployeeNo { get; set; }
        public int IsEnable { get; set; }
    }

    public class UpdateTenantStaffLeaveApplication
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveDate { get; set; }
        public int LeaveDurationTypeId { get; set; }
        public string Reason { get; set; }
        public int TimeSheetId { get; set; }
        public int IsEnable { get; set; }
    }

    public class UpdateTenantStaffLeaveEntitlement
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public int LeaveTypeId { get; set; }
        public int Entitle { get; set; }
        public int IsEnable { get; set; }
        public int CarryForward { get; set; }
    }

    public class UpdateTenantStaffRecurring
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public int RenumerationId { get; set; }
        public int FrequencyId { get; set; }
        public double Amount { get; set; }
        public int IsEnable { get; set; }
    }

    public class UpdateTenantStaffRenumeration
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public int Overtime { get; set; }
        public double OTRateNormal { get; set; }
        public double OTRateRest { get; set; }
        public double OTRatePublic { get; set; }
        public int IsEnable { get; set; }
    }

    public class UpdateTenantStaffRequirement
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public int EPFCotribute { get; set; }
        public string EPFNo { get; set; }
        public double EPFEmployeePercentage { get; set; }
        public double EPFEmployerPercentage { get; set; }
        public string PCBNo { get; set; }
        public string SocsoNo { get; set; }
        public int IsEnable { get; set; }
    }


    public class UpdateTenantStaffTimesheet
    {
        public int Id { get; set; }
        public int TenantStaffId { get; set; }
        public string Date { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string OTIn { get; set; }
        public string OTOut { get; set; }
        public int DayTypeId { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveDateFrom { get; set; }
        public int LeaveFromDurationTypeId { get; set; }
        public string LeaveDateTo { get; set; }
        public int LeaveToDurationTypeId { get; set; }
        public string Reason { get; set; }
        public int IsEnable { get; set; }
    }

    public class ListIdToDelete
    {
        public int id { get; set; }
    }

    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class LeaveTypes : ResponseBase
    {
        public List<LeaveType> result { get; set; }
    }

    public class RenumerationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class RenumerationTypes : ResponseBase
    {
        public List<RenumerationType> result { get; set; }
    }
}