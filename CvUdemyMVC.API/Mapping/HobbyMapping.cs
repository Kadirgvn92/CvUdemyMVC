using AutoMapper;
using CvUdemyMVC.DtoLayer.HobbyDto;
using CvUdemyMVC.EntityLayer;

namespace CvUdemyMVC.API.Mapping;

public class HobbyMapping : Profile
{
    public HobbyMapping()
    {
        CreateMap<Hobby, ResultHobbyDto>().ReverseMap();
        CreateMap<Hobby, CreateHobbyDto>().ReverseMap();
        CreateMap<Hobby, UpdateHobbyDto>().ReverseMap();
        CreateMap<Hobby, GetHobbyDto>().ReverseMap();
    }
}
