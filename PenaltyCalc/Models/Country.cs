using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalc.Models
{
    public class Country
    {
        public string Name { get; set; }
        public double PalentyAmount { get; set; }
        public double SpecialTax { get; set; }
        public string Currency { get; set; }
        public List<Weekend> Weekend { get; set; }
        public List<Holiday> Holidays { get; set; }

    }
}
