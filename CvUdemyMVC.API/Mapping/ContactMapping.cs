using AutoMapper;
using CvUdemyMVC.DtoLayer.ContactDto;
using CvUdemyMVC.EntityLayer;

namespace CvUdemyMVC.API.Mapping;

public class ContactMapping : Profile
{
    public ContactMapping()
    {
        CreateMap<Contact, ResultContactDto>().ReverseMap();
        CreateMap<Contact, CreateContactDto>().ReverseMap();
        CreateMap<Contact, UpdateContactDto>().ReverseMap();
        CreateMap<Contact, GetContactDto>().ReverseMap();
    }
}
