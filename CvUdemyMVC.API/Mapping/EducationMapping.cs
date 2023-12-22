using AutoMapper;
using CvUdemyMVC.DtoLayer.EducationDto;
using CvUdemyMVC.EntityLayer;

namespace CvUdemyMVC.API.Mapping;

public class EducationMapping : Profile
{
    public EducationMapping()
    {
        CreateMap<Education, ResultEducationDto>().ReverseMap();
        CreateMap<Education, CreateEducationDto>().ReverseMap();
        CreateMap<Education, UpdateEducationDto>().ReverseMap();
        CreateMap<Education, GetEducationDto>().ReverseMap();

    }
}
