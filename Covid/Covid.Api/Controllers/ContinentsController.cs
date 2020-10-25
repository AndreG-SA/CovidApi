using Covid.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Covid.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContinentsController : ControllerBase
    {
        private readonly IDataInfrastructureService _dataInfrastructureService;

        public ContinentsController(IDataInfrastructureService dataInfrastructureService)
        {
            _dataInfrastructureService = dataInfrastructureService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var statistics = await _dataInfrastructureService.GetStatisticsAsync().ConfigureAwait(false);
            return Ok();
        }
    }
}
