using AutoMapper;
using System.Linq.Expressions;
using WebApp.Application.Dtos.certificateTitle;
using WebApp.Core.Interfaces;
using WebApp.Core.models;

namespace WebApp.Application.Services
{
    public class CertificateTitleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CertificateTitleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(AddCertificateTitleDto dto)
        {
            var certificateTitle = _mapper.Map<AddCertificateTitleDto, CertificateTitle>(dto);
            await _unitOfWork.CertificateTitleRepo.AddAsync(certificateTitle);
        }

        public async Task<ReadCertificateTitleDto> GetByIdAsync(int id)
        {
            var certificateTitle = await _unitOfWork.CertificateTitleRepo.GetAsync(c => c.Id == id);
            var certificteTitleDto = _mapper.Map<CertificateTitle, ReadCertificateTitleDto>(certificateTitle);
            return certificteTitleDto;
        }

        public async Task<IEnumerable<ReadCertificateTitleDto>> GetAllAsync(Expression<Func<CertificateTitle, bool>> filter = null!,
            bool isTracked = true, int pageSize = 0, int pageNumber = 0, params Expression<Func<CertificateTitle, object>>[] includes)
        {
            var certificateTitles = await _unitOfWork.CertificateTitleRepo.GetAllAsync(filter: filter, isTracked: isTracked, pageSize: pageSize,
              pageNumber: pageNumber, includes: includes);
            var certificteTitleDtos = new List<ReadCertificateTitleDto>();

            foreach (var certificateTitle in certificateTitles)
            {
                var certificteTitleDto = _mapper.Map<CertificateTitle, ReadCertificateTitleDto>(certificateTitle);
                certificteTitleDtos.Add(certificteTitleDto);
            }
            return certificteTitleDtos;
        }


        public void Update(UpdateCertificateTitleDto dto)
        {
            var certificateTitle = _mapper.Map<UpdateCertificateTitleDto, CertificateTitle>(dto);
            _unitOfWork.CertificateTitleRepo.Update(certificateTitle);
        }

        public async void Remove(int id)
        {
            var certificateTitle = await _unitOfWork.CertificateTitleRepo.GetAsync(c => c.Id == id);
            _unitOfWork.CertificateTitleRepo.Remove(certificateTitle);
        }
    }

}
