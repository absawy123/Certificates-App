using AutoMapper;
using WebApp.Application.Dtos.certificateType;
using WebApp.Core.models;

namespace WebApp.Application.Mappers
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<AddJobDto, Job>();
            CreateMap<UpdateJobDto, Job>();
            CreateMap<Job, ReadJobDto>();
        }

    }



}
