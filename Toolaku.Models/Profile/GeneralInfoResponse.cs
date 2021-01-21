using System;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Profile
{
    public class GeneralInfoResponse : ResponseBase
    {
        public GeneralInfoResponse()
        {
            ReturnCode = 0;
            ResponseMessage = string.Empty;
        }

        public string CoverImgUrl { get; set; }
        public string LogoImgUrl { get; set; }
        public string CompanyName { get; set; }
        public string BRNo { get; set; }
        public string DateIncorporated { get; set; }
        public string Form9URL { get; set; }
        public string Form13URL { get; set; }
        public int CountryId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Postcode { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
    }

    public class TenantEditionInfoResponse : ResponseBase
    {
        public string TenantName { get; set; }
        public int TenantId { get; set; }
        public int EditionId { get; set; }
    }

    public class TenantEditionInfoUpsert : ResponseBase
    {
       
        public int TenantId { get; set; }
        public int EditionId { get; set; }
    }
}
