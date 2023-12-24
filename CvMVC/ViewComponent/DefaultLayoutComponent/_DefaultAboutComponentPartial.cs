using CvUdemyMVC.CvMVC.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvMVC.ViewComponent.DefaultLayoutComponent;

public class _DefaultAboutComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultAboutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7164/api/About");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
        return View(values);
    }
}
