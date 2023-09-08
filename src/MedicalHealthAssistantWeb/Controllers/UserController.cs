using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace MedicalHealthAssistantWeb.Controllers;

public class UserController : Controller
{
    private IUserService userService;
    
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    public async  Task<IActionResult> Index()
    {
        var result = await userService.GetAllUsersAsync();
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
