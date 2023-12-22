using AutoMapper;
using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DtoLayer.SkillDto;
using CvUdemyMVC.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvUdemyMVC.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;
    private readonly IMapper _mapper;


    public SkillController(ISkillService skillService, IMapper mapper)
    {
        _skillService = skillService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult SkillList()
    {
        var values = _skillService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateSkill(CreateSkillDto createSkillDto)
    {
        Skill skill = _mapper.Map<Skill>(createSkillDto);
        _skillService.TAdd(skill);
        return Ok("Skill created");
    }
    [HttpDelete]
    public IActionResult DeleteSkill(int id)
    {
        var values = _skillService.TGetByID(id);
        _skillService.TDelete(values);
        return Ok("Skill deleted");
    }
    [HttpPut]
    public IActionResult UpdateSkill(UpdateSkillDto updateSkillDto)
    {
        Skill skill = _mapper.Map<Skill>(updateSkillDto);
        _skillService.TUpdate(skill);
        return Ok("Skill updated");
    }
    [HttpGet("GetSkill")]
    public IActionResult GetSkill(int id)
    {
        var values = _skillService.TGetByID(id);
        return Ok(values);
    }
}
