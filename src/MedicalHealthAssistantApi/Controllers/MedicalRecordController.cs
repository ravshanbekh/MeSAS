using MedicalHealthAssistantApi.Models;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.MedicalRecords;
using Service.Interfaces;

namespace MedicalHealthAssistantApi.Controllers
{
    public class MedicalRecordController : BaseController
    {
        private readonly IMedicalRecordService MedicalRecordService;
        public MedicalRecordController(IMedicalRecordService MedicalRecordService)
        {
            this.MedicalRecordService = MedicalRecordService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddAsync(MedicalRecordCreationDto dto)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.MedicalRecordService.CreateAsync(dto)
            });

        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.MedicalRecordService.DeleteAsync(id)
            });


        [HttpGet("get/{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.MedicalRecordService.GetAsync(id)
            });

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllsync()
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data =await MedicalRecordService.GetAllMedicalRecordsAsync()
            });
    }
}
