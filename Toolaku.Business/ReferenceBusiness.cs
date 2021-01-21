using System;
using System.Collections.Generic;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models;
using Toolaku.Models.DTO;
using Toolaku.Models.Reference;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Business
{
    public class ReferenceBusiness
    {
        public static DayTypes GetDayType(Adapter ad)
        {
            var response = new DayTypes();
            try
            {
                var result = ReferenceDAL.GetDayType(ad);
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


        public static Editions GetEdition(Adapter ad)
        {
            var response = new Editions();
            try
            {
                var result = ReferenceDAL.GetEdition(ad);
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


        public static DocumentTypes GetDocumentType(Adapter ad)
        {
            var response = new DocumentTypes();
            try
            {
                var result = ReferenceDAL.GetDocumentType(ad);
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


        public static Frequencies GetFrequency(Adapter ad)
        {
            var response = new Frequencies();
            try
            {
                var result = ReferenceDAL.GetFrequency(ad);
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


        public static Genders GetGender(Adapter ad)
        {
            var response = new Genders();
            try
            {
                var result = ReferenceDAL.GetGender(ad);
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


        public static LeaveDurationTypes GetLeaveDurationType(Adapter ad)
        {
            var response = new LeaveDurationTypes();
            try
            {
                var result = ReferenceDAL.GetLeaveDurationType(ad);
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


        public static LeaveTypes GetLeaveType(Adapter ad)
        {
            var response = new LeaveTypes();
            try
            {
                var result = ReferenceDAL.GetLeaveType(ad);
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

        public static MaritalStatuses GetMaritalStatus(Adapter ad)
        {
            var response = new MaritalStatuses();
            try
            {
                var result = ReferenceDAL.GetMaritalStatus(ad);
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

        public static EmploymentStatuses GetEmploymentStatus(Adapter ad)
        {
            var response = new EmploymentStatuses();
            try
            {
                var result = ReferenceDAL.GetEmploymentStatus(ad);
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


        public static CategoryTypes GetCategoryType(Adapter ad)
        {
            var response = new CategoryTypes();

            try
            {
                var result = ReferenceDAL.GetCategoryType(ad);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
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

        public static ProductCategories GetProductCategoryParent(Adapter ad)
        {
            var response = new ProductCategories();

            try
            {
                var result = ReferenceDAL.GetProductCategoryParent(ad);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ProductCategories GetProductCategory(Adapter ad, int categoryId)
        {
            var response = new ProductCategories();

            try
            {
                var result = ReferenceDAL.GetProductCategory(ad, categoryId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ServiceCategories GetServiceCategoryParent(Adapter ad)
        {
            var response = new ServiceCategories();

            try
            {
                var result = ReferenceDAL.GetServiceCategoryParent(ad);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ServiceCategories GetServiceCategory(Adapter ad, int categoryId)
        {
            var response = new ServiceCategories();

            try
            {
                var result = ReferenceDAL.GetServiceCategory(ad, categoryId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static Countries GetCountry(Adapter ad)
        {
            var response = new Countries();

            try
            {
                var result = ReferenceDAL.GetCountry(ad);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
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

        public static Months GetMonth(Adapter ad)
        {
            var response = new Months();

            try
            {
                var result = ReferenceDAL.GetMonth(ad);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
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

        public static Vehicles GetVehicle(Adapter ad)
        {
            var response = new Vehicles();

            try
            {
                var result = ReferenceDAL.GetVehicle(ad);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
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

        public static TelcoSuppliers GetTelcoSupplier(Adapter ad)
        {
            var response = new TelcoSuppliers();

            try
            {
                var result = ReferenceDAL.GetTelcoSupplier(ad);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
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


        public static States GetState(Adapter ad, int countryId)
        {
            var response = new States();

            try
            {
                var result = ReferenceDAL.GetState(ad, countryId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
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

        public static Cities GetCity(Adapter ad, int stateId)
        {
            var response = new Cities();

            try
            {
                var result = ReferenceDAL.GetCity(ad, stateId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
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

        public static ProductCountries GetProductCountry(Adapter ad)
        {
            var response = new ProductCountries();

            try
            {
                var result = ReferenceDAL.GetProductCountry(ad);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ProductStates GetProductState(Adapter ad, int countryId)
        {
            var response = new ProductStates();

            try
            {
                var result = ReferenceDAL.GetProductState(ad, countryId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static ProductCities GetProductCity(Adapter ad, int stateId)
        {
            var response = new ProductCities();

            try
            {
                var result = ReferenceDAL.GetProductCity(ad, stateId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static LocationTypes GetLocationType(Adapter ad)
        {
            var response = new LocationTypes();

            try
            {
                var result = ReferenceDAL.GetLocationType(ad);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static Conditions GetPoductCondition(Adapter ad)
        {
            var response = new Conditions();

            try
            {
                var result = ReferenceDAL.GetPoductCondition(ad);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
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

        public static ProductMaterials GetPoductMaterial(Adapter ad)
        {
            var response = new ProductMaterials();

            try
            {
                var result = ReferenceDAL.GetPoductMaterial(ad);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
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

        public static Uoms GetUnitOfMeasurement(Adapter ad)
        {
            var response = new Uoms();

            try
            {
                var result = ReferenceDAL.GetUnitOfMeasurement(ad);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static Agencies GetAgency(Adapter ad)
        {
            var response = new Agencies();

            try
            {
                var result = ReferenceDAL.GetAgency(ad);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static AgencyGrades GetAgencyGrade(Adapter ad, int agencyId)
        {
            var response = new AgencyGrades();

            try
            {
                var result = ReferenceDAL.GetAgencyGrade(ad, agencyId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static AgencyCodeParents GetAgencyCodeParent(Adapter ad, int agencyId)
        {
            var response = new AgencyCodeParents();

            try
            {
                var result = ReferenceDAL.GetAgencyCodeParent(ad, agencyId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static AgencyCodes GetAgencyCode(Adapter ad, int agencyCodeId)
        {
            var response = new AgencyCodes();

            try
            {
                var result = ReferenceDAL.GetAgencyCode(ad, agencyCodeId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }


        public static DepartmentRoleListDT GetDepartmentRoleList(Adapter ad, string searchKey, Pager pager = null)
        {
            var response = new DepartmentRoleListDT();
            try
            {
                var result = ReferenceDAL.GetDepartmentRoleList(ad, searchKey, pager);
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

        public static DepartmentRoleDetails GetDepartmentRoleDetails(Adapter ad, int id)
        {
            var response = new DepartmentRoleDetails();
            try
            {
                response = ReferenceDAL.GetDepartmentRoleDetails(ad, id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        //--------------PUT Method--------------
        public static PostApiResponse UpdateCategoryType(Adapter ad, CategoryType categoryType)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ReferenceDAL.UpdateCategoryType(ad, categoryType);

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


        public static BasicApiResponse DeleteCategoryTypeList(Adapter ad, List<CategoryTypeToRemove> categoryTypeToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in categoryTypeToRemove)
                {
                    var result = ReferenceDAL.DeleteCategoryTypeList(ad, Convert.ToInt32(id.CategoryTypeId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Category Type are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Delete Operation Fail";
                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }


        public static PostApiResponse UpdateAgency(Adapter ad, Agency Agency)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ReferenceDAL.UpdateAgency(ad, Agency);

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

        public static BasicApiResponse DeleteAgencyList(Adapter ad, List<AgencyToRemove> AgencyToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in AgencyToRemove)
                {
                    var result = ReferenceDAL.DeleteAgencyList(ad, Convert.ToInt32(id.AgencyId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Agency are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Delete Operation Fail";
                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }


        public static PostApiResponse UpdateAgencyCode(Adapter ad, AgencyCode AgencyCode)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ReferenceDAL.UpdateAgencyCode(ad, AgencyCode);

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

        public static BasicApiResponse DeleteAgencyCodeList(Adapter ad, List<AgencyCodeToRemove> AgencyCodeToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in AgencyCodeToRemove)
                {
                    var result = ReferenceDAL.DeleteAgencyCodeList(ad, Convert.ToInt32(id.AgencyCodeId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Agency Code are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Delete Operation Fail";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static PostApiResponse UpdateAgencyGrade(Adapter ad, AgencyGrade AgencyGrade)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ReferenceDAL.UpdateAgencyGrade(ad, AgencyGrade);

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

        public static BasicApiResponse DeleteAgencyGradeList(Adapter ad, List<AgencyGradeToRemove> AgencyGradeToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in AgencyGradeToRemove)
                {
                    var result = ReferenceDAL.DeleteAgencyGradeList(ad, Convert.ToInt32(id.AgencyGradeId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Agency Grade are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Delete Operation Fail";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static PostApiResponse UpdateProductMaterial(Adapter ad, ProductMaterial ProductMaterial)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ReferenceDAL.UpdateProductMaterial(ad, ProductMaterial);

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

        public static BasicApiResponse DeleteProductMaterialList(Adapter ad, List<ProductMaterialToRemove> ProductMaterialToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in ProductMaterialToRemove)
                {
                    var result = ReferenceDAL.DeleteProductMaterialList(ad, Convert.ToInt32(id.ProductMaterialId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Material are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Delete Operation Fail";
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpCovntext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse UpdateDepartmentRole(Adapter ad, UpdateDepartmentRole request, int updatorUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var result = ReferenceDAL.UpdateDepartmentRole(ad, request, updatorUserId);

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

        public static PostApiResponse InsertCategoryType(Adapter ad, CategoryType categoryType)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ReferenceDAL.InsertCategoryType(ad, categoryType);

                if (result.ReturnCode == 0)
                {
                    response.Id = result.Id;
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

        public static PostApiResponse InsertAgency(Adapter ad, Agency Agency)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ReferenceDAL.InsertAgency(ad, Agency);

                if (result.ReturnCode == 0)
                {
                    response.Id = result.Id;
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


        public static PostApiResponse InsertAgencyCode(Adapter ad, AgencyCode AgencyCode)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ReferenceDAL.InsertAgencyCode(ad, AgencyCode);

                if (result.ReturnCode == 0)
                {
                    response.Id = result.Id;
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

        public static PostApiResponse InsertAgencyGrade(Adapter ad, AgencyGrade AgencyGrade)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ReferenceDAL.InsertAgencyGrade(ad, AgencyGrade);

                if (result.ReturnCode == 0)
                {
                    response.Id = result.Id;
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

        public static PostApiResponse InsertProductMaterial(Adapter ad, ProductMaterial ProductMaterial)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ReferenceDAL.InsertProductMaterial(ad, ProductMaterial);

                if (result.ReturnCode == 0)
                {
                    response.Id = result.Id;
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

        public static PostApiResponse InsertDepartmentRole(Adapter ad, InsertDepartmentRole request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ReferenceDAL.InsertDepartmentRole(ad, request, creatorUserId);
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

        //DELETE ----------------------------------

        public static BasicApiResponse DeleteDepartmentRole(Adapter ad, List<RefListIdToDelete> ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            try
            {
                var inIds = "0";
                foreach (var setId in ids)
                {
                    inIds += "," + setId.id;
                }

                var result = ReferenceDAL.DeleteDepartmentRole(ad, inIds, deleteUserId);
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
