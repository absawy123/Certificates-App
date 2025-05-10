using AutoMapper;
using WebApp.Application.Dtos.certificateType;
using WebApp.Core.models;

namespace WebApp.Application.Mappers
{
    public class InspectedItemProfile : Profile
    {
        public InspectedItemProfile()
        {
            CreateMap<AddItemDto, InspectedItem>();
            CreateMap<UpdateItemDto, InspectedItem>();
            CreateMap<InspectedItem, ReadItemDto>();
        }

    }



}
