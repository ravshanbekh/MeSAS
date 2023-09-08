using Domain.Configuration;
using Domain.Enums;
using MedicalHealthAssistantApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Users;
using Service.Interfaces;

namespace MedicalHealthAssistantApi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;
        public UserController(IUserService userService,IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
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
        public async Task<IActionResult> GetById(string token)
        {
            long Id = JwtHelper.GetUserIdFromTokenAsync(token,configuration);

            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await userService.GetAsync(Id)
            });
        }

        [Authorize(Roles="SuperAdmin")]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams @params)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await userService.GetAllUsersAsync(@params)
            });
        [HttpPatch("upgrade-role")]
        public async ValueTask<IActionResult> UpgradeRoleAsync(long id, UserRole role)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.UpgradeRoleAsync(id, role)
        });
    }
}

