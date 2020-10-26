
using System.Text.RegularExpressions;

namespace Covid.Domain
{
    /// <summary>
    /// Cases domain model
    /// </summary>
    public class Cases
    {
        public string New { get; }
        
        public int Active { get; }
        
        public int Critical { get; }
        
        public int Recovered { get; }
        
        public int Total { get; }

        public Cases(string @new, int active, int critical, int recovered, int total)
        {
            New       = @new;
            Active    = active;
            Critical  = critical;
            Recovered = recovered;
            Total     = total;
        }

        public int GetNewTotal()
        {
            if(string.IsNullOrWhiteSpace(New))
            {
                return 0;
            }
            var sanitisedString = Regex.Replace(New, @"[^\d]", "");
            int returnValue = 0;
            if(int.TryParse(sanitisedString, out returnValue) == false)
            {
                returnValue = 0;
            }
            return returnValue;
        }
    }

}
