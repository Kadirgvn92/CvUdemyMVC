using Microsoft.AspNetCore.Mvc;

namespace CvMVC.ViewComponent.DefaultLayoutComponent;

public class _DefaultCertificationComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
