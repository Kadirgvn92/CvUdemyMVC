using Microsoft.AspNetCore.Mvc;

namespace CvMVC.ViewComponent.LayoutComponent;

public class _LayoutFooterComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}
