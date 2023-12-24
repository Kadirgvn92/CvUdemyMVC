using CvUdemyMVC.CvMVC.Dtos.EducationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CvMVC.Controllers;
public class EducationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EducationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7164/api/Education");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultEducationDto>>(jsonData);
            await Task.Delay(1500);
            return View(values);
        }
        await Task.Delay(1500);
        return View();
    }
    [HttpGet]
    public IActionResult CreateEducation()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateEducation(CreateEducationDto createEducationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createEducationDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7164/api/Education", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {

            await Task.Delay(1500);
            return RedirectToAction("Index");
        }

        await Task.Delay(1500);
        return View();
    }

    public async Task<IActionResult> DeleteEducation(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7164/api/Education/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();

    }
    [HttpGet]
    public async Task<IActionResult> UpdateEducation(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7164/api/Education/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateEducationDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateEducation(UpdateEducationDto updateEducationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateEducationDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7164/api/Education", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            await Task.Delay(1500);
            return RedirectToAction("Index");
        }
        await Task.Delay(1500);
        return View();
    }
}
