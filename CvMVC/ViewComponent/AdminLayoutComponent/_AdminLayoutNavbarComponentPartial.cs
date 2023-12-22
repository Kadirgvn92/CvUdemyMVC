using Microsoft.AspNetCore.Mvc;

namespace CvMVC.ViewComponent.AdminLayoutComponent;

public class _AdminLayoutNavbarComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}
