using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Profile
{
    public class ProfileShareholder
    {
        public double AuthorizeCapital { get; set; }
        public double PreferenceShares { get; set; }
        public double ValuePreferenceShares { get; set; }
        public double OrdinaryShares { get; set; }
        public double ValueOrdinaryShares { get; set; }
    }

    public class ProfileShareholders : ResponseBase
    {
        public IList<ProfileShareholder> Result { get; set; }
    }

    public class UserSettingInfo : ResponseBase
    {
        public string ProfileImage { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int UserRole { get; set; }
    }
}
