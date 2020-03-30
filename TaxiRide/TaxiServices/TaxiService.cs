using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaxiRide.Model;

namespace TaxiRide.TaxiServices
{
    public class TaxiService: ITaxiService
    {
        public static TaxiRideModel _taxiRide = new TaxiRideModel();
        public static IList<string> DaysOfWeek = new List<String>() { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };

        public string GetRideCost()
        {
            return _taxiRide.CostOfRide;
        }

        public string GetErrorMessage()
        {
            return _taxiRide.ErrorMessage;
        }

        public bool GetErrorFlag()
        {
            return _taxiRide.ErrorFlag;
        }

        public void CalculateTaxiRideCost(TaxiRideModel taxiRide)
        {
            try
            {
                //account for if the ride starts at 7:58PM on a friday then we need to switch from weekday surcharge to night after 3 mintues
                double costOfRide = 3.00;
                const double unitCharge = .35;
                const double weekdayCharge = 1.00;
                const double taxCharge = .50;
                const double nightCharge = .50;
                bool AM = false;


                double costBelowSix = (taxiRide.NumOfMilesBelowSixMPH / .2) * unitCharge;
                double costAboveSix = (taxiRide.NumOfMinutesAboveSixMPH * unitCharge);

                // check if its AM or PM
                AM = taxiRide.TimeOfStart.ToLower().Contains("pm") ? false : true;

                //Get HH time digits
                int timeSplit = Convert.ToInt32(taxiRide.TimeOfStart.Split(':')[0]);

                //Get Day of the week
                string dateSplit = taxiRide.DateOfRide.Split(' ')[0].ToLower();

                // if it doesnt equal these then we know its mon - fri
                if (!dateSplit.Equals(DaysOfWeek[5]) && !dateSplit.Equals(DaysOfWeek[6]))
                {
                    if ((timeSplit >= 4 && timeSplit <= 8) && !AM)
                    {
                        costOfRide += weekdayCharge;
                    }
                }

                // surcharge for the nightly by $.5
                if ((AM && timeSplit >= 1 && timeSplit <= 6) || (!AM && timeSplit >= 8 && timeSplit <= 12))
                {
                    costOfRide += nightCharge;
                }
                costOfRide += costBelowSix;
                costOfRide += costAboveSix;
                costOfRide += taxCharge;
                _taxiRide.CostOfRide = costOfRide.ToString("C2");
                _taxiRide.ErrorFlag = false;
                _taxiRide.ErrorMessage = "";
            } catch (Exception)
            {
                _taxiRide.ErrorFlag = true;
                _taxiRide.ErrorMessage = "You entered an invalid format into an input field try again";
                return;
            }
        }
    }
}
