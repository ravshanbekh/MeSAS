using MedicalHealthAssistantWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Users;
using System.Diagnostics;

namespace MedicalHealthAssistantWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Signin()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Signin(UserCreationDto dto)
    {
        return View();
    } 

    public IActionResult Signup()
    {
        return View();
    }
    public IActionResult Signup(UserCreationDto dto)
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}