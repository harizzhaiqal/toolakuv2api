using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using Toolaku.Business;
using Toolaku.Library;
using Toolaku.Models;
using Toolaku.Models.DTO;
using Toolaku.Models.HR;
using Toolaku.Models.Pagingnation;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ToolakuV2_API.Controllers
{
    [RoutePrefix("api/HR")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class HRController : ApiController
    {
        //--------------------------------------
        //--------------GET Method--------------
        //--------------------------------------

        [HttpGet]
        [AllowAnonymous]
        [Route("leaveTypeByStaff")]
        public IHttpActionResult GetLeaveTypeByStaff(int tenantStaffId, int leaveEntitlementId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new LeaveTypes();

                response = HRBusiness.GetLeaveTypeByStaff(ad, tenantStaffId, leaveEntitlementId);
                return Ok(response);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("renumerationTypeByStaff")]
        public IHttpActionResult GetRenumerationTypeByStaff(int tenantStaffId, int recurringId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = new RenumerationTypes();

                response = HRBusiness.GetRenumerationTypeByStaff(ad, tenantStaffId, recurringId);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("timesheet/list")]
        public IHttpActionResult GetTenantStaffTimesheetList(string startDate = null, string endDate = null, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = HRBusiness.GetTenantStaffTimesheetList(ad, Convert.ToInt32(tenantId), startDate, endDate, searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("timesheet")]
        public IHttpActionResult GetTenantStaffTimesheetDetails(int timesheetId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetTenantStaffTimesheetDetails(ad, timesheetId);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("staff/requirement")]
        public IHttpActionResult GetTenantStaffRequirementDetails(int tenantStaffId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetTenantStaffRequirementDetails(ad, tenantStaffId);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("dashboard/employmentStatus")]
        public IHttpActionResult GetDashboardEmploymentStatus()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetDashboardEmploymentStatus(ad, Convert.ToInt32(tenantId));
                return Ok(response);
            }
        }



        [HttpGet]
        [Authorize]
        [Route("report/monthly/staff")]
        public IHttpActionResult GetTenantStaffReportMontlyStaff(int tenantStaffId, int month, int year)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetTenantStaffReportMontlyStaff(ad, tenantStaffId, month, year);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("report/monthly/details")]
        public IHttpActionResult GetTenantStaffReportMontlyDetails(int month, int year)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetTenantStaffReportMontlyDetails(ad, Convert.ToInt32(tenantId), month, year);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("report/list")]
        public IHttpActionResult GetTenantStaffReportList(int month, int year, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = HRBusiness.GetTenantStaffReportList(ad, Convert.ToInt32(tenantId), month, year, searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("staff/renumeration")]
        public IHttpActionResult GetTenantStaffRenumerationDetails(int tenantStaffId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetTenantStaffRenumerationDetails(ad, tenantStaffId);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("staff/recurring/list")]
        public IHttpActionResult GetTenantStaffRecurringList(int tenantStaffId, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = HRBusiness.GetTenantStaffRecurringList(ad, tenantStaffId, searchKey, page);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("staff/recurring")]
        public IHttpActionResult GetTenantStaffRecurringDetails(int RecurringId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetTenantStaffRecurringDetails(ad, RecurringId);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("staff/monthly/details")]
        public IHttpActionResult GetTenantStaffMontlyDetails(int tenantStaffId, int month, int year)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetTenantStaffMontlyDetails(ad, tenantStaffId, month, year);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("staff/list")]
        public IHttpActionResult GetTenantStaffList(string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = HRBusiness.GetTenantStaffList(ad, Convert.ToInt32(tenantId), searchKey, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("staff/leave/entitlement/list")]
        public IHttpActionResult GetTenantStaffLeaveEntitlementList(int tenantStaffId, string searchKey = null, int RowsPerPage = 0,
        int PageNumber = 0, string OrderScript = "", string ColumnFilterScript = "")
        {
            using (Adapter ad = new Adapter())
            {
                var page = new Pager();
                page.RowsPerPage = RowsPerPage;
                page.PageNumber = PageNumber;
                page.OrderScript = OrderScript;
                page.ColumnFilterScript = ColumnFilterScript;

                var response = HRBusiness.GetTenantStaffLeaveEntitlementList(ad, tenantStaffId, searchKey, page);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("staff/leave/entitlement")]
        public IHttpActionResult GetTenantStaffLeaveEntitlementDetails(int LeaveEntitlementId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetTenantStaffLeaveEntitlementDetails(ad, LeaveEntitlementId);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("staff/leave")]
        public IHttpActionResult GetTenantStaffLeaveDetails(int LeaveId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetTenantStaffLeaveDetails(ad, LeaveId);
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("staff/employment")]
        public IHttpActionResult GetTenantStaffEmploymentDetails(int tenantStaffId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetTenantStaffEmploymentDetails(ad, tenantStaffId);
                return Ok(response);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("staff")]
        public IHttpActionResult GetTenantStaffDetails(int TenantStaffId)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.GetTenantStaffDetails(ad, TenantStaffId);
                return Ok(response);
            }
        }






            //--------------------------------------
            //--------------PUT Method--------------
            //--------------------------------------

            [HttpPut]
        [Authorize]
        [Route("timesheet")]
        public IHttpActionResult UpdateTenantStaffTimesheet(UpdateTenantStaffTimesheet request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.UpdateTenantStaffTimesheet(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("staff/requirement")]
        public IHttpActionResult UpdateTenantStaffRequirement(UpdateTenantStaffRequirement request)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.UpdateTenantStaffRequirement(ad, request);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("staff/renumeration")]
        public IHttpActionResult UpdateTenantStaffRenumeration(UpdateTenantStaffRenumeration request)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.UpdateTenantStaffRenumeration(ad, request);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("staff/recurring")]
        public IHttpActionResult UpdateTenantStaffRecurring(UpdateTenantStaffRecurring request)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.UpdateTenantStaffRecurring(ad, request);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("staff/leave/entitlement")]
        public IHttpActionResult UpdateTenantStaffLeaveEntitlement(UpdateTenantStaffLeaveEntitlement request)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.UpdateTenantStaffLeaveEntitlement(ad, request);
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("staff/leave/application")]
        public IHttpActionResult UpdateTenantStaffLeaveApplication(UpdateTenantStaffLeaveApplication request)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.UpdateTenantStaffLeaveApplication(ad, request);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("staff/employment")]
        public IHttpActionResult UpdateTenantStaffEmployment(UpdateTenantStaffEmployment request)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.UpdateTenantStaffEmployment(ad, request);
                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize]
        [Route("staff")]
        public IHttpActionResult UpdateTenantStaff(UpdateTenantStaff request)
        {
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.UpdateTenantStaff(ad, request);
                return Ok(response);
            }
        }

        //--------------------------------------
        //--------------POST Method--------------
        //--------------------------------------

        [HttpPost]
        [Authorize]
        [Route("timesheet")]
        public IHttpActionResult InsertTenantStaffTimesheet(InsertTenantStaffTimesheet request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.InsertTenantStaffTimesheet(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("staff/requirement")]
        public IHttpActionResult InsertTenantStaffRequirement(InsertTenantStaffRequirement request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.InsertTenantStaffRequirement(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("staff/renumeration")]
        public IHttpActionResult InsertTenantStaffRenumeration(InsertTenantStaffRenumeration request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.InsertTenantStaffRenumeration(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("staff/recurring")]
        public IHttpActionResult InsertTenantStaffRecurring(InsertTenantStaffRecurring request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.InsertTenantStaffRecurring(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("staff/leave/entitlement")]
        public IHttpActionResult InsertTenantStaffLeaveEntitlement(InsertTenantStaffLeaveEntitlement request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.InsertTenantStaffLeaveEntitlement(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("staff/leave/application")]
        public IHttpActionResult InsertTenantStaffLeaveApplication(InsertTenantStaffLeaveApplication request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.InsertTenantStaffLeaveApplication(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("staff/employment")]
        public IHttpActionResult InsertTenantStaffEmployment(InsertTenantStaffEmployment request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;
            
            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.InsertTenantStaffEmployment(ad, request, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("staff")]
        public IHttpActionResult InsertTenantStaff(InsertTenantStaff request)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var tenantId = principal.Claims.Where(c => c.Type == "TenantId").Single().Value;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.InsertTenantStaff(ad, request, Convert.ToInt32(tenantId), Convert.ToInt32(userId));
                return Ok(response);
            }
        }



        //--------------------------------------
        //--------------DELETE Method--------------
        //--------------------------------------
        [HttpPut]
        [Authorize]
        [Route("staff/leave/entitlement/delete")]
        public IHttpActionResult DeleteTenantStaffLeaveEntitlement(List<ListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.DeleteTenantStaffLeaveEntitlement(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("staff/requirement/delete")]
        public IHttpActionResult DeleteTenantStaffRequirement(int RequirementId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.DeleteTenantStaffRequirement(ad, RequirementId, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("staff/recurring/delete")]
        public IHttpActionResult DeleteTenantStaffRecurring(List<ListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.DeleteTenantStaffRecurring(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("staff/delete")]
        public IHttpActionResult DeleteTenantStaff(List<ListIdToDelete> ids)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.DeleteTenantStaff(ad, ids, Convert.ToInt32(userId));
                return Ok(response);
            }
        }


        [HttpDelete]
        [Authorize]
        [Route("leave/application/by/timesheet")]
        public IHttpActionResult DeleteLeaveApplicationByTimeSheet(int TimesheetId)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == "NameIdentifier").Single().Value;

            using (Adapter ad = new Adapter())
            {
                var response = HRBusiness.DeleteLeaveApplicationByTimeSheet(ad, TimesheetId);
                return Ok(response);
            }

        }

    }
}
