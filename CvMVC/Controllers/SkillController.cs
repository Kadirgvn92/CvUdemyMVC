using CvUdemyMVC.CvMVC.Dtos.SkillDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CvMVC.Controllers;
public class SkillController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SkillController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7164/api/Skill");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSkillDto>>(jsonData);
            await Task.Delay(1500);
            return View(values);
        }
        await Task.Delay(1500);
        return View();
    }
    [HttpGet]
    public IActionResult CreateSkill()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSkill(CreateSkillDto createSkillDto, IFormFile imageFile)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createSkillDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7164/api/Skill", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {

            await Task.Delay(1500);
            return RedirectToAction("Index");
        }

        await Task.Delay(1500);
        return View();
    }

    public async Task<IActionResult> DeleteSkill(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7164/api/Skill/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();

    }
    [HttpGet]
    public async Task<IActionResult> UpdateSkill(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7164/api/Skill/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateSkillDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSkill(UpdateSkillDto updateSkillDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateSkillDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7164/api/Skill", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            await Task.Delay(1500);
            return RedirectToAction("Index");
        }
        await Task.Delay(1500);
        return View();
    }
}
