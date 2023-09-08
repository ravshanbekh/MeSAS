using MedicalHealthAssistantWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Users;
using Service.Interfaces;
using System.Diagnostics;

namespace MedicalHealthAssistantWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService userService;
    public HomeController(ILogger<HomeController> logger, IUserService userService)
    {
        _logger = logger;
        this.userService = userService;
    }

    public IActionResult Signin()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Signin(UserCreationDto dto)
    {
        var result = await this.userService.CreateAsync(dto);
        return View(result);
    }

    [HttpPost]
    public IActionResult Signup(UserCreationDto dto)
    {
        return View();
    }
    public IActionResult Signup()
    {
        return View();
    }



    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult AdminPage()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}