using Service.DTOs.MedicalRecords;
using Service.DTOs.Users;

namespace Service.Interfaces;

public interface IMedicalRecordService
{
    Task<MedicalRecordResultDto> CreateAsync(MedicalRecordCreationDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<MedicalRecordResultDto>> GetAllMedicalRecordsAsync();
    Task<MedicalRecordResultDto> GetAsync(long id);
}
