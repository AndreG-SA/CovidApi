using Covid.Api.Models;
using Covid.Domain;
using System.Collections.Generic;

namespace Covid.Api.Mappers
{
    public interface ICountryCalculationService
    {
        List<CountryResponse> Calculate(List<string> continents, List<Statistics> countries);
    }
}
