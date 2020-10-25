using Covid.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Covid.Infrastructure
{

    /// <summary>
    /// Infrastructure Service to handle service calls to underlying Rest client
    /// </summary>
    public interface IDataInfrastructureService
    {
        Task<List<StatisticsResponse>> GetStatisticsAsync();
    }
}
