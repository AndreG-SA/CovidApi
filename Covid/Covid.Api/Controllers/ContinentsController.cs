using Covid.Api.Mappers;
using Covid.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContinentsController : ControllerBase
    {
        private readonly IContinentCalculationService _continentCalculationService;
        private readonly IConsolidatedDataService _consolidatedDataService;

        public ContinentsController(IContinentCalculationService continentCalculationService,
                                    IConsolidatedDataService consolidatedDataService)
        {
            _continentCalculationService = continentCalculationService;
            _consolidatedDataService     = consolidatedDataService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var statistics     = await _consolidatedDataService.GetConsolidatedStatiticsAsync().ConfigureAwait(false);
            var continentNames = statistics.Where(w => w.IsCountry()).Select(s => s.Continent).Distinct().ToList();
            var response       = _continentCalculationService.Calculate(continentNames, statistics);
            return Ok(response);
        }
    }
}
