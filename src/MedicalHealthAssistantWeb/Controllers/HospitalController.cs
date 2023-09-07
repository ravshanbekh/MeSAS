using Microsoft.AspNetCore.Mvc;

namespace MedicalHealthAssistantWeb.Controllers
{
    public class HospitalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
