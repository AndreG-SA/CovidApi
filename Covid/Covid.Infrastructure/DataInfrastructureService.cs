using Covid.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Covid.Infrastructure
{
    /// <summary>
    /// Infrastructure Service to handle service calls to underlying Rest client
    /// </summary>
    public class DataInfrastructureService : IDataInfrastructureService
    {
        private readonly ISecuredServiceClient _securedServiceClient;

        private const string _statisticsRoute = "statistics";

        public DataInfrastructureService(ISecuredServiceClient securedServiceClient)
        {
            _securedServiceClient = securedServiceClient;
        }
        public async Task<List<StatisticResponse>> GetStatisticsAsync()
        {
            var result = await _securedServiceClient.GetAsync<ResponseWrapper<List<StatisticResponse>>>(_statisticsRoute);
            return result.Response;
        }
    }
}
