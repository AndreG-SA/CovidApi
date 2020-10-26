using Covid.Domain;
using Covid.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid.Api.Services
{
    /// <summary>
    /// Get a list of countries and then get the history for each country
    /// Process the requests async to try and make it a bit faster
    /// </summary>

    public class ConsolidatedDataService : IConsolidatedDataService
    {
        private readonly IDataInfrastructureService _dataInfrastructureService;

        public ConsolidatedDataService(IDataInfrastructureService dataInfrastructureService)
        {
            _dataInfrastructureService = dataInfrastructureService;
        }

        public async Task<List<Statistics>> GetConsolidatedStatiticsAsync()
        {
            var returnValue = new List<Statistics>();
            var dateToQuery = DateTime.Now;
            var countries   = await _dataInfrastructureService.GetCountriesAsync().ConfigureAwait(false);
            countries       = countries.Select(s => s.CleanCountryNames()).Distinct().ToList();
            var semaphore   = new Semaphore(1, 1);

            await countries.ForEachAsync(20, async country =>
            {
                var countryStatisitics = await _dataInfrastructureService.GetStatisticsForCountryAsync(country, dateToQuery).ConfigureAwait(false);
                if (countryStatisitics != null || countryStatisitics.Count > 0)
                {
                    var countryStatistics = countryStatisitics.OrderBy(o => o.Time).FirstOrDefault();
                    if (countryStatistics != null)
                    {
                        semaphore.WaitOne(); //Synchronise access to the List, I am not sure if List.Add is thread safe 
                        returnValue.Add(countryStatistics);
                        semaphore.Release();
                    }
                }
            }).ConfigureAwait(false);

            return returnValue;
        }
    }
}
