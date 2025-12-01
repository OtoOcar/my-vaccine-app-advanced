using AutoMapper;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class VaccineService : IVaccineService
    {
        private readonly IVaccineRepository _repository;
        private readonly IMapper _mapper;

        public VaccineService(IVaccineRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VaccineResponseDto>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<VaccineResponseDto>>(entities);
        }

        public async Task<VaccineResponseDto?> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<VaccineResponseDto>(entity);
        }

        public async Task<VaccineResponseDto> Create(VaccineRequestDto request)
        {
            var entity = _mapper.Map<Vaccine>(request);
            await _repository.Add(entity, request.CategoryIds);
            return _mapper.Map<VaccineResponseDto>(entity);
        }

        public async Task<VaccineResponseDto?> Update(VaccineRequestDto request, int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.Name = request.Name;
            entity.RequiresBooster = request.RequiresBooster;

            await _repository.Update(entity, request.CategoryIds);
            return _mapper.Map<VaccineResponseDto>(entity);
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