using System;
using System.Collections.Generic;
using Toolaku.DataAccess;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.Service;
using Toolaku.Models.Services;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Business
{
    public class ServicesBusiness
    {
        //--------------GET Method--------------
        /*
        public static ServicesLists GetServiceList(Adapter ad, int tenantId)
        {
            var response = new ServicesLists();

            try
            {
                var result = ServicesDAL.GetServiceList(ad, tenantId);

                if (result.Count != 0)
                {
                    response.result = result;
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
        */

        public static ServicesLists GetServiceList(Adapter ad, int tenantId, string searchKey, Pager pager = null)
        {
            var response = new ServicesLists();

            try
            {
                var result = ServicesDAL.GetServiceList(ad, tenantId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.result = result.Item1;
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }
        public static TenantServiceCategory GetServiceCategory(Adapter ad, int serviceId)
        {
            var response = new TenantServiceCategory();

            try
            {
                response = ServicesDAL.GetServiceCategory(ad, serviceId);

                if (response.level1CatId != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Such Record. Please insert new record";
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

        public static ServiceDescription GetServiceDescription(Adapter ad, int serviceId)
        {
            var response = new ServiceDescription();

            try
            {
                response = ServicesDAL.GetServiceDescription(ad, serviceId);

                if (response.description != string.Empty)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No description. Please insert new record";
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

        /*
        public static CoverageLists GetServiceCoverageList(Adapter ad, int serviceId)
        {
            var response = new CoverageLists();

            try
            {
                var result = ServicesDAL.GetServiceCoverageList(ad, serviceId);

                if (result.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                    response.result = result;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No coverage area listed";
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
        */

        public static CoverageLists GetServiceCoverageList(Adapter ad, int serviceId, string searchKey, Pager pager = null)
        {
            var response = new CoverageLists();

            try
            {
                var result = ServicesDAL.GetServiceCoverageList(ad, serviceId, searchKey, pager);

                if (result.Item1.Count != 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                   
                    response.result = result.Item1;
                    response.pageInfo = result.Item2;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No coverage area listed";
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

        public static ServiceGenerals GetServiceVariantList(Adapter ad, int serviceId)
        {
            var response = new ServiceGenerals();

            try
            {
                var result = ServicesDAL.GetServiceVariantList(ad, serviceId);

                if (result.Count != 0)
                {
                    response.serviceVariantList = result;
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



        public static ServiceVariant GetServiceVariantDetails(Adapter ad, int serviceVariantId)
        {
            var response = new ServiceVariant();

            try
            {
                response = ServicesDAL.GetServiceVariantDetails(ad, serviceVariantId);
            }
            catch (Exception e)
            {
                throw e;
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }


        //--------------PUT Method--------------
        public static BasicApiResponse DeleteServiceList(Adapter ad, string userId, List<ServiceToRemove> serviceToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in serviceToRemove)
                {
                    var result = ServicesDAL.DeleteServiceList(ad, Convert.ToInt32(id.serviceId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Products are successfully deleted";
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

        public static BasicApiResponse EnlistService(Adapter ad, string userId, List<ServiceToRemove> serviceToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {

                foreach (var id in serviceToRemove)
                {
                    var result = ServicesDAL.EnlistService(ad, Convert.ToInt16(id.serviceId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Services are successfully unlist";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Unlist Operation Fail";
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

        public static ServiceGenerals GetServiceGeneralInfo(Adapter ad, int serviceId)
        {
            var response = new ServiceGenerals();

            try
            {
                var infoResult = ServicesDAL.GetServiceGeneralInfo(ad, serviceId);

                if (infoResult.Count != 0)
                {

                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                    response.basicInfo = infoResult;

                    var imageResult = ServicesDAL.GetServiceImage(ad, serviceId);
                    response.imageList = imageResult;
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Such Record. Please insert new record";
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

        public static PostApiResponse UpdateServiceGeneral(Adapter ad, ServiceGeneralUpdate serviceGeneralUpdate)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ServicesDAL.UpdateServiceGeneral(ad, serviceGeneralUpdate);

                if (result.ReturnCode == 0)
                {
                    //delete all image first in table TenantProductImage
                    var imageDelete = ServicesDAL.DeleteServiceImageAll(ad, serviceGeneralUpdate.serviceId);
                    //---

                    var myImage = serviceGeneralUpdate.imageList;
                    for (var i = 0; i < myImage.Count; i++)
                    {
                        var imageInsert = ServicesDAL.InsertServiceImage(ad, serviceGeneralUpdate.serviceId, myImage[i].imageURL, myImage[i].isDefault);
                    }
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

        public static BasicApiResponse UpdateServiceCategory(Adapter ad, TenantServiceCategoryUpdate tenantserviceCategoryUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ServicesDAL.UpdateServiceCategory(ad, tenantserviceCategoryUpdate);

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

        public static BasicApiResponse UpdateServiceDescription(Adapter ad, ServiceDescriptionUpdate serviceDescriptionUpdate)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ServicesDAL.UpdateServiceDescription(ad, serviceDescriptionUpdate);

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

        public static BasicApiResponse DeleteCoverageList(Adapter ad, string userId, List<CoverageToRemove> coverageToRemove)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in coverageToRemove)
                {
                    var result = ServicesDAL.DeleteCoverageList(ad, Convert.ToInt32(id.coverageId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Coverage are successfully deleted";
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

        public static BasicApiResponse UpdateServiceVariant(Adapter ad, ServiceVariant serviceVariant)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ServicesDAL.UpdateServiceVariant(ad, serviceVariant);

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


        //--------------POST Method--------------
        public static PostApiResponse InsertServiceGeneral(Adapter ad, int tenantId, ServiceGeneralRequest serviceGeneralRequest)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ServicesDAL.InsertServiceGeneral(ad, tenantId, serviceGeneralRequest);

                if (result.ReturnCode == 0)
                {
                    var serviceId = result.Id;
                    var myImage = serviceGeneralRequest.imageList;
                    for (var i = 0; i < myImage.Count; i++)
                    {
                        var imageInsert = ServicesDAL.InsertServiceImage(ad, serviceId, myImage[i].imageURL, myImage[i].isDefault);
                    }
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

        public static PostApiResponse InsertServiceCoverage(Adapter ad, CoverageDetailInsert coverageDetailIn)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ServicesDAL.InsertServiceCoverage(ad, coverageDetailIn);

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


        public static BasicApiResponse InsertServiceVariant(Adapter ad, int tenantServiceId, ServiceVariant serviceVariantRequest)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ServicesDAL.InsertServiceVariant(ad, tenantServiceId, serviceVariantRequest);

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

        //--------------DELETE Method--------------
        public static BasicApiResponse DeleteServiceImage(Adapter ad, int serviceImageId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ServicesDAL.DeleteServiceImage(ad, serviceImageId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

        public static BasicApiResponse DeleteServiceVariant(Adapter ad, int serviceVariantId)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ServicesDAL.DeleteServiceVariant(ad, serviceVariantId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;
        }

    }
}
