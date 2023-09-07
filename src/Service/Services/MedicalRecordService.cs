using Service.DTOs.MedicalRecords;
using Service.Interfaces;

namespace Service.Services;

public class MedicalRecordService : IMedicalRecordService
{
    public Task<MedicalRecordResultDto> CreateAsync(MedicalRecordCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MedicalRecordResultDto>> GetAllMedicalRecordsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<MedicalRecordResultDto> GetAsync(long Id)
    {
        throw new NotImplementedException();
    }
}
