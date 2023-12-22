using AutoMapper;
using CvUdemyMVC.DtoLayer.SkillDto;
using CvUdemyMVC.EntityLayer;

namespace CvUdemyMVC.API.Mapping;

public class SkillMapping:Profile
{
    public SkillMapping()
    {
        CreateMap<Skill, ResultSkillDto>().ReverseMap();
        CreateMap<Skill, CreateSkillDto>().ReverseMap();
        CreateMap<Skill, UpdateSkillDto>().ReverseMap();
        CreateMap<Skill, GetSkillDto>().ReverseMap();
    }
}
