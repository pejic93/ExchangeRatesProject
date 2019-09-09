using ExchangeRatesProject.Models.InputExchangeModels;
using ExchangeRatesProject.Models.OutputExchangeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesProject.Interfaces.RatesServices
{
    public interface IRatesService
    {
        Task<ReturnModel> GetRates(InputExchangeDataModel data);
    }
}
