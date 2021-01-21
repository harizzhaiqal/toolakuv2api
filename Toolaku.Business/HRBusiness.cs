using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models;
using Toolaku.Models.DTO;
using Toolaku.Models.HR;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Business
{
    public class HRBusiness
    {
        //--------------GET Method--------------

        public static LeaveTypes GetLeaveTypeByStaff(Adapter ad, int tenantStaffId, int leaveEntitlementId)
        {
            var response = new LeaveTypes();
            try
            {
                var result = HRDAL.GetLeaveTypeByStaff(ad, tenantStaffId, leaveEntitlementId);
                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.result = result;
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

        public static RenumerationTypes GetRenumerationTypeByStaff(Adapter ad, int tenantStaffId, int recurringId)
        {
            var response = new RenumerationTypes();
            try
            {
                var result = HRDAL.GetRenumerationTypeByStaff(ad, tenantStaffId, recurringId);
                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.result = result;
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

        public static TenantStaffTimesheetListDT GetTenantStaffTimesheetList(Adapter ad, int tenantId, string startDate, string endDate, string searchKey, Pager pager = null)
        {
            var response = new TenantStaffTimesheetListDT();
            try
            {
                var result = HRDAL.GetTenantStaffTimesheetList(ad, tenantId, startDate, endDate, searchKey, pager);
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

        public static TenantStaffTimesheetDetails GetTenantStaffTimesheetDetails(Adapter ad, int timesheetId)
        {
            var response = new TenantStaffTimesheetDetails();
            try
            {
                response = HRDAL.GetTenantStaffTimesheetDetails(ad, timesheetId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static TenantStaffRequirementDetails GetTenantStaffRequirementDetails(Adapter ad, int tenantStaffId)
        {
            var response = new TenantStaffRequirementDetails();
            try
            {
                response = HRDAL.GetTenantStaffRequirementDetails(ad, tenantStaffId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }


        public static DashboardEmploymentStatus GetDashboardEmploymentStatus(Adapter ad, int tenantId)
        {
            var response = new DashboardEmploymentStatus();
            try
            {
                response = HRDAL.GetDashboardEmploymentStatus(ad, tenantId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static TenantStaffReportMontlyStaffDT GetTenantStaffReportMontlyStaff(Adapter ad, int tenantStaffId, int month, int year)
        {
            var response = new TenantStaffReportMontlyStaffDT();
            try
            {
                var result = HRDAL.GetTenantStaffReportMontlyStaff(ad, tenantStaffId, month, year);
                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
                    response.header = result.Item2;
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


        public static TenantStaffReportMontlyDetailsDT GetTenantStaffReportMontlyDetails(Adapter ad, int tenantId, int month, int year)
        {
            var response = new TenantStaffReportMontlyDetailsDT();
            try
            {
                var result = HRDAL.GetTenantStaffReportMontlyDetails(ad, tenantId, month, year);
                if (result.Item1.Count != 0)
                {
                    response.list = result.Item1;
                    response.header = result.Item2;
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
        /*
        public static TenantStaffReportMontlyDetails GetTenantStaffReportMontlyDetailsOLD(Adapter ad, int tenantId, int month, int year)
        {
            var response = new TenantStaffReportMontlyDetails();
            try
            {
                response = HRDAL.GetTenantStaffReportMontlyDetails(ad, tenantId, month, year);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }
        */

        public static TenantStaffReportListDT GetTenantStaffReportList(Adapter ad, int tenantId, int month, int year, string searchKey, Pager pager = null)
        {
            var response = new TenantStaffReportListDT();
            try
            {
                var result = HRDAL.GetTenantStaffReportList(ad, tenantId, month, year, searchKey, pager);
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

        public static TenantStaffRenumerationDetails GetTenantStaffRenumerationDetails(Adapter ad, int tenantStaffId)
        {
            var response = new TenantStaffRenumerationDetails();
            try
            {
                response = HRDAL.GetTenantStaffRenumerationDetails(ad, tenantStaffId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static TenantStaffRecurringListDT GetTenantStaffRecurringList(Adapter ad, int tenantStaffId, string searchKey, Pager pager = null)
        {
            var response = new TenantStaffRecurringListDT();
            try
            {
                var result = HRDAL.GetTenantStaffRecurringList(ad, tenantStaffId, searchKey, pager);
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


        public static TenantStaffRecurringDetails GetTenantStaffRecurringDetails(Adapter ad, int id)
        {
            var response = new TenantStaffRecurringDetails();
            try
            {
                response = HRDAL.GetTenantStaffRecurringDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static TenantStaffMontlyDetailsDT GetTenantStaffMontlyDetails(Adapter ad, int tenantStaffId, int month, int year)
        {
            var response = new TenantStaffMontlyDetailsDT();
            try
            {
                var result = HRDAL.GetTenantStaffMontlyDetails(ad, tenantStaffId, month, year);
                if (result.Count != 0)
                {
                    response.list = result;
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


        public static TenantStaffLeaveEntitlementListDT GetTenantStaffLeaveEntitlementList(Adapter ad, int tenantStaffId, string searchKey, Pager pager = null)
        {
            var response = new TenantStaffLeaveEntitlementListDT();
            try
            {
                var result = HRDAL.GetTenantStaffLeaveEntitlementList(ad, tenantStaffId, searchKey, pager);
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

        public static TenantStaffLeaveEntitlementDetails GetTenantStaffLeaveEntitlementDetails(Adapter ad, int id)
        {
            var response = new TenantStaffLeaveEntitlementDetails();
            try
            {
                response = HRDAL.GetTenantStaffLeaveEntitlementDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static TenantStaffLeaveDetails GetTenantStaffLeaveDetails(Adapter ad, int id)
        {
            var response = new TenantStaffLeaveDetails();
            try
            {
                response = HRDAL.GetTenantStaffLeaveDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static TenantStaffEmploymentDetails GetTenantStaffEmploymentDetails(Adapter ad, int id)
        {
            var response = new TenantStaffEmploymentDetails();
            try
            {
                response = HRDAL.GetTenantStaffEmploymentDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static TenantStaffDetails GetTenantStaffDetails(Adapter ad, int id)
        {
            var response = new TenantStaffDetails();
            try
            {
                response = HRDAL.GetTenantStaffDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public static TenantStaffListDT GetTenantStaffList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new TenantStaffListDT();
            try
            {
                var result = HRDAL.GetTenantStaffList(ad, tenantId, searchKey, pager);
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




        //--------------PUT Method--------------
        public static BasicApiResponse UpdateTenantStaffTimesheet(Adapter ad, UpdateTenantStaffTimesheet request, int creatorUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = HRDAL.UpdateTenantStaffTimesheet(ad, request, creatorUserId);

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



        public static BasicApiResponse UpdateTenantStaffRequirement(Adapter ad, UpdateTenantStaffRequirement request)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = HRDAL.UpdateTenantStaffRequirement(ad, request);

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


        public static BasicApiResponse UpdateTenantStaffRenumeration(Adapter ad, UpdateTenantStaffRenumeration request)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = HRDAL.UpdateTenantStaffRenumeration(ad, request);

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

        public static BasicApiResponse UpdateTenantStaffRecurring(Adapter ad, UpdateTenantStaffRecurring request)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = HRDAL.UpdateTenantStaffRecurring(ad, request);

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

        public static BasicApiResponse UpdateTenantStaffLeaveEntitlement(Adapter ad, UpdateTenantStaffLeaveEntitlement request)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = HRDAL.UpdateTenantStaffLeaveEntitlement(ad, request);

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


        public static BasicApiResponse UpdateTenantStaffLeaveApplication(Adapter ad, UpdateTenantStaffLeaveApplication request)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = HRDAL.UpdateTenantStaffLeaveApplication(ad, request);

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

        public static BasicApiResponse UpdateTenantStaffEmployment(Adapter ad, UpdateTenantStaffEmployment request)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = HRDAL.UpdateTenantStaffEmployment(ad, request);

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


        public static BasicApiResponse UpdateTenantStaff(Adapter ad, UpdateTenantStaff request)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = HRDAL.UpdateTenantStaff(ad, request);

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
        public static PostApiResponse InsertTenantStaffTimesheet(Adapter ad, InsertTenantStaffTimesheet request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = HRDAL.InsertTenantStaffTimesheet(ad, request, creatorUserId);
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


        public static PostApiResponse InsertTenantStaffRequirement(Adapter ad, InsertTenantStaffRequirement request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = HRDAL.InsertTenantStaffRequirement(ad, request, creatorUserId);
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


        public static PostApiResponse InsertTenantStaffRenumeration(Adapter ad, InsertTenantStaffRenumeration request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = HRDAL.InsertTenantStaffRenumeration(ad, request, creatorUserId);
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

        public static PostApiResponse InsertTenantStaffRecurring(Adapter ad, InsertTenantStaffRecurring request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = HRDAL.InsertTenantStaffRecurring(ad, request, creatorUserId);
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


        public static PostApiResponse InsertTenantStaffLeaveEntitlement(Adapter ad, InsertTenantStaffLeaveEntitlement request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = HRDAL.InsertTenantStaffLeaveEntitlement(ad, request, creatorUserId);
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


        public static PostApiResponse InsertTenantStaffLeaveApplication(Adapter ad, InsertTenantStaffLeaveApplication request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = HRDAL.InsertTenantStaffLeaveApplication(ad, request, creatorUserId);
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


        public static PostApiResponse InsertTenantStaffEmployment(Adapter ad, InsertTenantStaffEmployment request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = HRDAL.InsertTenantStaffEmployment(ad, request, creatorUserId);
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


        public static PostApiResponse InsertTenantStaff(Adapter ad, InsertTenantStaff request, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = HRDAL.InsertTenantStaff(ad, request, tenantId, creatorUserId);
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
        public static BasicApiResponse DeleteTenantStaffLeaveEntitlement(Adapter ad, List<ListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = HRDAL.DeleteTenantStaffLeaveEntitlement(ad, inIds, deleteUserId);
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

        public static BasicApiResponse DeleteTenantStaffRequirement(Adapter ad, int RequirementId, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = HRDAL.DeleteTenantStaffRequirement(ad, RequirementId, deleteUserId);
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

        public static BasicApiResponse DeleteTenantStaffRecurring(Adapter ad, List<ListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = HRDAL.DeleteTenantStaffRecurring(ad, inIds, deleteUserId);
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

        public static BasicApiResponse DeleteTenantStaff(Adapter ad, List<ListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = HRDAL.DeleteTenantStaff(ad, inIds, deleteUserId);
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

        public static BasicApiResponse DeleteLeaveApplicationByTimeSheet(Adapter ad, int id)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = HRDAL.DeleteLeaveApplicationByTimeSheet(ad, id);
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
