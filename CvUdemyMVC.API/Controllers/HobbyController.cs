using AutoMapper;
using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DtoLayer.HobbyDto;
using CvUdemyMVC.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvUdemyMVC.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class HobbyController : ControllerBase
{
    private readonly IHobbyService _hobbyService;
    private readonly IMapper _mapper;

    public HobbyController(IHobbyService hobbyService,IMapper mapper)
    {
        _hobbyService = hobbyService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult HobbyList()
    {
        var values = _hobbyService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateHobby(CreateHobbyDto createHobbyDto)
    {
        Hobby hobby = _mapper.Map<Hobby>(createHobbyDto);
        _hobbyService.TAdd(hobby);
        return Ok("Hobby created");
    }
    [HttpDelete]
    public IActionResult DeleteHobby(int id)
    {
        var values = _hobbyService.TGetByID(id);
        _hobbyService.TDelete(values);
        return Ok("Hobby deleted");
    }
    [HttpPut]
    public IActionResult UpdateHobby(UpdateHobbyDto updateHobbyDto)
    {
        Hobby hobby = _mapper.Map<Hobby>(updateHobbyDto);
        _hobbyService.TUpdate(hobby);
        return Ok("Hobby updated");
    }
    [HttpGet("GetHobby")]
    public IActionResult GetHobby(int id)
    {
        var values = _hobbyService.TGetByID(id);
        return Ok(values);
    }
}
