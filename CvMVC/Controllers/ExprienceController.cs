using CvUdemyMVC.CvMVC.Dtos.ExprienceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CvMVC.Controllers;
public class ExprienceController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ExprienceController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7164/api/Exprience");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultExprienceDto>>(jsonData);
            await Task.Delay(1500);
            return View(values);
        }
        await Task.Delay(1500);
        return View();
    }
    [HttpGet]
    public IActionResult CreateExprience()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateExprience(CreateExprienceDto createExprienceDto, IFormFile imageFile)
    {
        //if (imageFile != null && imageFile.Length > 0)
        //{
        //	// Kullanıcının seçtiği dosya adını kullanarak dosyayı kaydet
        //	var filePath = "/uploads/" + imageFile.FileName;
        //	using (var stream = new FileStream(filePath, FileMode.Create))
        //	{
        //		imageFile.CopyTo(stream);
        //	}

        //	createExprienceDto.Image = filePath;
        //}
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createExprienceDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7164/api/Exprience", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {

            await Task.Delay(1500);
            return RedirectToAction("Index");
        }

        await Task.Delay(1500);
        return View();
    }

    public async Task<IActionResult> DeleteExprience(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7164/api/Exprience/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();

    }
    [HttpGet]
    public async Task<IActionResult> UpdateExprience(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7164/api/Exprience/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateExprienceDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateExprience(UpdateExprienceDto updateExprienceDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateExprienceDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7164/api/Exprience", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            await Task.Delay(1500);
            return RedirectToAction("Index");
        }
        await Task.Delay(1500);
        return View();
    }
}
