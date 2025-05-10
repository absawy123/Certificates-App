using AutoMapper;
using WebApp.Application.Dtos.Certificate;
using WebApp.Core.models;

namespace WebApp.Application.Mappers
{
    public class CertificateProfile : Profile
    {
            public CertificateProfile()
            {
                CreateMap<AddCertificateDto, Certificate>();
                CreateMap<UpdateCertificateDto, Certificate>();
                CreateMap<Certificate, ReadCertificateDto>();
            }
        
    }



}
