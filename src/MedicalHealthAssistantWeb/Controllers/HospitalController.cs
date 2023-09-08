using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace MedicalHealthAssistantWeb.Controllers;

public class HospitalController : Controller
{
    public readonly HospitalService HospitalService;
    public HospitalController(HospitalService hospitalService)
    {
        HospitalService = hospitalService;
    }
    public async Task<IActionResult> Index()
    {
        var result =await  HospitalService.GetAllHospitalsAsync();
        return View(result);
    }
}
