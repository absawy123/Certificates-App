using AutoMapper;
using System.Linq.Expressions;
using WebApp.Application.Dtos.certtificateType;
using WebApp.Core.Interfaces;
using WebApp.Core.models;

namespace WebApp.Application.Services
{
    public class CertificateTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CertificateTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(AddCerTypeDto dto)
        {
            var certificateType = _mapper.Map<AddCerTypeDto, CertificateType>(dto);
            await _unitOfWork.CertificateTypeRepo.AddAsync(certificateType);
        }

        public async Task<ReadCerTypeDto> GetByIdAsync(int id)
        {
            var certificateType = await _unitOfWork.CertificateTypeRepo.GetAsync(c => c.Id == id);
            var certificateTypeDto = _mapper.Map<CertificateType, ReadCerTypeDto>(certificateType);
            return certificateTypeDto;
        }

        public async Task<IEnumerable<ReadCerTypeDto>> GetAllAsync(Expression<Func<CertificateType, bool>> filter = null!,
            bool isTracked = true, int pageSize = 0, int pageNumber = 0, params Expression<Func<CertificateType, object>>[] includes)
        {
            var certificateTpes = await _unitOfWork.CertificateTypeRepo.GetAllAsync(filter: filter, isTracked: isTracked, pageSize: pageSize,
              pageNumber: pageNumber, includes: includes);
            var certificateDtos = new List<ReadCerTypeDto>();

            foreach (var cerType in certificateTpes)
            {
                var certificateDto = _mapper.Map<CertificateType, ReadCerTypeDto>(cerType);
                certificateDtos.Add(certificateDto);
            }
            return certificateDtos;
        }


        public void Update(UpdateCerTypeDto dto)
        {
            var certificateType = _mapper.Map<UpdateCerTypeDto, CertificateType>(dto);
            _unitOfWork.CertificateTypeRepo.Update(certificateType);
        }

        public async void Remove(int id)
        {
            var certificateType = await _unitOfWork.CertificateTypeRepo.GetAsync(c => c.Id == id);
            _unitOfWork.CertificateTypeRepo.Remove(certificateType);
        }

        public async Task<int> SaveChangesAsync() => await _unitOfWork.SaveChangesAsync();
        
    }

}
