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
    private readonly UserService _userService; // Inject UserService

 
    public BookingController(BookingService bookingService, IBookingRepo bookingRepo,UserService userService)
    {
        _bookingService = bookingService;
        _bookingRepo = bookingRepo;
        _userService = userService; // Assign injected UserService

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
 
    // [Authorize(Roles = "Customer")]
    // [HttpPost("booking")]
    // public async Task<IActionResult> AddBooking([FromBody] Booking booking)
    // {
    //     try
    //     {
    //         if (booking == null)
    //         {
    //             return BadRequest("Booking data is null");
    //         }
 
    //         var addedBooking = await _bookingService.AddBookingAsync(booking);
    //         return Ok(new { Message = "Booking added successfully.", Booking = addedBooking });
    //     }
    //     catch (ArgumentNullException)
    //     {
    //         return BadRequest("Invalid booking data.");
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, $"An error occurred while adding booking: {ex.Message}");
    //     }
    // }
 
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
  
    await _bookingRepo.UpdateBookingAsync(existingBooking);
    var updatedData = await _bookingRepo.GetBookingByIdAsync(bookingId);
    return Ok(updatedData);
}
 
[Authorize(Roles = "Customer")]
[HttpPost("booking")]
public async Task<IActionResult> AddBooking([FromBody] Booking booking)
{
    if (booking == null)
    {
        return BadRequest("Booking data is null");
    }

    try
    {
        if (booking.User != null && booking.User.UserId != booking.UserId)
        {
            booking.User = null;
        }

        var addedBooking = await _bookingService.AddBookingAsync(booking);

        // Fetch user details (including user name) based on the user ID in the booking
        long userId = booking.UserId ?? 0; // Convert nullable long to long, defaulting to 0 if null
        var user = await _userService.GetUserByIdAsync(userId);
        if (user == null)
        {
            // Handle the case where the user is not found (optional)
            return BadRequest("User not found");
        }

        // Include user details in the response
        var response = new
        {
            Booking = addedBooking,
            User = user
        };

        return Ok(response);
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"An error occurred while adding a booking: {ex.Message}");
    }
}

}