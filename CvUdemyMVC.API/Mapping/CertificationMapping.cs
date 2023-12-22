using AutoMapper;
using CvUdemyMVC.DtoLayer.CertificationDto;
using CvUdemyMVC.EntityLayer;

namespace CvUdemyMVC.API.Mapping;

public class CertificationMapping : Profile
{
    public CertificationMapping()
    {
        CreateMap<Certification, ResultCertificationDto>().ReverseMap();
        CreateMap<Certification, CreateCertificationDto>().ReverseMap();
        CreateMap<Certification, UpdateCertificationDto>().ReverseMap();
        CreateMap<Certification, GetCertificationDto>().ReverseMap();

    }
}
