using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.Models;
using dotnetapp.Repository;
 
namespace dotnetapp.Service
{
    public class BookingServiceImpl : BookingService
    {
         private readonly IBookingRepo _bookingRepo;
        public BookingServiceImpl(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }
 
        public async Task<Booking> GetBookingByIdAsync(long id)
        {
            return await _bookingRepo.GetBookingByIdAsync(id);
        }
        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(long userId)
        {
            return await _bookingRepo.GetBookingsByUserIdAsync(userId);
        }
        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _bookingRepo.GetAllBookingsAsync();
        }
        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            return await _bookingRepo.AddBookingAsync(booking);
        }
 
        public async Task DeleteBookingAsync(long id)
        {
            await _bookingRepo.DeleteBookingAsync(id);
        }
        public async Task UpdateBookingStatusAsync(long id, string newStatus)
        {
            var booking = await _bookingRepo.GetBookingByIdAsync(id);
            if (booking != null)
            {
                booking.Status = newStatus;
                await _bookingRepo.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Booking not found.");
            }
        }
    }
}