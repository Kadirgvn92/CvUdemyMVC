using AutoMapper;
using CvUdemyMVC.DtoLayer.AboutDto;
using CvUdemyMVC.EntityLayer;

namespace CvUdemyMVC.API.Mapping;

public class AboutMapping : Profile
{
    public AboutMapping()
    {
        CreateMap<About, ResultAboutDto>().ReverseMap();
        CreateMap<About, CreateAboutDto>().ReverseMap();
        CreateMap<About, UpdateAboutDto>().ReverseMap();
        CreateMap<About, GetAboutDto>().ReverseMap();
    }
}
