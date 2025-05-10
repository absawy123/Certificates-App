using AutoMapper;
using WebApp.Application.Dtos.certtificateType;
using WebApp.Core.models;

namespace WebApp.Application.Mappers
{
    public class CertificateTypeProfile : Profile
    {
        public CertificateTypeProfile()
        {
            CreateMap<AddCerTypeDto, CertificateType>();
            CreateMap<UpdateCerTypeDto, CertificateType>();
            CreateMap<CertificateType, ReadCerTypeDto>();
        }

    }



}
