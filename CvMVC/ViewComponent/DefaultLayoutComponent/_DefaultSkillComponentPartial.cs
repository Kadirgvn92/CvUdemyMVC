using Microsoft.AspNetCore.Mvc;

namespace CvMVC.ViewComponent.DefaultLayoutComponent;

public class _DefaultSkillComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
