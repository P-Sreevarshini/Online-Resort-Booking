using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.Models;
using dotnetapp.Repository;

namespace dotnetapp.Service
{
    public class ResortServiceImpl : ResortService
    {
        private readonly ResortRepo _repository;

        public ResortServiceImpl(ResortRepo repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Resort>> GetAllResortsAsync()
        {
            return await _repository.GetAllResortsAsync();
        }

        public async Task<Resort> AddResortAsync(Resort resort)
        {
            return await _repository.AddResortAsync(resort);
        }

        public async Task<Resort> UpdateResortAsync(long id, Resort resort)
        {
            return await _repository.UpdateResortAsync(id, resort);
        }

        public async Task<Resort> DeleteResortAsync(long id)
        {
            return await _repository.DeleteResortAsync(id);
        }
        public async Task<Resort> GetResortByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
