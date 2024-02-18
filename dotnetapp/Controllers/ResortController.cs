using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using dotnetapp.Models;
using dotnetapp.Service;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization.Roles;
using Microsoft.AspNetCore.Authorization;
 
 
namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 // [Authorize(Roles = "Admin")]
 
    public class ResortController : ControllerBase
    {
        private readonly ResortService _resortService;
 
        public ResortController(ResortService resortService)
        {
            _resortService = resortService;
        }
       
      [Authorize(Roles = "Customer,Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resort>>> Get()
        {
            var resorts = await _resortService.GetAllResortsAsync();
            return Ok(resorts);
        }
      [Authorize(Roles = "Admin")]
 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Resort resort)
        {
            try
            {
                if (resort == null)
                    return BadRequest("Resort data is null");
 
                resort.Bookings = null;
 
                var newResort = await _resortService.AddResortAsync(resort);
                return CreatedAtAction(nameof(Get), new { id = newResort.ResortId }, newResort);
            }
            catch (Exception ex)
            {
                // return StatusCode(500, "Internal server error");
                return StatusCode(500, ex);
 
 
            }
        }
  [Authorize(Roles = "Admin")]
 
    [HttpPut("{ResortId}")]
    public async Task<IActionResult> Put(long ResortId, [FromBody] Resort resort) // Use the same parameter name as in the route
    {
        try
        {
            if (resort == null || resort.ResortId != ResortId)
                return BadRequest("Invalid resort data");
            var updatedResort = await _resortService.UpdateResortAsync(ResortId, resort);
            if (updatedResort == null)
            {
                return NotFound();
            }
 
            return Ok(updatedResort);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }
 
 
  [Authorize(Roles = "Admin")]
 
    [HttpDelete("{ResortId}")]
    public async Task<IActionResult> Delete(long ResortId) // Use the same parameter name as in the route
    {
        try
        {
            var deletedResort = await _resortService.DeleteResortAsync(ResortId);
            if (deletedResort == null)
            {
                return NotFound();
            }
            return Ok(deletedResort);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }
    [Authorize(Roles = "Customer,Admin")]
    [HttpGet("{ResortId}")]
    public async Task<ActionResult<Resort>> Get(long ResortId)
    {
        try
        {
            var resort = await _resortService.GetResortByIdAsync(ResortId);
            if (resort == null)
            {
                return NotFound();
            }
            return Ok(resort);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }

 
    }
}