using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Finance
{
    public class InvoiceInfoRequest
    {
        public int CustomerId { get; set; }
        public string InvoiceTitle { get; set; }
        public string InvoiceNo { get; set; }
        public string PONo { get; set; }
        public string InvoiceDate { get; set; }
        public string DueDate { get; set; }
    }

    public class InvoiceInfoResponse : ResponseBase
    {
        public InvoiceInfoResponse()
        {
            ReturnCode = 0;
            ResponseMessage = string.Empty;
        }

        public int InvoiceId { get; set; }
    }

    public class InvoiceItemRequest
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int ServiceId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class InvoiceList
    {
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string CustomerName { get; set; }
        public double InvoiceTotal { get; set; }
        public double AmountDue { get; set; }
        public string Status { get; set; }
    }

    public class InvoiceLists : ResponseBase
    {
        public List<InvoiceList> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class InvoiceInfoView : ResponseBase
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceTitle { get; set; }
        public string InvoiceNo { get; set; }
        public string PONo { get; set; }
        public string InvoiceDate { get; set; }
        public string DueDate { get; set; }
        public string Reasons { get; set; }
    }

    public class InvoiceItemListResponse
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
    }

    public class InvoiceItemListResponses : ResponseBase
    {
        public List<InvoiceItemListResponse> result { get; set; }
    }

    public class InvoiceItemResponse : ResponseBase
    {
        public int ProductId { get; set; }
        public int ServiceId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }

    public class InvoiceInfoUpdateRequest
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceTitle { get; set; }
        public string InvoiceNo { get; set; }
        public string PONo { get; set; }
        public string InvoiceDate { get; set; }
        public string PaymentDue { get; set; }
    }
    public class InvoiceItemUpdateRequest
    {
        public int InvoiceItemId { get; set; }
        public int ProductId { get; set; }
        public int ServiceId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class InvoiceToRemove
    {
        public int InvoiceId { get; set; }
    }

    public class InvoiceToApprove
    {
        public int InvoiceId { get; set; }
        public string Reason { get; set; }
        public int StatusId { get; set; }
    }

    public class InvoiceReceipt
    {
        public int InvoiceId { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptNo { get; set; }
        public double Amount { get; set; }
        public int PaymentMethodId { get; set; }
        public string Notes { get; set; }
    }

    public class InvoicePaymentDue : ResponseBase
    {
        public double PaymentDue { get; set; }
    }

    public class ReceipListResponses : ResponseBase
    {
        public List<ReceipListResponse> result { get; set; }
    }

    public class ReceipListResponse : ResponseBase
    {
        public int ReceiptId { get; set; }
        public string ReceiptDate { get; set; }
        public string PaymentMethod { get; set; }
        public double Amount { get; set; }
    }

    public class ReceiptToRemove
    {
        public int ReceiptId { get; set; }
    }

    public class InvoiceItemPreview
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
    }

    public class ReceiptItemPreview
    {
        public string PaymentOn { get; set; }
        public double Amount { get; set; }
    }

    public class InvoicePreview : ResponseBase
    {
        public string TenantLogo { get; set; }
        public string TenantName { get; set; }
        public string TenantROCNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string PaymentDue { get; set; }
        public double AmountDue { get; set; }
        public double Total { get; set; }

        public List<InvoiceItemPreview> item { get; set; }
        public List<ReceiptItemPreview> payment { get; set; }

    }

    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string MethodName { get; set; }
    }

    public class PaymentMethods : ResponseBase
    {
        public List<PaymentMethod> methodList { get; set; }
    }

    public class ReceiptPreview : ResponseBase
    {
        public string TenantLogo { get; set; }
        public string TenantName { get; set; }
        public string TenantROCNo { get; set; }
        public string ReceiptNo { get; set; }
        public string CustomerName { get; set; }
        public string ReceiptDate { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Notes { get; set; }

    }

    public class InvoiceToConfirm
    {
        public int InvoiceId { get; set; }
    }

    public class InvoiceIdAfterConvert : ResponseBase
    {
        public int InvoiceId { get; set; }
    }
}
