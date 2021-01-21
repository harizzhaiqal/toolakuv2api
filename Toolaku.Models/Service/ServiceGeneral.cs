using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Service
{
    public class ServiceGeneral
    {
        public string serviceName { get; set; }
        public string shortDescription { get; set; }
        public string serviceNo { get; set; }
        public bool activeStatus { get; set; }
    }

    public class ServiceImageList
    {
        public int serviceImageId { get; set; }
        public string imageURL { get; set; }
        public bool isDefault { get; set; }
    }

    public class ServiceGenerals : ResponseBase
    {
        public List<ServiceGeneral> basicInfo { get; set; }
        public List<ServiceImageList> imageList { get; set; }
        public List<ServiceVariant> serviceVariantList { get; set; }
    }

    public class ServiceGeneralRequest
    {
        public string serviceName { get; set; }
        public string shortDescription { get; set; }
        public string serviceNo { get; set; }
        public bool activeStatus { get; set; }

        public List<ServiceImageRequest> imageList { get; set; }
    }

    public class ServiceImageRequest
    {
        public string imageURL { get; set; }
        public bool isDefault { get; set; }
    }

    public class ServiceVariant
    {
        public int serviceVariantId { get; set; }
        public int serviceId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }


    public class ServiceGeneralUpdate
    {
        public int serviceId { get; set; }
        public string serviceName { get; set; }
        public string shortDescription { get; set; }
        public string serviceNo { get; set; }
        public bool activeStatus { get; set; }

        public List<ServiceImageRequest> imageList { get; set; }
    }
}
