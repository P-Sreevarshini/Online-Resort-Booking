using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using dotnetapp.Models;
using System.Collections.Generic;
 
namespace dotnetapp.Repository
{
    public interface IBookingRepo
    {
        Task<Booking> GetBookingByIdAsync(long id);
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(long userId);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> AddBookingAsync(Booking booking);
        Task DeleteBookingAsync(long id);
        Task UpdateBookingAsync(Booking booking);
        Task UpdateBookingStatusAsync(long id, string newStatus);
        Task SaveChangesAsync();
    }
 
    public class BookingRepo : IBookingRepo
    {
        private readonly ApplicationDbContext _context;
 
        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }
 
        public async Task<Booking> GetBookingByIdAsync(long id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
        }
        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
        return await _context.Bookings.Include(b => b.Resort).ToListAsync();
        }
        // public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(long userId)
        // {
        //     return await _context.Bookings.Where(b => b.UserId == userId).ToListAsync();
        // }
        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(long userId)
        {
            return await _context.Bookings
                                .Where(b => b.UserId == userId)
                                .Include(b => b.Resort)
                                .ToListAsync();
        }

 
        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            Console.WriteLine(booking);
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
 
        public async Task UpdateBookingStatusAsync(long id, string newStatus)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                booking.Status = newStatus;
                await _context.SaveChangesAsync();
            }
        }
 
        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
 
        public async Task DeleteBookingAsync(long id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
 
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}