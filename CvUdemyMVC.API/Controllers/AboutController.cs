using AutoMapper;
using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DtoLayer.AboutDto;
using CvUdemyMVC.EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace CvUdemyMVC.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    private readonly IAboutService _aboutService;
    private readonly IMapper _mapper;

    public AboutController(IAboutService aboutService, IMapper mapper)
    {
        _aboutService = aboutService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult AboutList()
    {
        var values = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateAbout(CreateAboutDto createAboutDto)
    {
        About about = _mapper.Map<About>(createAboutDto);
        _aboutService.TAdd(about);
        return Ok("About created");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAbout(int id)
    {
        var values = _aboutService.TGetByID(id);
        _aboutService.TDelete(values);
        return Ok("About deleted");
    }
    [HttpPut]
    public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
    {
        About about = _mapper.Map<About>(updateAboutDto);
        _aboutService.TUpdate(about);
        return Ok("About updated");
    }
    [HttpGet("{id}")]
    public IActionResult GetAbout(int id)
    {
        var values = _aboutService.TGetByID(id);
        return Ok(values);
    }
}
