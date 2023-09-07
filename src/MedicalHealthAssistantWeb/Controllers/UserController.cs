using Microsoft.AspNetCore.Mvc;

namespace MedicalHealthAssistantWeb.Controllers;

public class UserController : Controller
{
    public IActionResult Index()
    {
        
        return View();
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
