using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Service;
using dotnetapp.Repository;
using System.Collections.Generic;
 
[Route("/api/")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly BookingService _bookingService;
    private readonly IBookingRepo _bookingRepo;
 
    public BookingController(BookingService bookingService, IBookingRepo bookingRepo)
    {
        _bookingService = bookingService;
        _bookingRepo = bookingRepo;
    }
 
    [Authorize(Roles = "Admin,Customer")]  //get by bookingid
    [HttpGet("booking/{bookingId}")]
    public async Task<IActionResult> GetBooking(long bookingId)
    {
        var booking = await _bookingService.GetBookingByIdAsync(bookingId);
        if (booking == null)
        {
            return NotFound();
        }
 
        // double totalPrice = booking.Resort.Price.Value * booking.NoOfPersons.Value;
        // booking.TotalPrice = totalPrice;
 
        // double advancePayment = 0.3 * totalPrice;
        // booking.AdvPay = advancePayment;
 
        return Ok(booking);
    }
 
    [Authorize(Roles = "Admin,Customer")]    //get by userid
    [HttpGet("user/{UserId}")]
    public async Task<IActionResult> GetBookingsByUserId(long UserId)
    {
        try
        {
            var bookings = await _bookingRepo.GetBookingsByUserIdAsync(UserId);
            return Ok(bookings);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while fetching bookings for user {UserId}: {ex.Message}");
            return StatusCode(500);
        }
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("booking")]      //get all the booking
    public async Task<IActionResult> GetAllBookings()
    {
        try
        {
            var bookings = await _bookingRepo.GetAllBookingsAsync();
            return Ok(bookings);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while fetching all bookings: {ex.Message}");
            return StatusCode(500);
        }
    }
 
    [Authorize(Roles = "Customer")]
    [HttpPost("booking")]
    public async Task<IActionResult> AddBooking([FromBody] Booking booking)
    {
        try
        {
            if (booking == null)
            {
                return BadRequest("Booking data is null");
            }
 
            var addedBooking = await _bookingService.AddBookingAsync(booking);
            return Ok(new { Message = "Booking added successfully.", Booking = addedBooking });
        }
        catch (ArgumentNullException)
        {
            return BadRequest("Invalid booking data.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while adding booking: {ex.Message}");
        }
    }
 
    [Authorize(Roles = "Customer")]
    [HttpDelete("booking/{bookingId}")]
    public async Task<IActionResult> DeleteBooking(long bookingId)
    {
        try
        {
            await _bookingService.DeleteBookingAsync(bookingId);
            return Ok(new { Message = "Booking deleted successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while deleting booking: {ex.Message}");
        }
    }
 
   [Authorize(Roles = "Admin")]
[HttpPut("booking/{bookingId}")]
public async Task<IActionResult> UpdateBooking(long bookingId, [FromBody] Booking updatedBooking)
{
    if (bookingId != updatedBooking.BookingId)
    {
        return BadRequest();
    }
 
    var existingBooking = await _bookingRepo.GetBookingByIdAsync(bookingId);
    if (existingBooking == null)
    {
        return NotFound();
    }

    existingBooking.Status = updatedBooking.Status;
    // existingBooking.NoOfPersons = updatedBooking.NoOfPersons;
    // existingBooking.FromDate = updatedBooking.FromDate;
    // existingBooking.ToDate = updatedBooking.ToDate;
    // existingBooking.Address = updatedBooking.Address;
 
    await _bookingRepo.UpdateBookingAsync(existingBooking);
    var updatedData = await _bookingRepo.GetBookingByIdAsync(bookingId);
    return Ok(updatedData);
}
 
    // [Authorize(Roles = "Admin")]
    // [HttpPut("booking/{bookingId}")]
    // public async Task<IActionResult> UpdateBookingStatus(long bookingId, [FromBody] string newStatus)
    // {
    //     var booking = await _bookingRepo.GetBookingByIdAsync(bookingId);
    //     if (booking == null)
    //     {
    //         return NotFound();
    //     }
 
    //     booking.Status = newStatus;
 
    //     await _bookingRepo.UpdateBookingStatusAsync(bookingId, newStatus);
 
    //     return Ok(booking);
    // }
}