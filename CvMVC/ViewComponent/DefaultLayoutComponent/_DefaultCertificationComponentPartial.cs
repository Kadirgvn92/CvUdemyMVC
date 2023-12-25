using CvUdemyMVC.CvMVC.Dtos.CertificationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvMVC.ViewComponent.DefaultLayoutComponent;

public class _DefaultCertificationComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultCertificationComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7164/api/Certification");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCertificationDto>>(jsonData);
        return View(values);
    }
}
