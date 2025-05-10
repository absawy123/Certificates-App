using AutoMapper;
using WebApp.Application.Dtos.certificateTitle;
using WebApp.Core.models;

namespace WebApp.Application.Mappers
{
    public class CertificateTitleProfile : Profile
    {
        public CertificateTitleProfile()
        {
            CreateMap<AddCertificateTitleDto, CertificateType>();
            CreateMap<UpdateCertificateTitleDto, CertificateType>();
            CreateMap<CertificateTitle, ReadCertificateTitleDto>();
        }

    }



}
