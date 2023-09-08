using Domain.Configuration;
using Domain.Enums;
using Service.DTOs.Attachments;

using Service.DTOs.Attachments;

using Service.DTOs.Users;

namespace Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> CreateAsync(UserCreationDto dto);
    Task<UserResultDto> UpdateAsync(UserUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<UserResultDto>> GetAllUsersAsync();
    Task<IEnumerable<UserResultDto>> GetAllUsersAsync(PaginationParams @params);
    Task<UserResultDto> GetAsync(long id);

    ValueTask<UserResultDto> UpgradeRoleAsync(long id, UserRole role);

    Task<UserResultDto> ImageUploadAsync(long id, AttachmentCreationDto dto);
}
