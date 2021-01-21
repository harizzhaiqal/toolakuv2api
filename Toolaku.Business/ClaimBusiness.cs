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
    public class ClaimBusiness
    {

        //--------------------------------------------GET Method---------------------------------------------------------

        public static PersonalClaimListDT GetPersonalClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new PersonalClaimListDT();

            try
            {
                var result = ClaimDAL.GetPersonalClaimList(ad, userId, searchKey, pager);

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

        public static PersonalClaimDetails GetPersonalClaimDetails(Adapter ad, int claimId)
        {
            var response = new PersonalClaimDetails();

            try
            {
                response = ClaimDAL.GetPersonalClaimDetails(ad, claimId);

                if (response.Date != "")
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



        public static TravelClaimListDT GetTravelClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new TravelClaimListDT();

            try
            {
                var result = ClaimDAL.GetTravelClaimList(ad, userId, searchKey, pager);

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

        public static TravellingClaimDetails GetTravellingClaimDetails(Adapter ad, int travelId)
        {
            var response = new TravellingClaimDetails();

            try
            {
                response = ClaimDAL.GetTravellingClaimDetails(ad, travelId);

                if (response.Date != "")
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


        public static PhoneAllowanceClaimListDT GetPhoneAllowanceClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new PhoneAllowanceClaimListDT();

            try
            {
                var result = ClaimDAL.GetPhoneAllowanceClaimList(ad, userId, searchKey, pager);

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

        public static PhoneAllowanceClaimDetails GetPhoneAllowanceClaimDetails(Adapter ad, int phoneId)
        {
            var response = new PhoneAllowanceClaimDetails();

            try
            {
                response = ClaimDAL.GetPhoneAllowanceClaimDetails(ad, phoneId);

                if (response.Date != "")
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


        public static MedicalClaimListDT GetMedicalClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new MedicalClaimListDT();

            try
            {
                var result = ClaimDAL.GetMedicalClaimList(ad, userId, searchKey, pager);

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

        public static MedicalClaimDetails GetMedicalClaimDetails(Adapter ad, int medicalId)
        {
            var response = new MedicalClaimDetails();

            try
            {
                response = ClaimDAL.GetMedicalClaimDetails(ad, medicalId);

                if (response.Date != "")
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



        public static PurchaseItemClaimListDT GetPurchaseItemClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new PurchaseItemClaimListDT();

            try
            {
                var result = ClaimDAL.GetPurchaseItemClaimList(ad, userId, searchKey, pager);

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

        public static PurchaseItemClaimDetails GetPurchaseItemClaimDetails(Adapter ad, int purchaseId)
        {
            var response = new PurchaseItemClaimDetails();

            try
            {
                response = ClaimDAL.GetPurchaseItemClaimDetails(ad, purchaseId);

                if (response.Date != "")
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


        public static TravelClaimListDT GetPersonalClaimTravellingList(Adapter ad, int claimId)
        {
            var response = new TravelClaimListDT();

            try
            {
                var result = ClaimDAL.GetPersonalClaimTravellingList(ad, claimId);

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


        public static PhoneAllowanceClaimListDT GetPersonalClaimPhoneList(Adapter ad, int claimId)
        {
            var response = new PhoneAllowanceClaimListDT();

            try
            {
                var result = ClaimDAL.GetPersonalClaimPhoneList(ad, claimId);

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


        public static MedicalClaimListDT GetPersonalClaimMedicalList(Adapter ad, int claimId)
        {
            var response = new MedicalClaimListDT();

            try
            {
                var result = ClaimDAL.GetPersonalClaimMedicalList(ad, claimId);

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

        public static PurchaseItemClaimListDT GetPersonalClaimPurchaseList(Adapter ad, int claimId)
        {
            var response = new PurchaseItemClaimListDT();

            try
            {
                var result = ClaimDAL.GetPersonalClaimPurchaseList(ad, claimId);

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


        public static ClaimAttachmentDT GetAttachmentTravelling(Adapter ad, int travelId)
        {
            var response = new ClaimAttachmentDT();

            try
            {
                var result = ClaimDAL.GetAttachmentTravelling(ad, travelId);

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


        public static ClaimAttachmentDT GetAttachmentPhoneAllowance(Adapter ad, int phoneId)
        {
            var response = new ClaimAttachmentDT();

            try
            {
                var result = ClaimDAL.GetAttachmentPhoneAllowance(ad, phoneId);

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


        public static ClaimAttachmentDT GetAttachmentMedical(Adapter ad, int medicalId)
        {
            var response = new ClaimAttachmentDT();

            try
            {
                var result = ClaimDAL.GetAttachmentMedical(ad, medicalId);

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


        public static ClaimAttachmentDT GetAttachmentPurchaseItem(Adapter ad, int purchaseId)
        {
            var response = new ClaimAttachmentDT();

            try
            {
                var result = ClaimDAL.GetAttachmentPurchaseItem(ad, purchaseId);

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

        public static WaitingApprovalClaimListDT GetWaitingApprovalClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new WaitingApprovalClaimListDT();

            try
            {
                var result = ClaimDAL.GetWaitingApprovalClaimList(ad, userId, searchKey, pager);

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


        public static ApprovedClaimListDT GetApprovedClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new ApprovedClaimListDT();

            try
            {
                var result = ClaimDAL.GetApprovedClaimList(ad, userId, searchKey, pager);

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


        public static ClaimReport GetClaimReport(Adapter ad, int claimId)
        {
            var response = new ClaimReport();
            var result1 = new List<TravellingClaimReport>();
            var result2 = new List<PhoneAllowanceClaimReport>();
            var result3 = new List<MedicalClaimReport>();
            var result4 = new List<PurchaseItemClaimReport>();

            try
            {
                response = ClaimDAL.GetClaimReport(ad, claimId);

                if (response.Date != "")
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "No Content";
                }

                result1 = ClaimDAL.GetTravellingClaimReport(ad, claimId);
                if (result1.Count != 0)
                {
                    response.travelList = result1;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }

                result2 = ClaimDAL.GetPhoneAllowanceClaimReport(ad, claimId);
                if (result2.Count != 0)
                {
                    response.phoneList = result2;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }

                result3 = ClaimDAL.GetMedicalClaimReport(ad, claimId);
                if (result3.Count != 0)
                {
                    response.medicalList = result3;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
                }

                result4 = ClaimDAL.GetPurchaseItemClaimReport(ad, claimId);
                if (result4.Count != 0)
                {
                    response.purchaseList = result4;
                    response.ReturnCode = 200;
                    response.ResponseMessage = "";
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







        //--------------------------------------------PUT Method---------------------------------------------------------

        public static BasicApiResponse UpdatePersonalClaim(Adapter ad, UpdatePersonalClaim updatePersonalClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ClaimDAL.UpdatePersonalClaim(ad, updatePersonalClaim);

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

        public static BasicApiResponse UpdateTravellingClaim(Adapter ad, UpdateTravellingClaim updateTravellingClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ClaimDAL.UpdateTravellingClaim(ad, updateTravellingClaim);

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

        public static BasicApiResponse UpdatePhoneAllowanceClaim(Adapter ad, UpdatePhoneAllowanceClaim updatePhoneAllowanceClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ClaimDAL.UpdatePhoneAllowanceClaim(ad, updatePhoneAllowanceClaim);

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

        public static BasicApiResponse UpdateMedicalClaim(Adapter ad, UpdateMedicalClaim updateMedicalClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ClaimDAL.UpdateMedicalClaim(ad, updateMedicalClaim);

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

        public static BasicApiResponse UpdatePurchaseClaim(Adapter ad, UpdatePurchaseClaim updatePurchaseClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ClaimDAL.UpdatePurchaseClaim(ad, updatePurchaseClaim);

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


        public static BasicApiResponse UpdateClaimApprover(Adapter ad, int claimId, List<UpdateClaimApprover> userIds)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;
            var returnMsg = "";

            try
            {


                foreach (var id in userIds)
                {
                    var result = ClaimDAL.UpdateClaimApprover(ad, claimId, id.UserId);
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                        returnMsg = result.ResponseMessage;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "People successfully added";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = returnMsg;
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


        public static BasicApiResponse UpdateClaimStatusApprove(Adapter ad, UpdateClaimStatus updateClaimStatus)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ClaimDAL.UpdateClaimStatusApprove(ad, updateClaimStatus);

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


        public static BasicApiResponse UpdateClaimStatusReject(Adapter ad, UpdatePersonalClaim updatePersonalClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                var result = ClaimDAL.UpdateClaimStatusReject(ad, updatePersonalClaim);

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




        //--------------------------------------------POST Method---------------------------------------------------------


        public static PostApiResponse InsertPersonalClaim(Adapter ad, InsertPersonalClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ClaimDAL.InsertPersonalClaim(ad, request, userId, tenantId, creatorUserId);
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


        public static PostApiResponse InsertTravellingClaim(Adapter ad, InsertTravellingClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ClaimDAL.InsertTravellingClaim(ad, request, userId, tenantId, creatorUserId);
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

        public static PostApiResponse InsertPhoneAllowanceClaim(Adapter ad, InsertPhoneAllowanceClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ClaimDAL.InsertPhoneAllowanceClaim(ad, request, userId, tenantId, creatorUserId);
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

        public static PostApiResponse InsertMedicalClaim(Adapter ad, InsertMedicalClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ClaimDAL.InsertMedicalClaim(ad, request, userId, tenantId, creatorUserId);
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

        public static PostApiResponse InsertPurchaseItemClaim(Adapter ad, InsertPurchaseItemClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ClaimDAL.InsertPurchaseItemClaim(ad, request, userId, tenantId, creatorUserId);
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

        public static PostApiResponse InsertPersonalClaimTravelling(Adapter ad, InsertTravellingClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ClaimDAL.InsertPersonalClaimTravelling(ad, request, userId, tenantId, creatorUserId);
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

        public static PostApiResponse InsertPersonalClaimPhone(Adapter ad, InsertPhoneAllowanceClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ClaimDAL.InsertPersonalClaimPhone(ad, request, userId, tenantId, creatorUserId);
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

        public static PostApiResponse InsertPersonalClaimMedical(Adapter ad, InsertMedicalClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ClaimDAL.InsertPersonalClaimMedical(ad, request, userId, tenantId, creatorUserId);
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

        public static PostApiResponse InsertPersonalClaimPurchaseItem(Adapter ad, InsertPurchaseItemClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ClaimDAL.InsertPersonalClaimPurchaseItem(ad, request, userId, tenantId, creatorUserId);
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



        public static PostApiResponse InsertAttachmentTravel(Adapter ad, InsertClaimAttachment request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ClaimDAL.InsertAttachmentTravel(ad, request, creatorUserId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;

        }


        public static PostApiResponse InsertAttachmentPhoneAllowance(Adapter ad, InsertClaimAttachment request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ClaimDAL.InsertAttachmentPhoneAllowance(ad, request, creatorUserId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;

        }


        public static PostApiResponse InsertAttachmentMedical(Adapter ad, InsertClaimAttachment request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                var result = ClaimDAL.InsertAttachmentMedical(ad, request, creatorUserId);
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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;

        }


        public static PostApiResponse InsertAttachmentPurchaseItem(Adapter ad, InsertClaimAttachment request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                var result = ClaimDAL.InsertAttachmentPurchaseItem(ad, request, creatorUserId);

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
                //string context = clsCommon.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }

            return response;

        }




        //--------------------------------------------DELETE Method---------------------------------------------------------

        public static BasicApiResponse DeletePersonalClaimList(Adapter ad, string userId, string tenantId, List<DeletePersonalClaim> deletePersonalClaim)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in deletePersonalClaim)
                {
                    var result = ClaimDAL.DeletePersonalClaimList(ad, Convert.ToInt32(id.ClaimId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Personal Claim are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Personal Claim Delete Operation Fail";
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


        public static BasicApiResponse DeleteTravellingClaimList(Adapter ad, string userId, string tenantId, List<DeleteTravellingClaim> deleteTravellingClaims)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in deleteTravellingClaims)
                {
                    var result = ClaimDAL.DeleteTravellingClaimList(ad, Convert.ToInt32(id.TravelId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Travelling Claim are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Travelling Claim Delete Operation Fail";
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

        public static BasicApiResponse DeletePhoneAllowanceClaimList(Adapter ad, string userId, string tenantId, List<DeletePhoneAllowanceClaim> deletePhoneAllowanceClaim)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in deletePhoneAllowanceClaim)
                {
                    var result = ClaimDAL.DeletePhoneAllowanceClaimList(ad, Convert.ToInt32(id.PhoneId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Phone Allowance are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Phone Allowance Delete Operation Fail";
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

        public static BasicApiResponse DeleteMedicalClaimList(Adapter ad, string userId, string tenantId, List<DeleteMedicalClaim> deleteMedicalClaim)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in deleteMedicalClaim)
                {
                    var result = ClaimDAL.DeleteMedicalClaimList(ad, Convert.ToInt32(id.MedicalId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Medical Claim are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Medical Claim Delete Operation Fail";
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

        public static BasicApiResponse DeletePurchaseItemClaimList(Adapter ad, string userId, string tenantId, List<DeletePurchaseItemClaim> deletePurchaseItemClaim)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in deletePurchaseItemClaim)
                {
                    var result = ClaimDAL.DeletePurchaseItemClaimList(ad, Convert.ToInt32(id.PurchaseId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Purchase Item  are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Purchase Item Delete Operation Fail";
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

        public static BasicApiResponse DeleteClaim_Travelling(Adapter ad, string userId, string tenantId, List<DeleteClaimItem> deleteClaimItem)
        {
            var response = new BasicApiResponse();
            var responseMsg = string.Empty;
            var returnCode = 0;

            try
            {
                foreach (var id in deleteClaimItem)
                {
                    var result = ClaimDAL.DeleteClaim_Travelling(ad, Convert.ToInt32(id.ClaimId));
                    if (result.ReturnCode == 1)
                    {
                        returnCode = result.ReturnCode;
                    }
                }

                if (returnCode == 0)
                {
                    response.ReturnCode = 200;
                    response.ResponseMessage = "Travelling Claim are successfully deleted";
                }
                else
                {
                    response.ReturnCode = 204;
                    response.ResponseMessage = "Travelling Claim Delete Operation Fail";
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

        public static BasicApiResponse DeleteAttachmentTravelling(Adapter ad, List<DeleteAttachmentClaim> ids)
        {
            var response = new BasicApiResponse();

            try
            {
                var inIds = "0";
                foreach (var id in ids)
                {
                    inIds += "," + id.travelId;
                }
                var result = ClaimDAL.DeleteAttachmentTravelling(ad, inIds);

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


        public static BasicApiResponse DeleteAttachmentPhone(Adapter ad, List<DeleteAttachmentClaim> ids)
        {
            var response = new BasicApiResponse();

            try
            {
                var inIds = "0";
                foreach (var id in ids)
                {
                    inIds += "," + id.phoneId;
                }
                var result = ClaimDAL.DeleteAttachmentPhone(ad, inIds);

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

        public static BasicApiResponse DeleteAttachmentMedical(Adapter ad, List<DeleteAttachmentClaim> ids)
        {
            var response = new BasicApiResponse();

            try
            {
                var inIds = "0";
                foreach (var id in ids)
                {
                    inIds += "," + id.medicalId;
                }
                var result = ClaimDAL.DeleteAttachmentMedical(ad, inIds);

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

        public static BasicApiResponse DeleteAttachmentPurchaseItem(Adapter ad, List<DeleteAttachmentClaim> ids)
        {
            var response = new BasicApiResponse();

            try
            {
                var inIds = "0";
                foreach (var id in ids)
                {
                    inIds += "," + id.purchaseId;
                }
                var result = ClaimDAL.DeleteAttachmentPurchaseItem(ad, inIds);

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

      
