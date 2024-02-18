using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
 
namespace dotnetapp.Repository
{
    public class ResortRepo
    {
        private readonly ApplicationDbContext _context;
 
        public ResortRepo(ApplicationDbContext context)
        {
            _context = context;
        }
 
        public async Task<IEnumerable<Resort>> GetAllResortsAsync()
        {
            return await _context.Resorts.ToListAsync();
        }
 
        public async Task<Resort> AddResortAsync(Resort resort)
        {
            _context.Resorts.Add(resort);
            await _context.SaveChangesAsync();
            return resort;
        }
 
       public async Task<Resort> UpdateResortAsync(long id, Resort resort)
{
    var existingResort = await _context.Resorts.FindAsync(id);
    if (existingResort == null)
    {
        return null; // Resort not found
    }
 
    // Update existing resort properties with the new values
    existingResort.ResortName = resort.ResortName;
    existingResort.ResortImageUrl = resort.ResortImageUrl;
    existingResort.ResortLocation = resort.ResortLocation;
    existingResort.ResortAvailableStatus = resort.ResortAvailableStatus;
    existingResort.Price = resort.Price;
    existingResort.Capacity = resort.Capacity;
    existingResort.Description = resort.Description;
 
    // Save changes to the database
    await _context.SaveChangesAsync();
 
    return existingResort;
}
 
 
        public async Task<Resort> DeleteResortAsync(long id)
        {
            var resort = await _context.Resorts.FindAsync(id);
            if (resort == null)
            {
                return null;
            }
 
            _context.Resorts.Remove(resort);
            await _context.SaveChangesAsync();
            return resort;
        }
         public async Task<Resort> GetByIdAsync(long id)
        {
            return await _context.Resorts.FindAsync(id);
        }
    }
}