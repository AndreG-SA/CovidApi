using Covid.Domain;
using Covid.Infrastructure.Mappers;
using Covid.Infrastructure.Models;
using System;
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

        private const string _statisticsRoute = "history?day={0}&country={1}";
        private const string _countriesRoute = "countries";

        public DataInfrastructureService(ISecuredServiceClient securedServiceClient)
        {
            _securedServiceClient = securedServiceClient;
        }
        public async Task<List<string>> GetCountriesAsync()
        {
            var result = await _securedServiceClient.GetAsync<ResponseWrapper<List<string>>>(_countriesRoute).ConfigureAwait(false);
            return result.Response;
        }
        public async Task<List<Statistics>> GetStatisticsForCountryAsync(string country, DateTime day)
        {
            var query = string.Format(_statisticsRoute, day.ToString("yyyy-MM-dd"),country);
            var result = await _securedServiceClient.GetAsync<ResponseWrapper<List<StatisticsResponse>>>(query).ConfigureAwait(false);
            return StatisticsMapper.Map( result.Response);
        }
    }
}
