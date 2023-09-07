using Service.DTOs.Doctors;

namespace Service.Interfaces;

public interface IDoctorService
{
    Task<DoctorResultDto> CreateAsync(DoctorCreationDto dto);
    Task<DoctorResultDto> UpdateAsync(DoctorUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<DoctorResultDto>> GetAllDoctorsAsync();
    Task<DoctorResultDto> GetAsync(long id);
}
