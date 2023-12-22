﻿using CvUdemyMVC.CvMVC.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace CvMVC.Controllers;
public class AboutController : Controller
{
	private readonly IHttpClientFactory _httpClientFactory;

	public AboutController(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<IActionResult> Index()
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync("https://localhost:7164/api/About");
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
			await Task.Delay(1500);
			return View(values);
		}
		await Task.Delay(1500);
		return View();
	}
	[HttpGet]
	public IActionResult CreateAbout()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto, IFormFile imageFile)
	{
		if (imageFile != null && imageFile.Length > 0)
		{
			// Kullanıcının seçtiği dosya adını kullanarak dosyayı kaydet
			var filePath = "/uploads/" + imageFile.FileName;
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				imageFile.CopyTo(stream);
			}

			createAboutDto.Image = filePath;
		}
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(createAboutDto);
		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
		var responseMessage = await client.PostAsync("https://localhost:7164/api/About", stringContent);

		if (responseMessage.IsSuccessStatusCode)
		{
			
			await Task.Delay(1500);
			return RedirectToAction("Index");
		}

		await Task.Delay(1500);
		return View();
	}

	public async Task<IActionResult> DeleteAbout(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.DeleteAsync($"https://localhost:7164/api/About/{id}");
		if (responseMessage.IsSuccessStatusCode)
		{
			return RedirectToAction("Index");
		}
		return View();

	}
	[HttpGet]
	public async Task<IActionResult> UpdateAbout(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync($"https://localhost:7164/api/About/{id}");
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
			return View(values);
		}
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
	{
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(updateAboutDto);
		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
		var responseMessage = await client.PutAsync("https://localhost:7164/api/About", stringContent);
		if (responseMessage.IsSuccessStatusCode)
		{
			await Task.Delay(1500);
			return RedirectToAction("Index");
		}
		await Task.Delay(1500);
		return View();
	}
}
