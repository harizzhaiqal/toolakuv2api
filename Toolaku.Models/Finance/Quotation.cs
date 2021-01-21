using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.Finance;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Finance
{
    public class QuotationInfoRequest
    {
        public int CustomerId { get; set; }
        public string QuotationTitle { get; set; }
        public string QuotationNo { get; set; }
        public string PONo { get; set; }
        public string QuotationDate { get; set; }
        public string ExpiryDate { get; set; }
        public string Notes { get; set; }
    }

    public class QuotationInfoUpdateRequest
    {
        public int QuotationId { get; set; }
        public int CustomerId { get; set; }
        public string QuotationTitle { get; set; }
        public string QuotationNo { get; set; }
        public string PONo { get; set; }
        public string QuotationDate { get; set; }
        public string ExpiryDate { get; set; }
        public string Notes { get; set; }
    }

    public class QuotationItemRequest
    {
        public int QuotationId { get; set; }
        public int ProductId { get; set; }
        public int ServiceId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class QuotationItemUpdateRequest
    {
        public int QuotationItemId { get; set; }
        public int ProductId { get; set; }
        public int ServiceId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class QuotationInfoView : ResponseBase
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string QuotationTitle { get; set; }
        public string QuotationNo { get; set; }
        public string PONo { get; set; }
        public string QuotationDate { get; set; }
        public string ExpiryDate { get; set; }
        public string Notes { get; set; }
    }

    public class QuotationItemListResponse
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
    }

    public class QuotationItemResponse : ResponseBase
    {
        public int ProductId { get; set; }
        public int ServiceId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }

    public class QuotationItemListResponses : ResponseBase
    {
        public List<QuotationItemListResponse> result { get; set; }
    }

    public class QuotationList
    {
        public int QuotationId { get; set; }
        public string QuotationNo { get; set; }
        public string QuotationDate { get; set; }
        public string CustomerName { get; set; }
        public double QuotationTotal { get; set; }
        public string Status { get; set; }
        public int QuotationStatusId { get; set; }
    }

    public class QuotationLists : ResponseBase
    {
        public List<QuotationList> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class QuotationInfoResponse : ResponseBase
    {
        public QuotationInfoResponse()
        {
            ReturnCode = 0;
            ResponseMessage = string.Empty;
        }

        public int QuotationId { get; set; }
    }

    public class ItemToRemove
    {
        public int ItemId { get; set; }
    }

    public class QuotationToRemove
    {
        public int QuotationId { get; set; }
    }

    public class ProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }

    public class ProductLists : ResponseBase
    {
        public List<ProductList> result { get; set; }
    }

    public class ServicesList
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }

    }
    public class ServicesLists : ResponseBase
    {
        public List<ServicesList> result { get; set; }
    }

    public class QuotationToConfirm
    {
        public int QuotationId { get; set; }
    }

    public class QuotationItemPreview
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
    }

    public class QuotationPreview : ResponseBase
    {
        public string TenantLogo { get; set; }
        public string TenantName { get; set; }
        public string TenantROCNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string QuotationNo { get; set; }
        public string QuotationDate { get; set; }
        public string ExpiresOn { get; set; }
        public double GrandTotal { get; set; }
        public string Notes { get; set; }

        public List<QuotationItemPreview> item { get; set; }

    }
}
