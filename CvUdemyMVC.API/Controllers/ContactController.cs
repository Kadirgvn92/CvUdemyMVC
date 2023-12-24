using AutoMapper;
using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DtoLayer.ContactDto;
using CvUdemyMVC.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvUdemyMVC.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;
    private readonly IMapper _mapper;

    public ContactController(IContactService contactService, IMapper mapper)
    {
        _contactService = contactService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult ContactList()
    {
        var values = _contactService.TGetAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateContact(CreateContactDto createContactDto)
    {
        Contact contact = _mapper.Map<Contact>(createContactDto);
        _contactService.TAdd(contact);
        return Ok("Contact created");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteContact(int id)
    {
        var values = _contactService.TGetByID(id);
        _contactService.TDelete(values);
        return Ok("Contact deleted");
    }
    [HttpPut]
    public IActionResult UpdateContact(UpdateContactDto updateContactDto)
    {
        Contact contact = _mapper.Map<Contact>(updateContactDto);
        _contactService.TUpdate(contact);
        return Ok("Contact updated");
    }
    [HttpGet("{id}")]
    public IActionResult GetContact(int id)
    {
        var values = _contactService.TGetByID(id);
        return Ok(values);
    }
}
