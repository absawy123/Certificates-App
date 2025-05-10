using AutoMapper;
using System.Linq.Expressions;
using WebApp.Application.Dtos.certificateType;
using WebApp.Core.Interfaces;
using WebApp.Core.models;

namespace WebApp.Application.Services
{
    public class InspectedItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InspectedItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(AddItemDto dto)
        {
            var item = _mapper.Map<AddItemDto, InspectedItem>(dto);
            await _unitOfWork.InspectedItemRepo.AddAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ReadItemDto> GetByIdAsync(int id)
        {
            var item = await _unitOfWork.InspectedItemRepo.GetAsync(c => c.Id == id);
            var itemDto = _mapper.Map<InspectedItem, ReadItemDto>(item);
            return itemDto;
        }

        public async Task<IEnumerable<ReadItemDto>> GetAllAsync(Expression<Func<InspectedItem, bool>> filter = null!,
            bool isTracked = true, int pageSize = 0, int pageNumber = 0, params Expression<Func<InspectedItem, object>>[] includes)
        {
            var items = await _unitOfWork.InspectedItemRepo.GetAllAsync(filter: filter, isTracked: isTracked, pageSize: pageSize,
              pageNumber: pageNumber, includes: includes);
            var itemDtos = new List<ReadItemDto>();

            foreach (var item in items)
            {
                var itemDto = _mapper.Map<InspectedItem, ReadItemDto>(item);
                itemDtos.Add(itemDto);
            }
            return itemDtos;
        }


        public async Task UpdateAsync(UpdateItemDto dto)
        {
            var item = _mapper.Map<UpdateItemDto, InspectedItem>(dto);
            _unitOfWork.InspectedItemRepo.Update(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAysnc(int id)
        {
            var item = await _unitOfWork.InspectedItemRepo.GetAsync(c => c.Id == id);
            _unitOfWork.InspectedItemRepo.Remove(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
