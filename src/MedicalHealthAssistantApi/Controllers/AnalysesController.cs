using MedicalHealthAssistantApi.Models;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Analyses;
using Service.Interfaces;

namespace MedicalHealthAssistantApi.Controllers;

public class AnalysesController
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
            Data = await this.analyseService.AddAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.analyseService.DeleteAsync(id)
        });

    [HttpDelete("remove/{id:long}")]
    public async Task<IActionResult> DestroyAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.AnalyseService.RemoveAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.AnalyseService.GetAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = AnalyseService.GetAll(@params)
        });

}
