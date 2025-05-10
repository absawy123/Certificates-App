using AutoMapper;
using System.Linq.Expressions;
using WebApp.Application.Dtos.Certificate;
using WebApp.Core.Interfaces;
using WebApp.Core.models;

namespace WebApp.Application.Services
{
    public class CertificateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CertificateService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(AddCertificateDto certificateDto)
        {
            var certificate = _mapper.Map<AddCertificateDto, Certificate>(certificateDto);
            await _unitOfWork.CertificateRepo.AddAsync(certificate);
        }

        public async Task<ReadCertificateDto> GetByIdAsync(int id)
        {
            var certificate = await _unitOfWork.CertificateRepo.GetAsync(c => c.Id == id);
            var certificateDto = _mapper.Map<Certificate, ReadCertificateDto>(certificate);
            return certificateDto;
        }

        public async Task<IEnumerable<ReadCertificateDto>> GetAllAsync(Expression<Func<Certificate, bool>> filter = null! ,
            bool isTracked=true, int pageSize=0, int pageNumber=0 ,params Expression<Func<Certificate, object>>[] includes)
        {
            var certificates= await _unitOfWork.CertificateRepo.GetAllAsync(filter:filter,isTracked: isTracked, pageSize: pageSize,
              pageNumber:pageNumber,includes:includes);
            var certificateDtos = new List<ReadCertificateDto>();

            foreach (var certificate in certificates)
            {
                var certificateDto = _mapper.Map<Certificate, ReadCertificateDto>(certificate);
                certificateDtos.Add(certificateDto);
            }
            return certificateDtos;
        }
           

        public void Update(UpdateCertificateDto certificateDto)
        {
            var certificate = _mapper.Map<UpdateCertificateDto,Certificate>(certificateDto);
            _unitOfWork.CertificateRepo.Update(certificate);
        }

        public async void Remove(int id)
        {
            var certificate =await _unitOfWork.CertificateRepo.GetAsync(c => c.Id == id);
            _unitOfWork.CertificateRepo.Remove(certificate);
        }
    }

}
