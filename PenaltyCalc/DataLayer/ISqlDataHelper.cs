using PenaltyCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalc.DataLayer
{
    public interface ISqlDataHelper
    {
         Country GetCountryData(string countryName);

    }
    
}
