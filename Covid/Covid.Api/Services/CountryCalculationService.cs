using Covid.Api.Models;
using Covid.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Covid.Api.Mappers
{
    public class CountryCalculationService : ICountryCalculationService
    {
        public List<CountryResponse> Calculate(List<string> continents, List<Statistics> countries)
        {
            var returnValue = new List<CountryResponse>();
            foreach(var continent in continents)
            {
                var countriesOnContinent = countries.Where(w => w.Continent == continent).ToList();
                var countryResponses = countriesOnContinent.Select(s => new CountryResponse(continent, s.Country,
                                                                                            MapTotals(s, countriesOnContinent, c => c.Cases.GetNewTotal()),
                                                                                            MapTotals(s, countriesOnContinent, c => c.Cases.Active),
                                                                                            MapTotals(s, countriesOnContinent, c => c.Deaths.Total)))
                                                           .OrderBy(o => o.Continent).ThenBy(t => t.Country)
                                                           .ToList();
                returnValue.AddRange(countryResponses);
            }
            return returnValue;
        }

        private TotalResponse MapTotals(Statistics country, List<Statistics> countries, Func<Statistics,int> func)
        {
            decimal total        = countries.Sum(s => func(s));
            decimal countryTotal = func(country);
            decimal percentage   = countryTotal / total * 100m;
            return new TotalResponse((int)countryTotal, (int)Math.Round(percentage, 0));
        }
    }
}
