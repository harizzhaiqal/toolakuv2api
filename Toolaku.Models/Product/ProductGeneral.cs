using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Product
{
    public class ProductGeneral
    {
        public string productName { get; set; }
        public string shortDescription { get; set; }
        public string skuNo { get; set; }
        public string brand { get; set; }
        public string modelNo { get; set; }
        public int conditionId { get; set; }
        public int productMaterialId { get; set; }
        public int countryOriginId { get; set; }
        public bool activeStatus { get; set; }

    }

    public class ProductGeneralRequest
    {
        public string productName { get; set; }
        public string shortDescription { get; set; }
        public string skuNo { get; set; }
        public string brand { get; set; }
        public string modelNo { get; set; }
        public int conditionId { get; set; }
        public int productMaterialId { get; set; }
        public int countryOriginId { get; set; }
        public bool activeStatus { get; set; }

        public List<ProductImageRequest> imageList { get; set; }
    }

    public class ProductGeneralUpdate
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string shortDescription { get; set; }
        public string skuNo { get; set; }
        public string brand { get; set; }
        public string modelNo { get; set; }
        public int conditionId { get; set; }
        public int productMaterialId { get; set; }
        public int countryOriginId { get; set; }
        public bool activeStatus { get; set; }

        public List<ProductImageRequest> imageList { get; set; }
    }

    public class ProductImageList
    {
        public int productImageId { get; set; }
        public string imageURL { get; set; }
        public bool isDefault { get; set; }
    }

    public class ProductImageRequest
    {
        public string imageURL { get; set; }
        public bool isDefault { get; set; }
    }

    public class ProductVariant
    {
        public int productVariantId { get; set; }
        public int productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }



        public class ProductGenerals : ResponseBase
    {
        public List<ProductGeneral> basicInfo { get; set; }
        public List<ProductImageList> imageList { get; set; }
        public List<ProductVariant> productVariantList { get; set; }
    }
}
