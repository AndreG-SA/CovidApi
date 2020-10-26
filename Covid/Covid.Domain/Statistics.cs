using System;

namespace Covid.Domain
{
    /// <summary>
    /// Statistics domain model
    /// </summary>
    public class Statistics
    {
        private const string _AllContinentsIdentifier = "All";

        public string Continent { get; }

        public string Country { get; }

        public int? Population { get; }

        public Cases Cases { get; }

        public Deaths Deaths { get; }

        public string Day { get; }

        public DateTime Time { get; }

        public Statistics(string continent, string country, int? population, Cases cases,
                          Deaths deaths, string day, DateTime time)
        {
            Continent  = continent;
            Country    = country;
            Population = population;
            Cases      = cases;
            Deaths     = deaths;
            Day        = day;
            Time       = time;
        }

        //public bool IsContinent()
        //{
        //    return string.IsNullOrWhiteSpace(Continent) == false &&
        //           string.IsNullOrWhiteSpace(Country) == false &&
        //           Continent == Country &&
        //           Continent != _AllContinentsIdentifier;
        //}

        public bool IsCountry()
        {
            return string.IsNullOrWhiteSpace(Continent) == false &&
                   string.IsNullOrWhiteSpace(Country) == false &&
                   Continent != Country &&
                   Continent != _AllContinentsIdentifier;
        }

    }
}
