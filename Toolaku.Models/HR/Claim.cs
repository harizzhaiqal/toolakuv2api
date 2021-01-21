using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.HR;
using Toolaku.Models.Pagingnation;


namespace Toolaku.Models.HR
{

    //----------GET--------------

    public class PersonalClaimList
    {
        public int ClaimId { get; set; }
        public string Month { get; set; }
        public string Status { get; set; }
        public double Total { get; set; }

    }

    public class PersonalClaimListDT : ResponseBase
    {
        public List<PersonalClaimList> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class PersonalClaimDetails : ResponseBase
    {
        public int ClaimId { get; set; }
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string VehicleNumber { get; set; }
        public double Total { get; set; }
        public string StatusName { get; set; }
    }

    public class TravelClaimList
    {
        public int TravelId { get; set; }
        public string Month { get; set; }
        public string ProjectCode { get; set; }
        public string Destination { get; set; }
        public double TotalAmount { get; set; }

    }

    public class TravelClaimListDT : ResponseBase
    {
        public List<TravelClaimList> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class TravellingClaimDetails : ResponseBase
    {
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string ProjectCode { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public int VehicleId { get; set; }
        public double Distance { get; set; }
        public double TotalMileage { get; set; }
        public double MealAllowance { get; set; }
        public double Accomodation { get; set; }
        public double Toll { get; set; }
        public double Parking { get; set; }
        public double TotalAmount { get; set; }
    }


    public class PhoneAllowanceClaimList
    {
        public int PhoneId { get; set; }
        public string Month { get; set; }
        public string Items { get; set; }
        public double Total { get; set; }

    }

    public class PhoneAllowanceClaimListDT : ResponseBase
    {
        public List<PhoneAllowanceClaimList> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class PhoneAllowanceClaimDetails : ResponseBase
    {
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public int SupplierId { get; set; }
        public double Total { get; set; }
    }


    public class MedicalClaimList
    {
        public int MedicalId { get; set; }
        public string Month { get; set; }
        public string Items { get; set; }
        public double Total { get; set; }

    }

    public class MedicalClaimListDT : ResponseBase
    {
        public List<MedicalClaimList> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class MedicalClaimDetails : ResponseBase
    {
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public string SupplierName { get; set; }
        public double Total { get; set; }
    }


    public class PurchaseItemClaimList
    {
        public int PurchaseId { get; set; }
        public string Month { get; set; }
        public string Items { get; set; }
        public double Total { get; set; }

    }

    public class PurchaseItemClaimListDT : ResponseBase
    {
        public List<PurchaseItemClaimList> result { get; set; }

        public PageInfo pageInfo { get; set; }

    }

    public class PurchaseItemClaimDetails : ResponseBase
    {
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public string SupplierName { get; set; }
        public double Total { get; set; }
    }


    public class ClaimAttachment
    {
        public int attachmentId { get; set; }
        public int travelId { get; set; }
        public int phoneId { get; set; }
        public int medicalId { get; set; }
        public int purchaseId { get; set; }
        public string attachmentURL { get; set; }
        public string description { get; set; }

    }

    public class ClaimAttachmentDT : ResponseBase
    {
        public List<ClaimAttachment> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class WaitingApprovalClaimList
    {
        public int ClaimId { get; set; }
        public string UserName { get; set; }
        public string Month { get; set; }
        public double Total { get; set; }
        public string StatusName { get; set; }

    }

    public class WaitingApprovalClaimListDT : ResponseBase
    {
        public List<WaitingApprovalClaimList> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class ApprovedClaimList
    {
        public int ClaimId { get; set; }
        public string UserName { get; set; }
        public string Month { get; set; }
        public double Total { get; set; }
        public string StatusName { get; set; }

    }

    public class ApprovedClaimListDT : ResponseBase
    {
        public List<ApprovedClaimList> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class ClaimReport : ResponseBase
    {
        public string TenantLogo { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string VehicleNumber { get; set; }
        public string Address { get; set; }
        public List<TravellingClaimReport> travelList { get; set; }
        public List<PhoneAllowanceClaimReport> phoneList { get; set; }
        public List<MedicalClaimReport> medicalList { get; set; }
        public List<PurchaseItemClaimReport> purchaseList { get; set; }
    }

    public class TravellingClaimReport
    {
        public string TravelDate { get; set; }
        public string ProjectCode { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public double Distance { get; set; }
        public double TotalMileage { get; set; }
        public double MealAllowance { get; set; }
        public double Accomodation { get; set; }
        public double Toll { get; set; }
        public double Parking { get; set; }
        public double TotalTravel { get; set; }

    }

    public class PhoneAllowanceClaimReport
    {
        public string Date { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public string SupplierName { get; set; }
        public double Total { get; set; }
    }

    public class MedicalClaimReport
    {
        public string Date { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public string SupplierName { get; set; }
        public double Total { get; set; }

    }

    public class PurchaseItemClaimReport
    {
        public string Date { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public string SupplierName { get; set; }
        public double Total { get; set; }
    }



    //-------------PUT-----------------

    public class UpdatePersonalClaim
    {
        public int ClaimId { get; set; }
        public string Date { get; set; }
        public string MonthId { get; set; }
        public string VehicleNumber { get; set; }
        public double TotalClaim { get; set; }
        public string RejectDescription { get; set; }
    }

    public class UpdateTravellingClaim
    {
        public int TravelId { get; set; }
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string ProjectCode { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public int VehicleId { get; set; }
        public double Distance { get; set; }
        public double TotalMileage { get; set; }
        public double MealAllowance { get; set; }
        public double Accomodation { get; set; }
        public double Toll { get; set; }
        public double Parking { get; set; }
        public double TotalAmount { get; set; }
    }


    public class UpdatePhoneAllowanceClaim
    {
        public int PhoneId { get; set; }
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public int SupplierId { get; set; }
        public double Total { get; set; }
    }

    public class UpdateMedicalClaim
    {
        public int MedicalId { get; set; }
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public string SupplierName { get; set; }
        public double Total { get; set; }
    }

    public class UpdatePurchaseClaim
    {
        public int PurchaseId { get; set; }
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public string SupplierName { get; set; }
        public double Total { get; set; }
    }

    public class UpdateClaimApprover
    {
        public int UserId { get; set; }
    }

    public class UpdateClaimApprovers
    {
        public int ClaimId { get; set; }
        public List<UpdateClaimApprover> UserIds { get; set; }
    }

    public class UpdateClaimStatus
    {
        public int ClaimId { get; set; }
        public string RejectDescription { get; set; }
    }


    //-------------POST-----------------

    public class InsertPersonalClaim
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string VehicleNumber { get; set; }
    }



    public class InsertTravellingClaim
    {
        public int ClaimId { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string ProjectCode { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public int VehicleId { get; set; }
        public double Distance { get; set; }
        public double TotalMileage { get; set; }
        public double MealAllowance { get; set; }
        public double Accomodation { get; set; }
        public double Toll { get; set; }
        public double Parking { get; set; }
        public double TotalAmount { get; set; }
    }


    public class InsertPhoneAllowanceClaim
    {
        public int ClaimId { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public int SupplierId{ get; set; }
        public double Total { get; set; }
    }

    public class InsertMedicalClaim
    {
        public int ClaimId { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public string SupplierName { get; set; }
        public double Total { get; set; }
    }

    public class InsertPurchaseItemClaim
    {
        public int ClaimId { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string BilNumber { get; set; }
        public string Items { get; set; }
        public string SupplierName { get; set; }
        public double Total { get; set; }
    }


    public class InsertClaimAttachment
    {
        public int attachmentId { get; set; }
        public int? claimId { get; set; } = null;
        public int travelId { get; set; }
        public int phoneId { get; set; }
        public int medicalId { get; set; }
        public int purchaseId { get; set; }
        public string attachmentURL { get; set; }
        public string description { get; set; }
    }




    //-------------DELETE-----------------

    public class DeletePersonalClaim
    {
        public int ClaimId { get; set; }
    }

    public class DeleteClaimItem
    {
        public int ClaimId { get; set; }
    }

    public class DeleteTravellingClaim
    {
        public int TravelId { get; set; }
    }


    public class DeletePhoneAllowanceClaim
    {
        public int PhoneId { get; set; }
    }

    public class DeleteMedicalClaim
    {
        public int MedicalId { get; set; }
    }

    public class DeletePurchaseItemClaim
    {
        public int PurchaseId { get; set; }
    }


    public class DeleteAttachmentClaim
    {
        public int claimId { get; set; }
        public int travelId { get; set; }
        public int phoneId { get; set; }
        public int medicalId { get; set; }
        public int purchaseId { get; set; }

    }


}
