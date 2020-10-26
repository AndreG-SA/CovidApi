using Covid.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Covid.Api.Services
{
    public interface IConsolidatedDataService
    {
        Task<List<Statistics>> GetConsolidatedStatiticsAsync();
    }
}
