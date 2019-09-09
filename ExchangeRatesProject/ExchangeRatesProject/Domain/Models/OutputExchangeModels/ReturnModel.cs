using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesProject.Models.OutputExchangeModels
{
    public class ReturnModel
    {
        public ReturnModel(double average, double minExchangeRate, double maxExchangeRate, DateTime dateOnMinRate, DateTime dateOnMaxRate)
        {
            AvgExchangeRate = average;
            MinExchangeRate = minExchangeRate;
            MaxExchangeRate = maxExchangeRate;
            DateOnMaxRate = dateOnMaxRate;
            DateOnMinRate = dateOnMinRate;
        }

        public double AvgExchangeRate { get; set; }
        public double MinExchangeRate { get; set; }
        public Double MaxExchangeRate { get; set; }
        public DateTime DateOnMinRate { get; set; }
        public DateTime DateOnMaxRate { get; set; }
    }
}
