using System;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Models.Service
{
    public class ServiceToRemove
    {
        public int serviceId { get; set; }
    }

    public class ServicesToRemove
    {
        public List<ServiceToRemove> ids { get; set; }
    }
}
