using System;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Models.Profile
{
    public class GeneralInfoRequest
    {
        public string CoverImgUrl { get; set; }
        public string LogoImgUrl { get; set; }
        public string CompanyName { get; set; }
        public string BRNo { get; set; }
        public string DateIncorporated { get; set; }
        public string Form9URL { get; set; }
        public string Form13URL { get; set; }
        public string CountryId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Postcode { get; set; }
        public string CityId { get; set; }
        public string StateId { get; set; }
        public string City { get; set; }
    }
}
