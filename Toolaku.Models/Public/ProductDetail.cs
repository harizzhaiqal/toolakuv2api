using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Public
{
    public class PageDetail : ResponseBase
    {
        public List<ProductImage> productImage { get; set; }
        public List<ProductDetail> productDetail { get; set; }
        public List<Description> description { get; set; }
        public List<CompanyProfile> companyProfile { get; set; }
    }
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ShortDescription { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
    }

    public class SearchCount
    {
        public int TotalProduct { get; set; }
        public int TotalService { get; set; }
        public int TotalCompany { get; set; }
    }

    public class Description
    {
        public string Name { get; set; }
        public string SKUNo { get; set; }
        public string Brand { get; set; }
        public string ModelNo { get; set; }
        public string Condition { get; set; }
        public string Material { get; set; }
        public string CountryOrigin { get; set; }
        public string LongDescription { get; set; }
    }
    public class CompanyProfile
    {
        public string CompanyName { get; set; }
        public string DateIncorporated { get; set; }
        public string Country { get; set; }
        public string WebsiteName { get; set; }
        public string WebsiteURL { get; set; }
        public string LogoUrl { get; set; }
    }
    public class ProductImage
    {
        public int ImageId { get; set; }
        public bool IsDefault { get; set; }
        public string ImageURL { get; set; }
    }
}
