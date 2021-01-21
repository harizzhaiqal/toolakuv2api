using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Public
{
    public class ServicePageDetail : ResponseBase
    {
        public List<ServiceImage> serviceImage { get; set; }
        public List<ServiceDetail> serviceDetail { get; set; }
        public List<ServiceDescription> description { get; set; }
        public List<ServiceCompanyProfile> companyProfile { get; set; }
    }
    public class ServiceDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ShortDescription { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
    }

        public class ServiceDescription
    {
        public string Name { get; set; }
        public string ServiceNo { get; set; }
        public string LongDescription { get; set; }
    }
    public class ServiceCompanyProfile
    {
        public string CompanyName { get; set; }
        public string DateIncorporated { get; set; }
        public string Country { get; set; }
        public string WebsiteName { get; set; }
        public string WebsiteURL { get; set; }

        public string LogoUrl { get; set; }
    }
    public class ServiceImage
    {
        public int ImageId { get; set; }
        public bool IsDefault { get; set; }
        public string ImageURL { get; set; }
    }
}
