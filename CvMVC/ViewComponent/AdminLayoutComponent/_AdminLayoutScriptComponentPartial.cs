using Microsoft.AspNetCore.Mvc;

namespace CvMVC.ViewComponent.AdminLayoutComponent;

public class _AdminLayoutScriptComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();	
	}
}
