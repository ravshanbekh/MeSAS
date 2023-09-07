using Service.DTOs.Analyses;

namespace Service.Interfaces;

public interface IAnalyseService
{
    Task<AnalyseResultDto> CreateAsync(AnalyseCreationDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<AnalyseResultDto>> GetAllAnalysesAsync();
    Task<AnalyseResultDto> GetAsync(long Id);
}
