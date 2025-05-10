using AutoMapper;
using System.Linq.Expressions;
using WebApp.Application.Dtos.certificateType;
using WebApp.Core.Interfaces;
using WebApp.Core.models;

namespace WebApp.Application.Services
{
    public class LocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(AddLocationDto dto)
        {
            var location = _mapper.Map<AddLocationDto, Location>(dto);
            await _unitOfWork.LocationRepo.AddAsync(location);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ReadLocationDto> GetByIdAsync(int id)
        {
            var location = await _unitOfWork.LocationRepo.GetAsync(c => c.Id == id);
            var locationDto = _mapper.Map<Location, ReadLocationDto>(location);
            return locationDto;
        }

        public async Task<IEnumerable<ReadLocationDto>> GetAllAsync(Expression<Func<Location, bool>> filter = null!,
            bool isTracked = true, int pageSize = 0, int pageNumber = 0, params Expression<Func<Location, object>>[] includes)
        {
            var locations = await _unitOfWork.LocationRepo.GetAllAsync(filter: filter, isTracked: isTracked, pageSize: pageSize,
              pageNumber: pageNumber, includes: includes);
            var locationDtos = new List<ReadLocationDto>();

            foreach (var location in locations)
            {
                var locationDto = _mapper.Map<Location, ReadLocationDto>(location);
                locationDtos.Add(locationDto);
            }
            return locationDtos;
        }


        public async void Update(UpdateLocationDto dto)
        {
            var location = _mapper.Map<UpdateLocationDto, Location>(dto);
            _unitOfWork.LocationRepo.Update(location);
            await _unitOfWork.SaveChangesAsync();
        }

        public async void Remove(int id)
        {
            var location = await _unitOfWork.LocationRepo.GetAsync(c => c.Id == id);
            _unitOfWork.LocationRepo.Remove(location);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
