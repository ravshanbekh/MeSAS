using Domain.Configuration;
using MedicalHealthAssistantApi.Models;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Users;
using Service.Interfaces;

namespace MedicalHealthAssistantApi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
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

        public async Task<IActionResult> PutAsync(UserUpdateDto dto)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await userService.UpdateAsync(dto)
            });

        [HttpGet("api/get/id")]
        public async Task<IActionResult> GetById(long Id)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await userService.GetAsync(Id)
            });

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams @params)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await userService.GetAllUsersAsync(@params)
            });
    }
}

