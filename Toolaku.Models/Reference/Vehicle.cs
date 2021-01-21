using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Reference
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        /*public float VehicleRate { get; set; }*/
    }

    public class Vehicles : ResponseBase
    {
        public List<Vehicle> Result { get; set; }
    }
}
