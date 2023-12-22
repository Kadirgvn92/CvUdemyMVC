using AutoMapper;
using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DtoLayer.EducationDto;
using CvUdemyMVC.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvUdemyMVC.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EducationController : ControllerBase
{
    private readonly IEducationService _educationService;
    private readonly IMapper _mapper;

    public EducationController(IEducationService educationService, IMapper mapper)
    {
        _educationService = educationService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult EducationList()
    {
        var values = _educationService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateEducation(CreateEducationDto createEducationDto)
    {
        Education education = _mapper.Map<Education>(createEducationDto);
        _educationService.TAdd(education);
        return Ok("Education created");
    }
    [HttpDelete]
    public IActionResult DeleteEducation(int id)
    {
        var values = _educationService.TGetByID(id);
        _educationService.TDelete(values);
        return Ok("Education deleted");
    }
    [HttpPut]
    public IActionResult UpdateEducation(UpdateEducationDto updateEducationDto)
    {
        Education education = _mapper.Map<Education>(updateEducationDto);
        _educationService.TUpdate(education);
        return Ok("Education updated");
    }
    [HttpGet("GetEducation")]
    public IActionResult GetEducation(int id)
    {
        var values = _educationService.TGetByID(id);
        return Ok(values);
    }
}
