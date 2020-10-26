using Covid.Api.Models;
using Covid.Domain;
using System.Collections.Generic;

namespace Covid.Api.Mappers
{
    public interface IContinentCalculationService
    {
        List<ContinentResponse> Calculate(List<string> continents, List<Statistics> countries);
    }
}
