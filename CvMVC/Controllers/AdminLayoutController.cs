using Microsoft.AspNetCore.Mvc;

namespace CvMVC.Controllers;
public class AdminLayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
