using Microsoft.AspNetCore.Mvc;

namespace CvMVC.Controllers;
public class UILayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
