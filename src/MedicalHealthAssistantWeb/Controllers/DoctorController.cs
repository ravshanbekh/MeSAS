using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace MedicalHealthAssistantWeb.Controllers;

public class DoctorController : Controller
{
    private readonly DoctorService doctorService;

    public DoctorController(DoctorService doctorService)
    {
        this.doctorService = doctorService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await doctorService.GetAllDoctorsAsync();
        return View(result);
    }
    public IActionResult Create() 
    {
        return View();
    }

    public IActionResult Update()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }
}
