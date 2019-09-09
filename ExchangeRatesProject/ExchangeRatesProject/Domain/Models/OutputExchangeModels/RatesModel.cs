using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesProject.Models.OutputExchangeModels
{
    public class RatesModel
    {
        public string Base { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public Dictionary<DateTime, Dictionary<string, double>> Rates { get; set; }
    }
}
