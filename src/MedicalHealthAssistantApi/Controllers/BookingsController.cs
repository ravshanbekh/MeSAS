using MedicalHealthAssistantApi.Models;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Bookings;
using Service.Interfaces;

namespace MedicalHealthAssistantApi.Controllers;

public class BookingsController :BaseController
{
    private readonly IBookingService bookingService;
    public BookingsController(IBookingService bookingService)
    {
        this.bookingService = bookingService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddAsync(BookingCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.bookingService.CreateAsync(dto)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(BookingUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.bookingService.UpdateAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.bookingService.DeleteAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.bookingService.GetAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = bookingService.GetAllBookingsAsync()
        });

}
