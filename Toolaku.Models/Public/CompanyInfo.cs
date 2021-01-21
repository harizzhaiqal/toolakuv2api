using System.Collections.Generic;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Public
{
    public class CompanyInfo
    {
        public string BannerImg { get; set; }
        public string LogoImg { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationNo { get; set; }
        public string DateIncorporated { get; set; }
        public string RegisteredAddress { get; set; }
        public string AuthorizeCapital { get; set; }
        public string TotalEmployees { get; set; }
    }

    public class CompanyOverView : ResponseBase
    {
        public List<HeaderWebsite> headerInfo { get; set; }
        public List<GeneralInfo> generalInfo { get; set; }
        public List<Branch> branchList { get; set; }
        public List<CorporateReg> corporateList { get; set; }
        public List<Certification> certificateList { get; set; }
        public List<Award> awardList { get; set; }
        public List<WebsiteItem> productList { get; set; }
        public List<WebsiteItem> serviceList { get; set; }
    }


    public class CompanyProductList : ResponseBase
    {       
        public List<WebsiteItem> productList { get; set; }
        public PageInfo pageInfo { get; set; }
    }


    public class CompanyServiceList : ResponseBase
    {
        public List<WebsiteItem> serviceList { get; set; }
        public PageInfo pageInfo { get; set; }
    }

    public class HeaderWebsite
    {
        public string BannerImg { get; set; }
        public string LogoImg { get; set; }
        public string CompanyName { get; set; }
    }

    public class Branch
    {
        public string BranchImg { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
    }

    public class CorporateReg
    {
        public string CorporateImg { get; set; }
        public string CorporateName { get; set; }
    }

    public class Certification
    {
        public string CertificationImg { get; set; }
        public string CertName { get; set; }
        public string IssuedBy { get; set; }
        public string DateIssued { get; set; }
    }
    public class Award
    {
        public string AwardImg { get; set; }
        public string AwardName { get; set; }
        public string AwardBy { get; set; }
        public string DateAwarded { get; set; }
    }
    public class GeneralInfo
    {
        public string RegistrationNo { get; set; }
        public string DateIncorporated { get; set; }
        public string RegisteredAddress { get; set; }
        public string AuthorizeCapital { get; set; }
        public string TotalEmployees { get; set; }
    }

    public class WebsiteItem
    {
        public int Id { get; set; }
        public string DefaultImage { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
