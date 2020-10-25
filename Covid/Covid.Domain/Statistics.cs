using System;

namespace Covid.Domain
{
    public class Statistics
    {
        public string Continent { get; set; }

        public string Country { get; set; }

        public int? Population { get; set; }

        public Cases Cases { get; set; }

        public Deaths Deaths { get; set; }

        public string Day { get; set; }

        public DateTime Time { get; set; }
    }

}
