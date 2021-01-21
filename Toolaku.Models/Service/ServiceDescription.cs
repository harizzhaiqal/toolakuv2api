using Toolaku.Models.DTO;

namespace Toolaku.Models.Service
{
    public class ServiceDescription : ResponseBase
    {
        public int serviceId { get; set; }
        public string description { get; set; }
    }
    public class ServiceDescriptionUpdate
    {
        public int serviceId { get; set; }
        public string description { get; set; }
    }
}
