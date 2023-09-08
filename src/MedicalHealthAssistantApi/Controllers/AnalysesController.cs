using MedicalHealthAssistantApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Analyses;
using Service.Interfaces;
using System.Data;

namespace MedicalHealthAssistantApi.Controllers;

public class AnalysesController : Controller

{
    private readonly IAnalyseService analyseService;
    public AnalysesController(IAnalyseService analyseService)
    {
        this.analyseService = analyseService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddAsync(AnalyseCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.analyseService.CreateAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.analyseService.DeleteAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.analyseService.GetAsync(id)
        });

    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data =await analyseService.GetAllAnalysesAsync()
        });
}
