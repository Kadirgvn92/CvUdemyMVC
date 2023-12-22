using Microsoft.AspNetCore.Mvc;

namespace CvMVC.Controllers;
public class DefaultController : Controller
{
    public IActionResult Index()
    {  
        return View();
    }
}
