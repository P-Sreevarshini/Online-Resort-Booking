using System.Threading.Tasks;
using dotnetapp.Models;
 
namespace dotnetapp.Service
{
    public interface BookingService
    {
         Task<Booking> GetBookingByIdAsync(long id);
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(long userId);
        Task<IEnumerable<Booking>> GetAllBookingsAsync(); // Add this method to the interface
        Task<Booking> AddBookingAsync(Booking booking);
        Task DeleteBookingAsync(long id);
        Task UpdateBookingStatusAsync(long id, string newStatus);
 
    }
}