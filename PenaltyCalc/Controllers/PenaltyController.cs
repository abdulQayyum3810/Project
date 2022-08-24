using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace PenaltyCalc.Controllers
{
    public class InputData
    {
        public string Checkout { get; set; }
        public string Checkin { get; set; }
        public string CountryName { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PenaltyController : ControllerBase
    {
        [Route("PalentyCalc")]
        [HttpPost]
        public double Palenty([FromBody] InputData data)
        {
            return 700;
        }
        [Route("Countries")]
        [HttpGet]
        public List<string> Countries()
        {
            return new List<string>() { "Pakistan", "UAE" };
        }
        [Route("test")]
        [HttpPost]

        public List<string> test([FromBody] InputData data)
        {
            return new List<string>() { data.Checkout, data.Checkin, data.CountryName };
        }
        [Route("BusinessDays")]
        [HttpPost]
        public int BusinessDays([FromBody] InputData data)

        {
            DateTime checkout = DateTime.Parse(data.Checkout);
            DateTime checkin = DateTime.Parse(data.Checkin);
            List<int> weekend = new List<int>() { 0, 6 };
            List<DateTime> holidays = new List<DateTime>() { DateTime.Parse("2022-08-14"), DateTime.Parse("2022-08-08"), DateTime.Parse("2022-08-09") };
            int businessDays = 0;
            for (DateTime currentDate = checkout; currentDate <= checkin; currentDate = currentDate.AddDays(1))
            {
                int currentDayOfWeek = Convert.ToInt32(currentDate.DayOfWeek);
                if (!(weekend.Contains(currentDayOfWeek) || holidays.Contains(currentDate)))
                {
                    businessDays++;
                }

            }
            return businessDays;
        }

    }
}