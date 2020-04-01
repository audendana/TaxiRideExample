using System;
using TaxiRide.Controller;
using TaxiRide.Model;
using TaxiRide.TaxiServices;
using Xunit;

namespace UnitTests
{
    public class UnitTest
    {
        private string ExpectedErrorMessage = "You entered an invalid format into an input field try again";
        [Fact]
        public void TaxiServiceCalculateCostTest()
        {
            var taxiRide = new TaxiRideModel();
            var taxiService = new TaxiService();

            taxiRide.NumOfMinutesAboveSixMPH = 5;
            taxiRide.NumOfMilesBelowSixMPH = 2;
            taxiRide.DateOfRide = "Friday (2010-10-08)";
            taxiRide.TimeOfStart = "5:30pm";

            taxiService.CalculateTaxiRideCost(taxiRide);
            taxiRide.CostOfRide = taxiService.GetRideCost();
            Assert.Equal("$9.75", taxiRide.CostOfRide);
        }

        [Fact]
        public void TaxiServiceCalculateCostInvalidTime()
        {
            var taxiRide = new TaxiRideModel();
            var taxiService = new TaxiService();

            taxiRide.NumOfMinutesAboveSixMPH = 5;
            taxiRide.NumOfMilesBelowSixMPH = 2;
            taxiRide.DateOfRide = "Friday (2010-10-08)";
            taxiRide.TimeOfStart = "xx5:30pm";

            taxiService.CalculateTaxiRideCost(taxiRide);
            taxiRide.ErrorMessage= taxiService.GetErrorMessage();
            Assert.Equal(ExpectedErrorMessage, taxiRide.ErrorMessage);
        }
        [Fact]
        public void TaxiServiceCalculateCostInvalidDate()
        {
            var taxiRide = new TaxiRideModel();
            var taxiService = new TaxiService();

            taxiRide.NumOfMinutesAboveSixMPH = 5;
            taxiRide.NumOfMilesBelowSixMPH = 2;
            taxiRide.DateOfRide = "Thurssday(2010-10-08)";
            taxiRide.TimeOfStart = "5:30pm";

            taxiService.CalculateTaxiRideCost(taxiRide);
            taxiRide.ErrorMessage= taxiService.GetErrorMessage();
            Assert.Equal(ExpectedErrorMessage, taxiRide.ErrorMessage);
        }
        [Fact]
        public void TaxiControllerGetRequest()
        { // should return null bc we are calling get on a empty value 
            var taxiService = new TaxiService();
            var taxiController = new TaxiController(taxiService);

            var result = taxiController.GetRideCost();
            Assert.Null(result);
        }
    }
}
