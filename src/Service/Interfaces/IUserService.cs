using Service.DTOs.Users;

namespace Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> CreateAsync(UserCreationDto dto);
    Task<UserResultDto> UpdateAsync(UserUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<UserResultDto>> GetAllUsersAsync();
    Task<UserResultDto> GetAsync(long Id);
}
