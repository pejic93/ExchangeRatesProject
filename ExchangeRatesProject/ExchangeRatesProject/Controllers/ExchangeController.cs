using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using ExchangeRatesProject.Interfaces.RatesServices;

using ExchangeRatesProject.Models.InputExchangeModels;
using ExchangeRatesProject.Models.OutputExchangeModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExchangeRatesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : BaseController
    {
        IRatesService _ratesService;
        public ExchangeController(IRatesService ratesService)
        {
            _ratesService = ratesService;
        }

        [HttpGet("get-rates")]
        public async Task<IActionResult> GetRates([FromBody]InputExchangeDataModel data)
        {
            var result = await _ratesService.GetRates(data);
            return Ok(result);
        }
    }
}