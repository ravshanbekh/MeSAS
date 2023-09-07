using Service.DTOs.Hospitals;
using Service.DTOs.Users;

namespace Service.Interfaces;

public interface IHospitalService
{
    Task<HospitalResultDto> CreateAsync(HospitalCreationDto dto);
    Task<HospitalResultDto> UpdateAsync(HospitalUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<HospitalResultDto>> GetAllHospitalsAsync();
    Task<HospitalResultDto> GetAsync(long id);
}
