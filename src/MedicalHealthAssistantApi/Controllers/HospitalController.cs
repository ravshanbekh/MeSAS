using MedicalHealthAssistantApi.Models;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Hospitals;
using Service.Interfaces;

namespace MedicalHealthAssistantApi.Controllers;

public class HospitalController : BaseController
{
    private readonly IHospitalService hospitalService;
    private readonly IMessageService messageService;

    public HospitalController(IHospitalService hospitalService, IMessageService messageService)
    {
        this.hospitalService = hospitalService;
        this.messageService = messageService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddAsync(HospitalCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.hospitalService.CreateAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.hospitalService.DeleteAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.hospitalService.GetAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllasync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await hospitalService.GetAllHospitalsAsync()
        });
}
