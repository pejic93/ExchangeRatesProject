using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesProject.Models.InputExchangeModels
{
    public class InputExchangeDataModel
    {
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public List<DateTime> Dates { get; set; }
    }
}
