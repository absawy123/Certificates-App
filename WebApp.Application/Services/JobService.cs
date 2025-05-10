using AutoMapper;
using System.Linq.Expressions;
using WebApp.Application.Dtos.certificateType;
using WebApp.Core.Interfaces;
using WebApp.Core.models;

namespace WebApp.Application.Services
{
    public class JobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(AddJobDto dto)
        {
            var job = _mapper.Map<AddJobDto, Job>(dto);
            await _unitOfWork.JobRepo.AddAsync(job);
        }

        public async Task<ReadJobDto> GetByIdAsync(int id)
        {
            var job = await _unitOfWork.JobRepo.GetAsync(c => c.Id == id);
            var jobDto = _mapper.Map<Job, ReadJobDto>(job);
            return jobDto;
        }

        public async Task<IEnumerable<ReadJobDto>> GetAllAsync(Expression<Func<Job, bool>> filter = null!,
            bool isTracked = true, int pageSize = 0, int pageNumber = 0, params Expression<Func<Job, object>>[] includes)
        {
            var jobs = await _unitOfWork.JobRepo.GetAllAsync(filter: filter, isTracked: isTracked, pageSize: pageSize,
              pageNumber: pageNumber, includes: includes);
            var jobDtos = new List<ReadJobDto>();

            foreach (var job in jobs)
            {
                var jobDto = _mapper.Map<Job, ReadJobDto>(job);
                jobDtos.Add(jobDto);
            }
            return jobDtos;
        }


        public void Update(UpdateJobDto dto)
        {
            var job = _mapper.Map<UpdateJobDto, Job>(dto);
            _unitOfWork.JobRepo.Update(job);
        }

        public async void Remove(int id)
        {
            var job = await _unitOfWork.JobRepo.GetAsync(c => c.Id == id);
            _unitOfWork.JobRepo.Remove(job);
        }
    }

}
