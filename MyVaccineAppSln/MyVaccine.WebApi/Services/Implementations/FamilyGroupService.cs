using AutoMapper;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class FamilyGroupService : IFamilyGroupService
    {
        private readonly IFamilyGroupRepository _repository;
        private readonly IMapper _mapper;

        public FamilyGroupService(IFamilyGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FamilyGroupResponseDto>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<FamilyGroupResponseDto>>(entities);
        }

        public async Task<FamilyGroupResponseDto?> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<FamilyGroupResponseDto>(entity);
        }

        public async Task<FamilyGroupResponseDto> Create(FamilyGroupRequestDto request)
        {
            var entity = _mapper.Map<FamilyGroup>(request);
            await _repository.Add(entity);
            return _mapper.Map<FamilyGroupResponseDto>(entity);
        }

        public async Task<FamilyGroupResponseDto?> Update(FamilyGroupRequestDto request, int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.Name = request.Name;
            await _repository.Update(entity);

            return _mapper.Map<FamilyGroupResponseDto>(entity);
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