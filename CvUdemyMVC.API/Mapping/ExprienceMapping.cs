using AutoMapper;
using CvUdemyMVC.DtoLayer.ExprienceDto;
using CvUdemyMVC.EntityLayer;

namespace CvUdemyMVC.API.Mapping;

public class ExprienceMapping : Profile
{
    public ExprienceMapping()
    {
        CreateMap<Exprience, ResultExprienceDto>().ReverseMap();
        CreateMap<Exprience, CreateExprienceDto>().ReverseMap();
        CreateMap<Exprience, UpdateExprienceDto>().ReverseMap();
        CreateMap<Exprience, GetExprienceDto>().ReverseMap();
    }
}
