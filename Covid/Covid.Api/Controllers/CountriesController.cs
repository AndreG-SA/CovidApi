using Covid.Api.Mappers;
using Covid.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IConsolidatedDataService _consolidatedDataService;
        private readonly ICountryCalculationService _countryCalculationService;

        public CountriesController(IConsolidatedDataService consolidatedDataService,
                                   ICountryCalculationService countryCalculationService)
        {
            _consolidatedDataService = consolidatedDataService;
            _countryCalculationService = countryCalculationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var statistics     = await _consolidatedDataService.GetConsolidatedStatiticsAsync().ConfigureAwait(false);
            var continentNames = statistics.Where(w => w.IsCountry()).Select(s => s.Continent).Distinct().ToList();
            var response       = _countryCalculationService.Calculate(continentNames, statistics);
            return Ok(response);
        }
    }
}
