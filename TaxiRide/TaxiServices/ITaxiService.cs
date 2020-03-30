using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiRide.Model;

namespace TaxiRide.TaxiServices
{
    public interface ITaxiService
    {
        string GetRideCost();

        string GetErrorMessage();
        bool GetErrorFlag();
        void CalculateTaxiRideCost(TaxiRideModel taxiRide);
    }
}
