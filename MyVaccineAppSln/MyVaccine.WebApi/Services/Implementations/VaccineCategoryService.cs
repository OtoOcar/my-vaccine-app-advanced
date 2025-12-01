using AutoMapper;
using MyVaccine.WebApi.Dtos.VaccineCategory;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class VaccineCategoryService : IVaccineCategoryService
    {
        private readonly IVaccineCategoryRepository _repository;
        private readonly IMapper _mapper;

        public VaccineCategoryService(IVaccineCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VaccineCategoryResponseDto>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<VaccineCategoryResponseDto>>(entities);
        }

        public async Task<VaccineCategoryResponseDto?> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<VaccineCategoryResponseDto>(entity);
        }

        public async Task<VaccineCategoryResponseDto> Create(VaccineCategoryRequestDto request)
        {
            var entity = _mapper.Map<VaccineCategory>(request);
            await _repository.Add(entity);
            return _mapper.Map<VaccineCategoryResponseDto>(entity);
        }

        public async Task<VaccineCategoryResponseDto?> Update(VaccineCategoryRequestDto request, int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.Name = request.Name;
            await _repository.Update(entity);

            return _mapper.Map<VaccineCategoryResponseDto>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.Delete(entity);
            return true;
        }
    }
}