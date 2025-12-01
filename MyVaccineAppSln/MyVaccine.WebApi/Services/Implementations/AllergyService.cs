using MyVaccine.WebApi.Models;
using AutoMapper;
using MyVaccine.WebApi.Dtos.Allergy;

public class AllergyService : IAllergyService
{
    private readonly IAllergyRepository _allergyRepository;
    private readonly IMapper _mapper;

    public AllergyService(IAllergyRepository allergyRepository, IMapper mapper)
    {
        _allergyRepository = allergyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AllergyResponseDto>> GetAll()
    {
        var entities = await _allergyRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AllergyResponseDto>>(entities);
    }

    public async Task<AllergyResponseDto?> GetById(int id)
    {
        var entity = await _allergyRepository.GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<AllergyResponseDto>(entity);
    }

    public async Task<AllergyResponseDto> Create(AllergyRequestDto request)
    {
        var entity = _mapper.Map<Allergy>(request);
        await _allergyRepository.Add(entity);
        return _mapper.Map<AllergyResponseDto>(entity);
    }

    public async Task<AllergyResponseDto?> Update(AllergyRequestDto request, int id)
    {
        var entity = await _allergyRepository.GetByIdAsync(id);
        if (entity == null) return null;

        entity.Name = request.Name;
        entity.UserId = request.UserId;

        await _allergyRepository.Update(entity);
        return _mapper.Map<AllergyResponseDto>(entity);
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await _allergyRepository.GetByIdAsync(id);
        if (entity == null) return false;

        await _allergyRepository.Delete(entity);
        return true;
    }
}