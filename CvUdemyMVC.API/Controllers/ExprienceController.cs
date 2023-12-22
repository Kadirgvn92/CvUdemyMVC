using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DtoLayer.ExprienceDto;
using CvUdemyMVC.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvUdemyMVC.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExprienceController : ControllerBase
{
    private readonly IExprienceService _exprienceService;

    public ExprienceController(IExprienceService exprienceService)
    {
        _exprienceService = exprienceService;
    }

    [HttpGet]
    public IActionResult ExprienceList()
    {
        var values = _exprienceService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateExprience(CreateExprienceDto createExprienceDto)
    {
        Exprience exprience = new Exprience()
        {
            Title = createExprienceDto.Title,
            Subtitle = createExprienceDto.Subtitle,
            Description = createExprienceDto.Description,
            Date = createExprienceDto.Date
        };
        _exprienceService.TAdd(exprience);
        return Ok("Exprience created");
    }
    [HttpDelete]
    public IActionResult DeleteExprience(int id)
    {
        var values = _exprienceService.TGetByID(id);
        _exprienceService.TDelete(values);
        return Ok("Exprience deleted");
    }
    [HttpPut]
    public IActionResult UpdateExprience(UpdateExprienceDto updateExprienceDto)
    {
        Exprience exprience = new Exprience()
        {
          ExprienceID = updateExprienceDto.ExprienceID,
          Title = updateExprienceDto.Title,
          Subtitle = updateExprienceDto.Subtitle,
          Description = updateExprienceDto.Description,
          Date = updateExprienceDto.Date
        };
        _exprienceService.TUpdate(exprience);
        return Ok("Exprience updated");
    }
    [HttpGet("GetExprience")]
    public IActionResult GetExprience(int id)
    {
        var values = _exprienceService.TGetByID(id);
        return Ok(values);
    }
}
