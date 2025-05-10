using AutoMapper;
using WebApp.Application.Dtos.certificateType;
using WebApp.Core.models;

namespace WebApp.Application.Mappers
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<AddLocationDto, Location>();
            CreateMap<UpdateLocationDto, Location>();
            CreateMap<Location, ReadLocationDto>();
        }

    }



}
