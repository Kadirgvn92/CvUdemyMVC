using CvUdemyMVC.CvMVC.Dtos.SkillDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvMVC.ViewComponent.DefaultLayoutComponent;

public class _DefaultSkillComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultSkillComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7164/api/Skill");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultSkillDto>>(jsonData);
        return View(values);
    }
}
