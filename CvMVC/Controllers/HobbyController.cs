using CvUdemyMVC.CvMVC.Dtos.HobbyDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CvMVC.Controllers;
public class HobbyController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HobbyController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7164/api/Hobby");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultHobbyDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateHobby()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateHobby()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7164/api/Hobby/{2}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateHobbyDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateHobby(UpdateHobbyDto updateHobbyDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateHobbyDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7164/api/Hobby", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            Thread.Sleep(1500);
            return View();
        }

        Thread.Sleep(1500);
        return View();
    }
}
