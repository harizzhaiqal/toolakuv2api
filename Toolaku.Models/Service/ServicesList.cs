using System.Collections.Generic;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Services
{
    public class ServicesList
    {
        public int serviceId { get; set; }
        public string imageURL { get; set; }
        public string serviceName { get; set; }
        public string serviceNo { get; set; }
        public string category { get; set; }
        public bool listing { get; set; }
    }
    public class ServicesLists : ResponseBase
    {
        public List<ServicesList> result { get; set; }
        public PageInfo pageInfo { get; set; }
    }
}
