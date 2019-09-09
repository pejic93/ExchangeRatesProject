using ExchangeRatesProject.Interfaces.RatesServices;
using ExchangeRatesProject.Models.InputExchangeModels;
using ExchangeRatesProject.Models.OutputExchangeModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeRatesProject.Services.RatesServices
{
    public class ExchangeRatesService : IRatesService
    {
        public async Task<ReturnModel> GetRates(InputExchangeDataModel data)
        {
            HttpClient httpClient = new HttpClient();

            var sortedDates = await SortDatesAsc(data.Dates);
            var firstDate = sortedDates.First().ToString("yyyy-MM-dd");
            var lastDate = sortedDates.Last().ToString("yyyy-MM-dd");

            string url = $"https://api.exchangeratesapi.io/history?symbols={data.BaseCurrency},{data.TargetCurrency}&base={data.BaseCurrency}&start_date={firstDate}&end_date={lastDate}";

            var response = await httpClient.GetAsync(url);
            var responseObject = await response.Content.ReadAsAsync<RatesModel>();

            var result = await GetValues(responseObject);

            return result;
        }

        private async Task<ReturnModel> GetValues(RatesModel response)
        {
            List<double> _rates = new List<double>();
            double min = Double.MaxValue;
            double max = 0;
            DateTime dateOnMax = DateTime.UnixEpoch, dateOnMin = DateTime.UnixEpoch;
            foreach (var r in response.Rates)
            {
                if (r.Value.Values.First() > max)
                {
                    max = r.Value.Values.First();
                    dateOnMax = r.Key;
                }
                else if (r.Value.Values.First() < min)
                {
                    min = r.Value.Values.First();
                    dateOnMin = r.Key;
                }
                _rates.Add(r.Value.Values.First());
            }

            var result = new ReturnModel(_rates.Average(), min, max, dateOnMin, dateOnMax);

            return result;
        }

        private static async Task<List<DateTime>> SortDatesAsc(List<DateTime> list)
        {
            list.Sort((a, b) => a.CompareTo(b));
            return list;
        }
    }
}
