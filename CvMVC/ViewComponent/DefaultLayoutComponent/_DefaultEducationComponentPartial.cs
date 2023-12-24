using CvUdemyMVC.CvMVC.Dtos.EducationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvMVC.ViewComponent.DefaultLayoutComponent;

public class _DefaultEducationComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultEducationComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7164/api/Education");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultEducationDto>>(jsonData);
        return View(values);
    }
}
