using Service.DTOs.Hospitals;
using Service.Interfaces;

namespace Service.Services;

public class HospitalService : IHospitalService
{
    public Task<HospitalResultDto> CreateAsync(HospitalCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<HospitalResultDto>> GetAllHospitalsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<HospitalResultDto> GetAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<HospitalResultDto> UpdateAsync(HospitalUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
