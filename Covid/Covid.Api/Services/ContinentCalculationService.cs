using Covid.Api.Models;
using Covid.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Covid.Api.Mappers
{
    public class ContinentCalculationService : IContinentCalculationService
    {
        public List<ContinentResponse> Calculate(List<string> continents, List<Statistics> countries)
        {
            return continents.Select(s => new ContinentResponse(s,
                                                                MapTotals(s, countries, c => c.Cases.GetNewTotal()),
                                                                MapTotals(s, countries, c => c.Cases.Active),
                                                                MapTotals(s, countries, c => c.Deaths.Total)))
                             .OrderBy(o => o.Continent)
                             .ToList();
        }
        private TotalResponse MapTotals(string continent, List<Statistics> countries, Func<Statistics, int> func)
        {
            decimal total = countries.Sum(s => func(s));
            decimal countryTotal = countries.Where(w => w.Continent == continent).Sum(s => func(s));
            decimal percentage = countryTotal / total * 100m;
            return new TotalResponse((int)countryTotal, (int)Math.Round(percentage, 0));
        }
    }
}
