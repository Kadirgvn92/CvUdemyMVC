using CvUdemyMVC.CvMVC.Dtos.CertificationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CvMVC.Controllers;
public class CertificationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CertificationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7164/api/Certification");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCertificationDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateCertification()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCertification(CreateCertificationDto createCertificationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createCertificationDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7164/api/Certification", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {

            await Task.Delay(1500);
            return RedirectToAction("Index");
        }

        await Task.Delay(1500);
        return View();
    }

    public async Task<IActionResult> DeleteCertification(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7164/api/Certification/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();

    }
    [HttpGet]
    public async Task<IActionResult> UpdateCertification(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7164/api/Certification/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateCertificationDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCertification(UpdateCertificationDto updateCertificationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateCertificationDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7164/api/Certification", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            await Task.Delay(1500);
            return RedirectToAction("Index");
        }
        await Task.Delay(1500);
        return View();
    }
}
