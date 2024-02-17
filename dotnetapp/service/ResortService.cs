using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Service
{
    public interface ResortService
    {
        Task<IEnumerable<Resort>> GetAllResortsAsync();
        Task<Resort> AddResortAsync(Resort resort);
        Task<Resort> UpdateResortAsync(long id, Resort resort);
        Task<Resort> DeleteResortAsync(long id);
    }
}
