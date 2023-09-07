using Service.DTOs.Messages;

namespace Service.Interfaces;

public interface IMessageService
{
    Task<MessageResultDto> CreateAsync(MessageCreationDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<MessageResultDto>> GetAllMessagesAsync();
    Task<MessageResultDto> GetAsync(long id);
}
