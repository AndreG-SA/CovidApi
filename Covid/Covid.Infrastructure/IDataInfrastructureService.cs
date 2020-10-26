using Covid.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Covid.Infrastructure
{

    /// <summary>
    /// Infrastructure Service to handle service calls to underlying Rest client
    /// </summary>
    public interface IDataInfrastructureService
    {
        Task<List<Statistics>> GetStatisticsForCountryAsync(string country, DateTime day);
        Task<List<string>> GetCountriesAsync();
    }
}
