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

    public IActionResult Index()
    {
        //var result = await userService.GetAllUsersAsync();
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

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await this.userService.DeleteAsync(id);
        return RedirectToRoute(new { controller = "User", action = "Index" });
    }
}
