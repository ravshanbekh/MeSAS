using MedicalHealthAssistantApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Hospitals;
using Service.DTOs.Messages;
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
    
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost("create")]
    public async Task<IActionResult> AddAsync(HospitalCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.hospitalService.CreateAsync(dto)
        });

    [Authorize(Roles = "SuperAdmin")]
    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.hospitalService.DeleteAsync(id)
        });

    [Authorize(Roles = "SuperAdmin")]
    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.hospitalService.GetAsync(id)
        });
    
    [Authorize(Roles = "SuperAdmin")]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllasync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await hospitalService.GetAllHospitalsAsync()
        });


    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpPost("create-message")]
    public async Task<IActionResult> PostMessageAsync(MessageCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await messageService.CreateAsync(dto)
        });


    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpDelete("delete-message")]
    public async Task<IActionResult> DeleteMessageAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await messageService.DeleteAsync(id)
        });


    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpGet("getall-message")]
    public async Task<IActionResult> GetAll()
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Succes",
           Data = await messageService.GetAllMessagesAsync()
       });


    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpGet("api/get/id/message")]
    public async Task<IActionResult> GetByIdMessageAsync(long Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await messageService.GetAsync(Id)
        });
}
