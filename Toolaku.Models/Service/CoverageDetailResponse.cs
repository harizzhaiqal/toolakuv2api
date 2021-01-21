using Toolaku.Models.DTO;

namespace Toolaku.Models.Service
{
    public class CoverageDetailResponse : ResponseBase
    {
        public int serviceId { get; set; }
        public int countryId { get; set; }
        public int stateId { get; set; } 
        public int cityId { get; set; }
    }

}
