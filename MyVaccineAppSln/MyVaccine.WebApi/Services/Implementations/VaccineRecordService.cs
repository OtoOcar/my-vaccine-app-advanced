using AutoMapper;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class VaccineRecordService : IVaccineRecordService
    {
        private readonly IVaccineRecordRepository _repository;
        private readonly IMapper _mapper;

        public VaccineRecordService(IVaccineRecordRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VaccineRecordResponseDto>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<VaccineRecordResponseDto>>(entities);
        }

        public async Task<VaccineRecordResponseDto?> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<VaccineRecordResponseDto>(entity);
        }

        public async Task<VaccineRecordResponseDto> Create(VaccineRecordRequestDto request)
        {
            var entity = _mapper.Map<VaccineRecord>(request);
            await _repository.Add(entity);
            return _mapper.Map<VaccineRecordResponseDto>(entity);
        }

        public async Task<VaccineRecordResponseDto?> Update(VaccineRecordRequestDto request, int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.UserId = request.UserId;
            entity.DependentId = request.DependentId;
            entity.VaccineId = request.VaccineId;
            entity.DateAdministered = request.DateAdministered;
            entity.AdministeredLocation = request.AdministeredLocation;
            entity.AdministeredBy = request.AdministeredBy;

            await _repository.Update(entity);
            return _mapper.Map<VaccineRecordResponseDto>(entity);
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