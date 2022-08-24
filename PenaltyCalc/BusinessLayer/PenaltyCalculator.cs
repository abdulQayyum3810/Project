using PenaltyCalc.DataLayer;
using PenaltyCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalc.BusinessLayer
{
    public class PenaltyCalculator:IPenaltyCalculator
    {
        ISqlDataHelper _sqlDataHelper;
        public PenaltyCalculator(ISqlDataHelper sqlDataHelper)
        {
            _sqlDataHelper = sqlDataHelper; 
        }

        public double CalculatePalenty(string checkout, string checkin, string countryName)
        {

            Country country = _sqlDataHelper.GetCountryData(countryName);
            DateTime checkoutDate = DateTime.Parse(checkout);
            DateTime checkinDate = DateTime.Parse(checkin);

            List<int> weekend = country.Weekend.Select(wd => wd.DayCode).ToList();
            List<DateTime> holidays = country.Holidays.Select(h => h.HolidayDate).ToList();

            int businessDays = CalculateBusinessDays(checkoutDate, checkinDate, weekend, holidays);

            double palenty = PenaltyCalculatorAlgo(businessDays, country.SpecialTax, country.PalentyAmount);

            return palenty;
        }
        

        public double PenaltyCalculatorAlgo(int businessDays,double specialTax,double palentyPerDay)
        {
            double palenty = 0;
            if (businessDays < 10)
            {
                return palenty;
            }

            palenty = businessDays * palentyPerDay;
            palenty += palenty * (specialTax / 100);
            return palenty;
        }
        public int CalculateBusinessDays(DateTime checkout, DateTime checkin, List<int> weekend, List<DateTime> holidays)
        {
            int businessDays = 0;
            for (DateTime currentDate = checkout; currentDate <= checkin; currentDate=currentDate.AddDays(1))
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
