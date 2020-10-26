
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
    }

}
