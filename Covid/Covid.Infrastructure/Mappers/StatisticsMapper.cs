using Covid.Domain;
using Covid.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Covid.Infrastructure.Mappers
{
    public static class StatisticsMapper
    {
        public static List<Statistics> Map(List<StatisticsResponse> data )
        {
            if(data == null || data.Count == 0)
            {
                return new List<Statistics>();
            }
            return data.Select(s => new Statistics(s.Continent,s.Country,s.Population,
                                                   new Cases(s.Cases.New,s.Cases.Active,s.Cases.Critical,s.Cases.Recovered,s.Cases.Total),
                                                   new Deaths(s.Deaths.New,s.Deaths.Total),
                                                   s.Day,s.Time)).ToList();
        }
    }
}
