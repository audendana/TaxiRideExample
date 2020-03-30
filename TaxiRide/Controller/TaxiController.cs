using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiRide.Model;
using TaxiRide.TaxiServices;

namespace TaxiRide.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiController : ControllerBase
    {
        private ITaxiService _taxiService;

        public TaxiController(ITaxiService taxiService)
        {
            _taxiService = taxiService;
        }

        [HttpGet]
        public string GetRideCost()
        {
            if (!_taxiService.GetErrorFlag())
            {
                return _taxiService.GetRideCost();
            }
            return _taxiService.GetErrorMessage();
        }

        [HttpPost]
        public void Post([FromBody] TaxiRideModel taxiRide)
        {
            _taxiService.CalculateTaxiRideCost(taxiRide);
        }
    }
}