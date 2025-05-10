using AutoMapper;
using WebApp.Application.Dtos.referenceStandared;
using WebApp.Core.models;

namespace WebApp.Application.Mappers
{
    public class ReferenceProfile : Profile
    {
        public ReferenceProfile()
        {
            CreateMap<AddReferenceDto, ReferenceStandared>();
            CreateMap<UpdateReferenceDto, ReferenceStandared>();
            CreateMap<ReferenceStandared, ReadReferenceDto>();
           
        }

    }



}
