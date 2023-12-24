using AutoMapper;
using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DtoLayer.CertificationDto;
using CvUdemyMVC.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvUdemyMVC.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CertificationController : ControllerBase
{
    private readonly ICertificationService _certificationService;
    private readonly IMapper _mapper;

    public CertificationController(ICertificationService certificationService, IMapper mapper)
    {
        _certificationService = certificationService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult CertificationList()
    {
        var values = _certificationService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateCertification(CreateCertificationDto createCertificationDto)
    {
        Certification certification = _mapper.Map<Certification>(createCertificationDto);
        _certificationService.TAdd(certification);
        return Ok("Certification created");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteCertification(int id)
    {
        var values = _certificationService.TGetByID(id);
        _certificationService.TDelete(values);
        return Ok("Certification deleted");
    }
    [HttpPut]
    public IActionResult UpdateCertification(UpdateCertificationDto updateCertificationDto)
    {
        Certification certification = _mapper.Map<Certification>(updateCertificationDto);
        _certificationService.TUpdate(certification);
        return Ok("Certification updated");
    }
    [HttpGet("{id}")]
    public IActionResult GetCertification(int id)
    {
        var values = _certificationService.TGetByID(id);
        return Ok(values);
    }
}
