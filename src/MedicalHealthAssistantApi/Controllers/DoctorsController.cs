using MedicalHealthAssistantApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Doctors;
using Service.Interfaces;
using System.Data;

namespace MedicalHealthAssistantApi.Controllers;

public class DoctorsController : BaseController
{
    private readonly IDoctorService doctorService;
    public DoctorsController(IDoctorService doctorService)
    {
        this.doctorService = doctorService;
    }

    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpPost("create")]
    public async Task<IActionResult> AddAsync(DoctorCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.doctorService.CreateAsync(dto)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(DoctorUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.doctorService.UpdateAsync(dto)
        });
    
    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.doctorService.DeleteAsync(id)
        });
    
    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.doctorService.GetAsync(id)
        });
    
    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await doctorService.GetAllDoctorsAsync()
        });
}
