using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiRide.Model
{
    public class TaxiRideModel
    {
        public int NumOfMinutesAboveSixMPH { get; set; }
        public int NumOfMilesBelowSixMPH { get; set; }
        public string DateOfRide { get; set; }
        public string TimeOfStart { get; set; }
        public string CostOfRide { get; set; }
        public string ErrorMessage { get; set; }
        public bool ErrorFlag { get; set; }
    }
}
