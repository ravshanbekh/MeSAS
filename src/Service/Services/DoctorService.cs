using Service.DTOs.Doctors;
using Service.Interfaces;

namespace Service.Services;

public class DoctorService : IDoctorSevice
{
    public Task<DoctorResultDto> CreateAsync(DoctorCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DoctorResultDto>> GetAllDoctorsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<DoctorResultDto> GetAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<DoctorResultDto> UpdateAsync(DoctorUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
