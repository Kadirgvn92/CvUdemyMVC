using Microsoft.AspNetCore.Mvc;

namespace CvMVC.ViewComponent.DefaultLayoutComponent;

public class _DefaultAboutComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    { return View(); }
}
