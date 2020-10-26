
namespace Covid.Domain
{
    /// <summary>
    /// Deaths domain model
    /// </summary>
    public class Deaths
    {
        public string New { get; }

        public int Total { get; }

        public Deaths(string @new, int total)
        {
            New   = @new;
            Total = total;
        }
    }
}
