using Domain.Configuration;
using Domain.Enums;
using MedicalHealthAssistantApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Attachments;
using Service.DTOs.Users;
using Service.Interfaces;
using System.Security.Claims;

namespace MedicalHealthAssistantApi.Controllers;

public class UserController : Controller
{
    private readonly IMessageService messageService;
    private readonly IUserService userService;
    public UserController(IUserService userService,IMessageService messageService)
    {
        this.userService = userService;
        this.messageService = messageService;
    }

    [HttpPost("User")]
    public async Task<IActionResult> PostAsync(UserCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.CreateAsync(dto)
        });
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.DeleteAsync(id)
        });

    [HttpPut("Update")]

    public async Task<IActionResult> PutAsync(UserViewUpdate dto)
    {
        long id = Convert.ToInt32(HttpContext.User.FindFirstValue("Id"));
        var dtoUser = new UserUpdateDto() 
        {
            Id=id,
            Role=dto.Role,
            Phone=dto.Phone,
            Address=dto.Address,
            LastName=dto.LastName,
            Password=dto.Password,
            FirstName=dto.FirstName,
            AttachmentId=dto.AttachmentId,
        };

        return Ok(new Response
           {
               StatusCode = 200,
               Message = "Succes",
               Data = await userService.UpdateAsync(dtoUser)
           });
    }

    [HttpGet("api/get/id")]
    public async Task<IActionResult> GetById(long Id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.GetAsync(Id)
        });
    }
    [HttpGet("api/get/current/user")]
    public async Task<IActionResult> GetByCurrentUser()
    {
        var id = Convert.ToInt32(HttpContext.User.FindFirstValue("Id"));
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.GetAsync(id)
        });
    }

    //[Authorize(Roles="SuperAdmin")]
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.GetAllUsersAsync(@params)
        });

    [Authorize(Roles ="SuperAdmin")]
    [HttpPatch("upgrade-role")]
    public async ValueTask<IActionResult> UpgradeRoleAsync(long id, UserRole role)
    => Ok(new Response
    {
        StatusCode = 200,
        Message = "Success",
        Data = await this.userService.UpgradeRoleAsync(id, role)
    });

    [HttpPost("image-upload")]
    public async Task<IActionResult> UploadImageAsync(long id, [FromForm] AttachmentCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.ImageUploadAsync(id, dto)
        }
            );

    [HttpGet("getLast-userMessage")]
    public async Task<IActionResult> GetLastMessage()
    {
        int id = Convert.ToInt32(HttpContext.User.FindFirstValue("Id"));
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = (await messageService.GetAllMessagesAsync()).Where(x => x.UserId.Equals(id)).LastOrDefault().MessageBody
        });
    }

    [HttpGet("getall-userMessage")]
    public async Task<IActionResult> GetAllMessage()
    {
        int id = Convert.ToInt32(HttpContext.User.FindFirstValue("Id"));
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = (await messageService.GetAllMessagesAsync()).Where(x => x.UserId.Equals(id)).Select(x=>x.MessageBody).ToList()
        });
    }

}

