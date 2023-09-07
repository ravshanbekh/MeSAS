using MedicalHealthAssistantApi.Models;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Messages;
using Service.Interfaces;

namespace MedicalHealthAssistantApi.Controllers;

public class MessagesController : BaseController
{
    private readonly IMessageService messageService;
    public MessagesController(IMessageService messageService)
    {
        this.messageService = messageService;
    }

    [HttpPost("Message")]
    public async Task<IActionResult> PostAsync(MessageCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await messageService.CreateAsync(dto)
        });
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await messageService.DeleteAsync(id)
        });

    [HttpGet("api/get/id")]
    public async Task<IActionResult> GetById(long Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await messageService.GetAsync(Id)
        });

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await messageService.GetAllMessagesAsync()
        });

}
