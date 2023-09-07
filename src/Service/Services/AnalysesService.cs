using Service.DTOs.Analyses;
using Service.Interfaces;

namespace Service.Services;

public class AnalysesService : IAnalyseService
{
    public Task<AnalyseResultDto> CreateAsync(AnalyseCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AnalyseResultDto>> GetAllAnalysesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AnalyseResultDto> GetAsync(long Id)
    {
        throw new NotImplementedException();
    }
}
