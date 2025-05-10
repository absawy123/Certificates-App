using AutoMapper;
using System.Linq.Expressions;
using WebApp.Application.Dtos.referenceStandared;
using WebApp.Core.Interfaces;
using WebApp.Core.models;

namespace WebApp.Application.Services
{
    public class ReferenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReferenceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(AddReferenceDto dto)
        {
            var reference = _mapper.Map<AddReferenceDto, ReferenceStandared>(dto);
            await _unitOfWork.ReferenceRepo.AddAsync(reference);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ReadReferenceDto> GetByIdAsync(int id)
        {
            var reference = await _unitOfWork.ReferenceRepo.GetAsync(c => c.Id == id);
            var referenceDto = _mapper.Map<ReferenceStandared, ReadReferenceDto>(reference);
            return referenceDto;
        }

        public async Task<IEnumerable<ReadReferenceDto>> GetAllAsync(Expression<Func<ReferenceStandared, bool>> filter = null!,
            bool isTracked = true, int pageSize = 0, int pageNumber = 0, params Expression<Func<ReferenceStandared, object>>[] includes)
        {
            var references = await _unitOfWork.ReferenceRepo.GetAllAsync(filter: filter, isTracked: isTracked, pageSize: pageSize,
              pageNumber: pageNumber, includes: includes);
            var referenceDtos = new List<ReadReferenceDto>();

            foreach (var reference in references)
            {
                var referenceDto = _mapper.Map<ReferenceStandared, ReadReferenceDto>(reference);
                referenceDtos.Add(referenceDto);
            }
            return referenceDtos;
        }


        public async Task UpdateAsync(UpdateReferenceDto dto)
        {
            var reference = _mapper.Map<UpdateReferenceDto, ReferenceStandared>(dto);
            _unitOfWork.ReferenceRepo.Update(reference);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var reference = await _unitOfWork.ReferenceRepo.GetAsync(c => c.Id == id);
            _unitOfWork.ReferenceRepo.Remove(reference);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
