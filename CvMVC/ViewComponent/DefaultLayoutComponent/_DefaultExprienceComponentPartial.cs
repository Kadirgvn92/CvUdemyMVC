using CvUdemyMVC.CvMVC.Dtos.ExprienceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvMVC.ViewComponent.DefaultLayoutComponent;

public class _DefaultExprienceComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultExprienceComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7164/api/Exprience");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultExprienceDto>>(jsonData);
        return View(values);
    }
}
